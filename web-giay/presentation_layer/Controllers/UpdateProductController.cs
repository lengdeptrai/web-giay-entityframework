using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class UpdateProductController : Controller
    {
        private IManageProduct manageProduct;

        public UpdateProductController()
        {
            this.manageProduct = new ManageProduct();
        }
        public void UpdateProduct(Product product)
        {
            manageProduct.updateProduct(product);
        }
    }
}
