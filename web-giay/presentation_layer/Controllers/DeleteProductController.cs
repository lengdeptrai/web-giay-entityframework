using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class DeleteProductController : Controller
    {
        private IManageProduct manageProduct;

        public DeleteProductController()
        {
            this.manageProduct = new ManageProduct();
        }
        public void DeleteProduct(int ProductId)
        {
            manageProduct.deleteProduct(ProductId);
        }
    }
}