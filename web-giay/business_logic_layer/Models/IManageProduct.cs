namespace web_giay.business_logic_layer.Models
{
    public interface IManageProduct
    {
        public void addProduct(Product p);

        public void updateProduct(Product p);

        public void deleteProduct(int ProductId);

        public Product getProductById(int ProductId);

        public List<Product> getProductByName(String ProductName);

        public List<Product> getAllProducts();

        public List<Product> getAllCategoryProducts(int CategoryId);

    }
}
