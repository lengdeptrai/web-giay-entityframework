using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        private int supplierId;
        private string companyName;
        private string address;
        private string city ;
        private string country;
        private string phone;

        public int SupplierId { get => supplierId; set => supplierId = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
