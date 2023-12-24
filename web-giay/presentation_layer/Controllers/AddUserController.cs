using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class AddUserController : Controller
    {
        private IManageUser manageUser;
        private IPasswordHasher passwordHasher;


        public AddUserController()
        {
            this.manageUser = new ManageUser();
            this.passwordHasher = new PasswordHasher();
        }
       public void AddUser(UserStore userStore)
        {
            userStore.Password = passwordHasher.HashPassword(userStore.Password);
            manageUser.addUser(userStore);
        }
    }
}
