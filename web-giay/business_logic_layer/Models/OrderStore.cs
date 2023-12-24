using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("OrderStore")]
    public class OrderStore
    {
        private int orderId;

        private int userId;
        private int sizeProductId;
        private int quantity;
        private double total;
        private DateTime dateCreate;

        public OrderStore() { 
            dateCreate = DateTime.Now;
        }

        [Key]
        public int OrderId { get => orderId; set => orderId = value; }
        public int UserId { get => userId; set => userId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Total { get => total; set => total = value; }
        public int SizeProductId { get => sizeProductId; set => sizeProductId = value; }
        public DateTime DateCreate { get => dateCreate; set => dateCreate = value; }
    }
}
