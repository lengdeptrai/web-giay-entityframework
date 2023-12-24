
using web_giay.data_access_layer;

namespace web_giay.business_logic_layer.Models
{
    public class ManageOrder : IManageOrder
    {
        private IManageOrderDAO manageOrderDAO;


        public ManageOrder()
        {
            manageOrderDAO = new ManageOrderDAO(new ManageOrderGateway());
        }
        public List<OrderStore> getAllOrderFalse()
        {
            return manageOrderDAO.getAllOrderFalse();
        }

        public List<OrderStore> getAllOrderTrue()
        {
            return manageOrderDAO.getAllOrderTrue();
        }

        public void updateOrder(OrderStore orderStore)
        {
            manageOrderDAO.updateOrder(orderStore);
        }
    }
}
