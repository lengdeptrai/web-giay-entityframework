using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class UpdateUserController : Controller
    {
        private IManageUser manageUser;

        public UpdateUserController()
        {
            this.manageUser = new ManageUser();

        }
        public void UpdateUser(UserStore user)
        {
            manageUser.updateUser(user);
        }
    }
}
