using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class SendEmailController : Controller
    {

        private readonly IEmailSender emailSender;

        public SendEmailController()
        {
            this.emailSender = new EmailSender();
        }
        public void SendEmailRegister(string email, string name)
        {
            emailSender.SendEmailRegister(email, name);
        }
    }
}
