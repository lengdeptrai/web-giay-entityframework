using Microsoft.AspNetCore.Mvc;

namespace web_giay.presentation_layer.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("AuthToken");

            return RedirectToAction("Index", "Home");
        }
    }
}
