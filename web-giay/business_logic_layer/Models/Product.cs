using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int productId;

        private string productName;

        private string productDescription;

        private int categoryId;

        private int supplierId;

        private double productPrice;
        private string productImgURL;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductDescription { get => productDescription; set => productDescription = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public int SupplierId { get => supplierId; set => supplierId = value; }
        public double ProductPrice { get => productPrice; set => productPrice = value; }
        public string ProductImgURL { get => productImgURL; set => productImgURL = value; }
    }
}
