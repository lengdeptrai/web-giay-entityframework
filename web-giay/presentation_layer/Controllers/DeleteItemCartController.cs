using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class DeleteItemCartController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteItemCartController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void DeleteItemCart(int productId, int sizeId)
        {
            ISession session = _httpContextAccessor.HttpContext.Session;

            string cartJson = session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ? new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);


            bool productExits = carts.Any(p => p.ProductId == productId );
            bool sizeExits = carts.Any(s => s.SizeId == sizeId );

            if (productExits && sizeExits)
            {
                ItemCart existingProduct = carts.FirstOrDefault(p => p.ProductId == productId);
                carts.Remove(existingProduct);
            }
            session.SetString("cart", JsonSerializer.Serialize(carts));
        }
    }
}
