using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public interface IManageSizeProductGateway
    {
        public void addSizeProduct(SizeProduct sizeProduct);
        public void deleteSizeProduct(int sizeProductId);
        public List<SizeProduct> getAllSizeProduct();
        public SizeProduct getSizeProductById(int sizeProductId);
        public void updateSizeProduct(SizeProduct sizeProduct);
        public List<SizeProduct> getSizeProductByProductId(int sProductId);
    }
}
