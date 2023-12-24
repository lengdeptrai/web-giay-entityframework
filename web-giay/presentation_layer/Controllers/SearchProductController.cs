using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class SearchProductController : Controller
    {

        private IManageProduct manageProduct;

        public SearchProductController()
        {
            this.manageProduct = new ManageProduct();
        }
        public List<Product> SearchProduct(string productName)
        {
            return manageProduct.getProductByName(productName);
        }
    }
}
