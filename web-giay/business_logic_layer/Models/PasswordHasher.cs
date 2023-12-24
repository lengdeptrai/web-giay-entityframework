using System.Security.Cryptography;
using System.Text;

namespace web_giay.business_logic_layer.Models
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi mật khẩu từ string sang byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Hash mật khẩu
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);

                // Chuyển đổi kết quả hash từ byte array sang dạng string hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        // Phương thức kiểm tra mật khẩu đã hash có khớp với mật khẩu gốc hay không
        public bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string enteredPasswordHash = HashPassword(enteredPassword);
            return string.Equals(enteredPasswordHash, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
