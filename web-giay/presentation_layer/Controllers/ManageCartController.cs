using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageCartController : Controller
    {

        private AddItemCartController addItemCartController;
        private DeleteItemCartController deleteItemCartController;
        private UpdateItemCartController updateItemCartController;
        private IManageSizeProduct manageSizeProduct;
        private readonly IManageProduct manageProduct;


        public ManageCartController(IHttpContextAccessor httpContextAccessor)
        {
            this.addItemCartController = new AddItemCartController(httpContextAccessor);
            this.deleteItemCartController = new DeleteItemCartController(httpContextAccessor);
            this.updateItemCartController = new UpdateItemCartController(httpContextAccessor);
            this.manageProduct = new ManageProduct();
            this.manageSizeProduct = new ManageSizeProduct();
        }

        public IActionResult Index(string fullName, string? admin)
        {

            ViewBag.Name = fullName;
            ViewBag.AccessAdmin = admin;
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ? new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            List<Product> products = new List<Product>();

            foreach(ItemCart item in carts)
            {
                Product product = manageProduct.getProductById(item.ProductId);
                products.Add(product);
            }

            ViewData["Products"] = products;
            ViewData["Carts"] = carts;
            Console.WriteLine(products.Count);
            Console.WriteLine(carts.Count);
            return View("~/presentation_layer/Views/Cart/Index.cshtml");
        }

        [HttpPost]
        public IActionResult AddItemCartFromProductDetails()
        {

            int quantity = Int32.Parse(Request.Form["QuantityCart"]);
            int productId = Int32.Parse(Request.Form["ProductId"]);
            int sizeId = Int32.Parse(Request.Form["SizeCart"]);
            Console.WriteLine(productId);
            ItemCart item = new ItemCart
            {
               ProductId = productId,
               Quantity = quantity,
               SizeId = sizeId
            };
            addItemCartController.AddToCart(item);

            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);
            List<Product> products = manageProduct.getAllProducts();
            ViewBag.CountCart = carts.Count();

            Product product = manageProduct.getProductById(productId);
            return View("~/presentation_layer/Views/ProductDetails/Index.cshtml", product);
        }

        public IActionResult AddToCart(int productId)
        {

            List<SizeProduct> sizes = manageSizeProduct.getSizeProductByProductId(productId);

            int size = 0;

            if (sizes.Count > 0) size = sizes[0].SizeId;

            ItemCart item = new ItemCart
            {
                ProductId = productId,
                Quantity = 0,
                SizeId = size
            };
            addItemCartController.AddToCart(item);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteItemCart(int productId, int sizeId)
        {
            deleteItemCartController.DeleteItemCart(productId, sizeId);
            return RedirectToAction("Index", "ManageCart");
        }

        [HttpPost]
        public IActionResult UpdateItemCart([FromBody]ItemCart item)
        {
            updateItemCartController.UpdateItemCart(item);
            return RedirectToAction("Index", "ManageCart");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
