
using web_giay.data_access_layer;

namespace web_giay.business_logic_layer.Models
{
    public class ManageSizeProduct : IManageSizeProduct
    {

        private IManageSizeProductDAO manageSizeProductDAO;

        public ManageSizeProduct()
        {
            this.manageSizeProductDAO = new ManageSizeProductDAO(new ManageSizeProductGateway());
        }
        public void addSizeProduct(SizeProduct sizeProduct)
        {
           this.manageSizeProductDAO.addSizeProduct(sizeProduct);
        }

        public void deleteSizeProduct(int sizeProductId)
        {
            this.manageSizeProductDAO.deleteSizeProduct(sizeProductId);
        }

        public List<SizeProduct> getAllSizeProduct()
        {
           return this.manageSizeProductDAO.getAllSizeProduct();
        }

        public SizeProduct getSizeProductById(int sizeProductId)
        {
            return this.manageSizeProductDAO.getSizeProductById(sizeProductId);
        }

        public List<SizeProduct> getSizeProductByProductId(int sProductId)
        {
            return this.manageSizeProductDAO.getSizeProductByProductId(sProductId);
        }

        public void updateSizeProduct(SizeProduct sizeProduct)
        {
            this.manageSizeProductDAO.updateSizeProduct(sizeProduct);
        }
    }
}
