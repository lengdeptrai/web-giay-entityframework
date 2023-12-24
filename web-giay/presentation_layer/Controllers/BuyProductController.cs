using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class BuyProductController : Controller
    {
        private DeleteItemCartController deleteItemCartController;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IManageUser manageUser;
        private IAuthService _authService;
        private IEmailSender _emailSender;
        private IManageProduct manageProduct;
        private IManageSize manageSize;

        public BuyProductController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.deleteItemCartController = new DeleteItemCartController(httpContextAccessor);
            _httpContextAccessor = httpContextAccessor;
            _authService = new AuthService(configuration);
            this.manageUser = new ManageUser();
            this._emailSender = new EmailSender();
            this.manageProduct = new ManageProduct();
            this.manageSize = new ManageSize();
        }

        [HttpPost]
        public IActionResult BuyProductFromCart([FromBody]List<ItemCart> itemCarts)
        {
            string token = HttpContext.Session.GetString("AuthToken");
            if (string.IsNullOrEmpty(token)) return Json(new { status = false });
            else
            {
                UserStore user = manageUser.getUserById(_authService.GetIdFromJWTToken(token));
                foreach (ItemCart item in itemCarts)
                {
                    OrderStore order = new OrderStore();
                    Product product = manageProduct.getProductById(item.ProductId);

                    double total = product.ProductPrice * item.Quantity;

                    Size size = manageSize.getSizeById(item.SizeId);
                    Console.WriteLine(size.SizeName);

                    _emailSender.SendEmailBuyProduct(user.Email, user.Name, order.DateCreate, product, item.Quantity, size.SizeName, total);

                    deleteItemCartController.DeleteItemCart(item.ProductId, item.SizeId);
                }
            }

            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);
            ViewBag.CountCart = carts.Count();


            return Json(new { status = true });
        }
    }
}
