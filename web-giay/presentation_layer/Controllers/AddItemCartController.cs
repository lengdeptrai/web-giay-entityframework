using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class AddItemCartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddItemCartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddToCart(ItemCart item) {

            if (item.Quantity == 0) item.Quantity = 1;
            ISession session = _httpContextAccessor.HttpContext.Session;

            string cartJson = session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ? new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);


            bool productExits = carts.Any(p => p.ProductId == item.ProductId);
            bool sizeExits = carts.Any(s => s.SizeId == item.SizeId);

            if (productExits && sizeExits)
            {
                ItemCart existingProduct = carts.FirstOrDefault(p => p.ProductId == item.ProductId);
                existingProduct.Quantity += item.Quantity ;
            }
            else
            {
                carts.Add(new ItemCart { ProductId = item.ProductId, Quantity = item.Quantity , SizeId = item.SizeId});
            }
            session.SetString("cart", JsonSerializer.Serialize(carts));

        }
    }
}