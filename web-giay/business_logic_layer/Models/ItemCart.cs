namespace web_giay.business_logic_layer.Models
{
    public class ItemCart
    {
        private int productId;
        private int sizeId;
        private int quantity;

        public int ProductId { get => productId; set => productId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int SizeId { get => sizeId; set => sizeId = value; }
    }
}
