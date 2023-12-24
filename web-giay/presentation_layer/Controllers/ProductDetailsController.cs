using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IManageProduct manageProduct; 

        public ProductDetailsController()
        {
            manageProduct = new ManageProduct();
        }

        public IActionResult Index(int itemid, string? admin, string? fullName)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            ViewBag.Name = fullName;
            ViewBag.AccessAdmin = admin;
            Product product = manageProduct.getProductById(itemid);
            return View("~/presentation_layer/Views/ProductDetails/Index.cshtml", product);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
