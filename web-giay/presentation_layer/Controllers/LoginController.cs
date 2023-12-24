using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class LoginController : Controller
    {

        private readonly IAuthService authService;
        private readonly IManageUser manageUser;
        private readonly IPasswordHasher passwordHasher;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
            this.manageUser = new ManageUser();
            this.passwordHasher = new PasswordHasher();
        }

        public IActionResult Index()
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            return View("~/presentation_layer/Views/Login/Index.cshtml");
        }

        [HttpPost]
        public IActionResult LoginUser(string email, string password)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password)) {
                UserStore user = manageUser.FindUserByEmailAndPassword(email, passwordHasher.HashPassword(password));
                if(user != null)
                {
                    string token = authService.GenerateJWTToken(user);

                    HttpContext.Session.SetString("AuthToken", token);

                    if (user.Access) return RedirectToAction("Index", "Report");

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.ErrorMessage = "Login failed . Email or password is incorrect !";
                    return View("~/presentation_layer/Views/Login/Index.cshtml");
                }
            }
            ViewBag.ErrorMessage = "Login failed";
            return View("~/presentation_layer/Views/Login/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
