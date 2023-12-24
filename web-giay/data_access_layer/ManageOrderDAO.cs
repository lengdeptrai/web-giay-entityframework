using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageOrderDAO : IManageOrderDAO
    {
        private IManageOrderGateway gateway;

        public ManageOrderDAO(IManageOrderGateway gateway)
        {
            this.gateway = gateway;
        }

        public List<OrderStore> getAllOrderFalse()
        {
            return this.gateway.getAllOrderFalse();
        }

        public List<OrderStore> getAllOrderTrue()
        {
            return gateway.getAllOrderTrue();   
        }

        public void updateOrder(OrderStore orderStore)
        {
            gateway.updateOrder(orderStore);
        }
    }
}
