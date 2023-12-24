using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public interface IManageOrderDAO
    {
        public List<OrderStore> getAllOrderTrue();
        public List<OrderStore> getAllOrderFalse();

        public void updateOrder(OrderStore orderStore);
    }
}
