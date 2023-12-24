using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageOrderController : Controller
    {



        public IActionResult Index(string fullName)
        {
            ViewBag.Name = fullName;
            ViewBag.IsManageOrder = "true";
            return View("~/presentation_layer/Views/ManageOrder/Index.cshtml");
        }
    }
}
