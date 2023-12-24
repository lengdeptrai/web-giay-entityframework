using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IManageUser manageUser;
        private readonly IPasswordHasher passwordHasher;
        private  SendEmailController sendEmailController;

        public RegisterController()
        {
            this.manageUser = new ManageUser();
            this.passwordHasher = new PasswordHasher();
            this.sendEmailController = new SendEmailController();
        }

        public IActionResult Index()
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            ViewData["user"] = new UserStore
            {
                Name = "",
                Phone = "",
                Email = "",
                Password = "",
                Address = "",
                Access = false
            };
            return View("~/presentation_layer/Views/Register/Index.cshtml");
        }

        [HttpPost]
        public IActionResult RegisterUser(UserStore user)
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            ViewBag.CountCart = carts.Count();
            if (user != null)
            {
                ViewData["user"] = user;
                if (user.Password.Length < 8)
                {
                    ViewBag.ErrorMessage = "Password must be at least 8 characters long!";
                    return View("~/presentation_layer/Views/Register/Index.cshtml");
                }
                if (manageUser.isEmailExits(user.Email))
                {
                    ViewBag.ErrorMessage = "Failed to register user. Email already exists !";
                    return View("~/presentation_layer/Views/Register/Index.cshtml");
                }

                
                manageUser.addUser(new UserStore
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password =  passwordHasher.HashPassword(user.Password),
                    Phone = user.Phone,
                    Address = "",
                    Access = false
                });

                sendEmailController.SendEmailRegister(user.Email, user.Name);
                return RedirectToAction("Index", "Login");
            }

            sendEmailController.SendEmailRegister(user.Email, user.Name);
            ViewBag.ErrorMessage = "Failed to register user"; 
            return View("~/presentation_layer/Views/Register/Index.cshtml"); 
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
