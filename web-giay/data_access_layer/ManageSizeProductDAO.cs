using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageSizeProductDAO : IManageSizeProductDAO
    {
        private IManageSizeProductGateway gateway;

        public ManageSizeProductDAO(IManageSizeProductGateway gateway)
        {
            this.gateway = gateway;
        }

        public void addSizeProduct(SizeProduct sizeProduct)
        {
            this.gateway.addSizeProduct(sizeProduct);
        }

        public void deleteSizeProduct(int sizeProductId)
        {
            this.gateway.deleteSizeProduct(sizeProductId);
        }

        public List<SizeProduct> getAllSizeProduct()
        {
            return this.gateway.getAllSizeProduct();
        }

        public SizeProduct getSizeProductById(int sizeProductId)
        {
            return this.gateway.getSizeProductById(sizeProductId);
        }

        public List<SizeProduct> getSizeProductByProductId(int sProductId)
        {
            return this.gateway.getSizeProductByProductId(sProductId);
        }

        public void updateSizeProduct(SizeProduct sizeProduct)
        {
            this.gateway.updateSizeProduct(sizeProduct);
        }
    }
}
