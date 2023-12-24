using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageProductDAO : AManageProductDAO
    {
        private AManageProductGateway gateway;


        public ManageProductDAO(AManageProductGateway gateway)
        {
            this.gateway = gateway;
        }

        public override void addProduct(Product p)
        {
            gateway.addProduct(p);
        }

        public override void deleteProduct(int ProductId)
        {
            gateway.deleteProduct(ProductId);
        }



        public override List<Product> getAllProducts()
        {
            return gateway.getAllProducts();
        }

        public override List<Product> getAllCategoryProducts(int CategoryId)
        {
            return gateway.getAllCategoryProducts(CategoryId);
        }

        public override Product getProductById(int ProductId)
        {
            return gateway.getProductById(ProductId);
        }

        public override List<Product> getProductByName(string ProductName)
        {
            return gateway.getProductByName(ProductName);
        }

        public override void updateProduct(Product p)
        {
            gateway.updateProduct(p);
        }
    }
}
