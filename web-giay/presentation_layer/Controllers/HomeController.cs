using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IManageProduct manageProduct;
        private IAuthService authService;

        public HomeController(IAuthService authService) { 
            this.manageProduct = new ManageProduct();
            this.authService = authService;

        }
        public IActionResult Index(string? admin)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);
            List<Product> products = manageProduct.getAllProducts();
            ViewBag.CountCart = carts.Count();
            ViewBag.AccessAdmin = admin;
            string token = HttpContext.Session.GetString("AuthToken");
            
            if (!string.IsNullOrEmpty(token))
            {
                ViewBag.Name = authService.GetNameFromJWTToken(token);
            }

            return View("~/presentation_layer/Views/Home/Index.cshtml", products);
        }

        public IActionResult Category(int categoryId, string fullName, string? admin)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            ViewBag.AccessAdmin = admin;
            ViewBag.Name = fullName;
            List<Product> products = manageProduct.getAllCategoryProducts(categoryId);
            return View("~/presentation_layer/Views/Home/Index.cshtml", products);
        }

        public IActionResult Search(string txtSearch, string? admin, string? fullName)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            ViewBag.Name = fullName;
            ViewBag.AccessAdmin = admin;
            ViewData["txtSearch"] = txtSearch;
            List<Product> products = manageProduct.getProductByName(txtSearch);
            return View("~/presentation_layer/Views/Home/Index.cshtml", products);
        }
        public IActionResult AccessAdmin(string fullName)
        {
            ViewBag.Name = fullName;
            ViewBag.AccessAdmin = "true";
            List<Product> products = manageProduct.getAllProducts();
            return View("~/presentation_layer/Views/Home/Index.cshtml", products);
        }
        public IActionResult Privacy()
        {
            return View("~/presentation_layer/Views/Home/Privacy.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
