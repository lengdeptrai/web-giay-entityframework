namespace web_giay.business_logic_layer.Models
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string enteredPassword, string hashedPassword);
    }
}
