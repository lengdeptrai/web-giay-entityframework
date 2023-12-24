namespace web_giay.business_logic_layer.Models
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Runtime.InteropServices;

    public class EmailSender : IEmailSender
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string senderEmail;
        private readonly string senderPassword;
        private string subjectRegister = "Thông báo đăng ký thành công tài khoản trên Shoe Store";
        private string subjectConfirm = "Thông báo đơn hàng đã được xác nhận từ Shoe Store";
        private string subjectBuyProduct = "Bạn đã mua một sản phẩm từ Shoe Store";
        public EmailSender()
        {
            this.smtpServer = "smtp.gmail.com";
            this.smtpPort = 587;
            this.senderEmail = "shoestore578@gmail.com";
            this.senderPassword = "gfhj jspn bjok cxxo";
        }

        public void SendEmailRegister(string recipientEmail, string recipientFullName)
        {
            string body = "<h3>Xin chào ! " + recipientFullName + ",</h3>" +
                "\r\n\r\n  <p>Chúng tôi xin gửi lời cảm ơn chân thành nhất đến bạn về việc đăng ký tài khoản mới trên nền tảng của chúng tôi. Chúng tôi rất vui mừng và trân trọng sự quan tâm và tin tưởng mà bạn đã dành cho cửa hàng chúng tôi.</p>" +
                "\r\n\r\n  <p>Việc bạn lựa chọn trở thành thành viên của cộng đồng chúng tôi không chỉ tạo điều kiện thuận lợi cho bạn trong việc truy cập và sử dụng các tính năng, mà còn giúp chúng tôi phát triển và cải thiện dịch vụ để đáp ứng tốt hơn các nhu cầu của bạn.</p>" +
                "\r\n\r\n  <p>Chúng tôi cam kết sẽ luôn nỗ lực hết mình để mang đến trải nghiệm tốt nhất cho bạn và sẽ luôn lắng nghe ý kiến đóng góp từ phía bạn.</p>" +
                "\r\n\r\n  <p>Một lần nữa, xin chân thành cảm ơn bạn đã chọn chúng tôi. Nếu có bất kỳ thắc mắc hay yêu cầu hỗ trợ nào, đừng ngần ngại liên hệ với chúng tôi. Chúng tôi luôn sẵn lòng hỗ trợ bạn mọi lúc, mọi nơi.</p>" +
                "\r\n\r\n  <p>Trân trọng,<br>" +
                "\r\n  Shoe Store</p>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subjectRegister;
                    mail.Body = body;
                    mail.IsBodyHtml = true; 

                    using (SmtpClient smtpClient = new SmtpClient(this.smtpServer, this.smtpPort))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(this.senderEmail, this.senderPassword);
                        smtpClient.EnableSsl = true; 
                        smtpClient.Send(mail);
                    }
                }
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex}");
            }
        }

        public void SendEmailBuyProduct(string recipientEmail, string recipientFullName, DateTime date, Product product, int quantity, int size, double total)
        {
            string body = "<h3>Xin chào! " + recipientFullName + ",</h3>" +
                "\r\n\r\n  <p>Chúng tôi thông báo, bạn có 1 đơn hàng của bạn ngày " + date.ToString("dd/MM/yyyy") + " với thông tin như sau:</p>" +
                "\r\n\r\n  <p>Sản phẩm: " + product.ProductName + "</p>" +
                "\r\n  <p>Số lượng: " + quantity.ToString() + "</p>" +
                "\r\n  <p>Size: " + size.ToString() + "</p>" +
                "\r\n  <p>Tổng cộng: $" + total.ToString() + "</p>" +
                "\r\n\r\n  <p>Cảm ơn bạn đã mua hàng tại cửa hàng chúng tôi. Chúng tôi sẽ xác nhận đơn hàng  trong thời gian sớm nhất.</p>" +
                "\r\n\r\n  <p>Nếu có bất kỳ thắc mắc hoặc yêu cầu hỗ trợ nào, đừng ngần ngại liên hệ với chúng tôi. Chúng tôi luôn sẵn lòng hỗ trợ bạn.</p>" +
                "\r\n\r\n  <p>Trân trọng,<br>" +
                "\r\n  Shoe Store</p>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subjectBuyProduct;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtpClient = new SmtpClient(this.smtpServer, this.smtpPort))
                    {
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(this.senderEmail, this.senderPassword);
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mail);
                    }
                }
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex}");
            }
        }

    }



}
