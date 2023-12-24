using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageAccountController : Controller
    {
        private IAuthService authService;
        private IManageUser manageUser;

        public ManageAccountController(IAuthService authService)
        {
            this.authService = authService;
            this.manageUser = new ManageUser();

        }
        public IActionResult Index()
        {
            string cartJson = HttpContext.Session.GetString("cart");
            List<ItemCart> carts = string.IsNullOrEmpty(cartJson) ?
                new List<ItemCart>() : JsonSerializer.Deserialize<List<ItemCart>>(cartJson);

            string token = HttpContext.Session.GetString("AuthToken");

            int userId = 0;
            if (!string.IsNullOrEmpty(token))
            {
                userId = authService.GetIdFromJWTToken(token);
            }
            UserStore user = manageUser.getUserById(userId);

            ViewBag.Name = user.Name;
            ViewBag.Phone = user.Phone;
            ViewBag.Address = user.Address;

            ViewBag.CountCart = carts.Count();
            return View("~/presentation_layer/Views/ManageAccount/Index.cshtml");
        }


        [HttpPost]
        public IActionResult UpdateAddress()
        {
            string address = Request.Form["AddressEdit"];
            string token = HttpContext.Session.GetString("AuthToken");

            int userId = 0;
            if (!string.IsNullOrEmpty(token))
            {
                userId = authService.GetIdFromJWTToken(token);
            }
            UserStore user = manageUser.getUserById(userId);

            user.Address = address;

            manageUser.updateUser(user);
            return RedirectToAction("Index", "ManageAccount");
        }

        [HttpPost]
        public IActionResult UpdatePhone()
        {
            string phone = Request.Form["PhoneEdit"];

            string token = HttpContext.Session.GetString("AuthToken");

            int userId = 0;
            if (!string.IsNullOrEmpty(token))
            {
                userId = authService.GetIdFromJWTToken(token);
            }
            UserStore user = manageUser.getUserById(userId);

            user.Phone = phone;

            manageUser.updateUser(user);
            return RedirectToAction("Index", "ManageAccount");
        }

        [HttpPost]
        public IActionResult UpdateName()
        {
            string name = Request.Form["NameEdit"];

            string token = HttpContext.Session.GetString("AuthToken");

            int userId = 0;
            if (!string.IsNullOrEmpty(token))
            {
                userId = authService.GetIdFromJWTToken(token);
            }
            UserStore user = manageUser.getUserById(userId);

            user.Name = name;

            manageUser.updateUser(user);
            return RedirectToAction("Index", "ManageAccount");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
