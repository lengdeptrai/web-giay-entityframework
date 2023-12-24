using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class AddProductController : Controller
    {
        private IManageProduct manageProduct;

        public AddProductController()
        {
            this.manageProduct = new ManageProduct();   
        }
        public void AddProuct(Product product)
        {
            manageProduct.addProduct(product);
        }
    }
}
