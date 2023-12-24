
using web_giay.data_access_layer;

namespace web_giay.business_logic_layer.Models
{
    public class ManageSize : IManageSize
    {
        private IManageSizeDAO manageSizeDAO;

        public ManageSize()
        {
            this.manageSizeDAO = new ManageSizeDAO(new ManageSizeGateway());
        }
        public List<Size> getAllSizes()
        {
           return manageSizeDAO.getAllSizes();
        }

        public Size getSizeById(int id)
        {
            return manageSizeDAO.getSizeById(id);
        }
    }
}
