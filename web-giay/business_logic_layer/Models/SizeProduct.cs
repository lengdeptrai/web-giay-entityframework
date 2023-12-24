using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("SizeProduct")]
    public class SizeProduct
    {
        [Key]
        private int sizeProductId;
        private int productId;
        private int sizeId;
        private int quantity;

        public int SizeProductId { get => sizeProductId; set => sizeProductId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int SizeId { get => sizeId; set => sizeId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
