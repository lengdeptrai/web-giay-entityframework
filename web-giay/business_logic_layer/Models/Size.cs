using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("Size")]
    public class Size
    {
        [Key]
        private int sizeId;
        private int sizeName;

        public int SizeId { get => sizeId; set => sizeId = value; }
        public int SizeName { get => sizeName; set => sizeName = value; }
    }
}
