using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{


    public class SearchController : Controller
    {

        private readonly IManageProduct manageProduct;


        public SearchController(IManageProduct manageProduct)
        {
            this.manageProduct = manageProduct; 
        }
        public IActionResult SearchProduct(string txtSearch)
        {
                ViewData["txtSearch"] = txtSearch;
                List<Product> products = manageProduct.getProductByName(txtSearch);
                return  View("~/presentation_layer/Views/Home/Index.cshtml", products);
        }
    }
}
