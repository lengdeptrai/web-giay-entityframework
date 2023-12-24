namespace web_giay.business_logic_layer.Models
{
    public interface IManageOrder
    {
        public List<OrderStore> getAllOrderTrue();
        public List<OrderStore> getAllOrderFalse();

        public void updateOrder(OrderStore orderStore);
    }
}
