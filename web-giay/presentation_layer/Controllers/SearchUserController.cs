using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class SearchUserController : Controller
    {

        private IManageUser manageUser;

        public SearchUserController()
        {
            this.manageUser = new ManageUser();
        }
        public List<UserStore> SearchUser(string name)
        {
            return manageUser.getUserByName(name);
        }
    }
}
