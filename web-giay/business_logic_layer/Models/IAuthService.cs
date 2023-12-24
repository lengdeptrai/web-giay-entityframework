namespace web_giay.business_logic_layer.Models
{
    public interface IAuthService
    {
        public string GenerateJWTToken(UserStore user);
        public string GetNameFromJWTToken(string jwtToken);

        public int GetIdFromJWTToken(string jwtToken);
    }
}
