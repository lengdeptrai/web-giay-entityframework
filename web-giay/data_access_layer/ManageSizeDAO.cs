using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageSizeDAO : IManageSizeDAO
    {
        private IManageSizeGateway gateway;

        public ManageSizeDAO(IManageSizeGateway gateway)
        {
            this.gateway = gateway;
        }
        public List<Size> getAllSizes()
        {
            return gateway.getAllSizes();
        }

        public Size getSizeById(int id)
        {
            return gateway.getSizeById(id);
        }
    }
}
