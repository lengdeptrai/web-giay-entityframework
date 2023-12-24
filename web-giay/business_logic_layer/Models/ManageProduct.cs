using web_giay.data_access_layer;

namespace web_giay.business_logic_layer.Models
{
    public class ManageProduct : AManageProduct
    {
        private AManageProductDAO productDAO;



        public ManageProduct()
        {
            this.productDAO = new ManageProductDAO( new ManageProductGateway());
        }

        public override void addProduct(Product p)
        {
            productDAO.addProduct(p);
        }

        public override void deleteProduct(int ProductId)
        {
            productDAO.deleteProduct(ProductId);
        }


        public override List<Product> getAllProducts()
        {
             return productDAO.getAllProducts();
        }

        public override List<Product> getAllCategoryProducts(int CategoryId)
        {
            return productDAO.getAllCategoryProducts(CategoryId);
        }

        public override Product getProductById(int ProductId)
        {
            return productDAO.getProductById(ProductId);
        }

        public override List<Product> getProductByName(string ProductName)
        {
            return productDAO.getProductByName(ProductName);
        }

        public override void updateProduct(Product p)
        {
            productDAO.updateProduct(p);
        }
    }
}
