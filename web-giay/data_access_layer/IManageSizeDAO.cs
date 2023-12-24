using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public interface IManageSizeDAO
    {
        public List<Size> getAllSizes();
        public Size getSizeById(int id);
    }
}
