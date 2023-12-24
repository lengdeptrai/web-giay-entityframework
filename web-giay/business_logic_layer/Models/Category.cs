using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        private int categoryId;
        private string categoryName;
        private string categoryDescription;

        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string CategoryDescription { get => categoryDescription; set => categoryDescription = value; }
    }
}
