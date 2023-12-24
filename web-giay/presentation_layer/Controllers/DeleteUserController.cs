using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class DeleteUserController : Controller
    {
        private IManageUser manageUser;

        public DeleteUserController()
        {
            manageUser = new ManageUser();
        }
        public void DeleteUser(int UserId)
        {
            manageUser.deleteUser(UserId);
        }
    }
}
