using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class UpdateItemCartController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateItemCartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void UpdateItemCart(ItemCart item)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;

            string cartJson = session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ? new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);


            bool productExits = carts.Any(p => p.ProductId == item.ProductId);
            if (productExits)
            {
                ItemCart existingProduct = carts.FirstOrDefault(p => p.ProductId == item.ProductId);
                existingProduct.Quantity = item.Quantity;
            }
            session.SetString("cart", JsonSerializer.Serialize(carts));
        }
    }
}
