using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ReportController : Controller
    {
        private readonly IAuthService _authService;

        public ReportController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("AuthToken");
            if (!string.IsNullOrEmpty(token))
            {
                ViewBag.Name = _authService.GetNameFromJWTToken(token);
            }
            ViewBag.IsReport = "true";
            return View("~/presentation_layer/Views/Report/Index.cshtml");
        }
    }
}
