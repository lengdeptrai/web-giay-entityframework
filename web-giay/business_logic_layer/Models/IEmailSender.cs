namespace web_giay.business_logic_layer.Models
{
    public interface IEmailSender
    {
        public void SendEmailRegister(string recipientEmail, string recipientFullName);
        public void SendEmailBuyProduct(string recipientEmail, string recipientFullName,
            DateTime date, Product product, int quantity, int size, double total);
    }
}
