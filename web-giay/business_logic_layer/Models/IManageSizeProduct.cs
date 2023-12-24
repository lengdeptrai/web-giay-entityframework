namespace web_giay.business_logic_layer.Models
{
    public interface IManageSizeProduct
    {
        public  void addSizeProduct(SizeProduct sizeProduct);
        public  void deleteSizeProduct(int sizeProductId);
        public  List<SizeProduct> getAllSizeProduct();
        public SizeProduct getSizeProductById(int sizeProductId);

        public List<SizeProduct> getSizeProductByProductId(int sProductId);
        public void updateSizeProduct(SizeProduct sizeProduct);
    }
}
