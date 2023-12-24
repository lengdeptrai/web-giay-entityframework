using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public abstract class AManageProductDAO : IManageProductDAO
    {
        public abstract void addProduct(Product p);
        public abstract void deleteProduct(int ProductId);
        public abstract List<Product> getAllProducts();
        public abstract List<Product> getAllCategoryProducts(int CategoryId);
        public abstract Product getProductById(int ProductId);
        public abstract List<Product> getProductByName(string ProductName);
        public abstract void updateProduct(Product p);
    }
}
