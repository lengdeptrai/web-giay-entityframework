using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageSizeProductController : Controller
    {
        private IManageSizeProduct manageSizeProduct;

        public ManageSizeProductController()
        {
            this.manageSizeProduct = new ManageSizeProduct();
        }
        public IActionResult Index()
        {
            ViewBag.IsManageSizeProduct = "true";
            List<SizeProduct> sizeProducts = manageSizeProduct.getAllSizeProduct();
            return View("~/presentation_layer/Views/SizeProduct/Index.cshtml", sizeProducts);
        }

        [HttpPost]
        public IActionResult AddSizeProduct()
        {

            int productId = Int32.Parse(Request.Form["ProductId"]);
            int sizeId = Int32.Parse(Request.Form["SizeId"]);
            int quantity = Int32.Parse(Request.Form["Quantity"]);

            SizeProduct sizeProduct = new SizeProduct
            {
                ProductId = productId,
                Quantity = quantity,
                SizeId = sizeId
            };

            manageSizeProduct.addSizeProduct(sizeProduct);
            return RedirectToAction("Index", "ManageSizeProduct");
        }

        [HttpPost]
        public IActionResult UpdateSizeProduct()
        {

            int sizeProductId = Int32.Parse(Request.Form["SizeProductIdUpdate"]);
            int productId = Int32.Parse(Request.Form["ProductIdUpdate"]);
            int sizeId = Int32.Parse(Request.Form["SizeIdUpdate"]);
            int quantity = Int32.Parse(Request.Form["QuantityUpdate"]);


            SizeProduct sizeProduct = new SizeProduct
            {
                SizeProductId = sizeProductId,
                ProductId = productId,
                Quantity = quantity,
                SizeId = sizeId
            };

            manageSizeProduct.updateSizeProduct(sizeProduct);
            return RedirectToAction("Index", "ManageSizeProduct");
        }

        public IActionResult DeleteSizeProduct(int sizeProductId)
        {
            manageSizeProduct.deleteSizeProduct(sizeProductId);
            return RedirectToAction("Index", "ManageSizeProduct");
        }
    }
}
