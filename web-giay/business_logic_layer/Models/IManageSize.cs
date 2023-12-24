namespace web_giay.business_logic_layer.Models
{
    public interface IManageSize
    {
        public List<Size> getAllSizes();

        public Size getSizeById(int id);
    }
}
