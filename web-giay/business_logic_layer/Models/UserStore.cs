
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_giay.business_logic_layer.Models
{
    [Table("UserStore")]
    public class UserStore
    {

        
        private int userId;
        private string name;
        private string email;
        private string password;
        private string address;
        private string phone;
        private bool access;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get => userId; set => userId = value; }

        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public bool Access { get => access; set => access = value; }
    }
}
