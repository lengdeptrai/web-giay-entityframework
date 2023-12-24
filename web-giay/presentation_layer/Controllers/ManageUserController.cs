using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageUserController : Controller
    {
        private IManageUser manageUser;
        private AddUserController addUserController;
        private DeleteUserController deleteUserController;
        private UpdateUserController updateUserController;
        private SearchUserController searchUserController;
        private IPasswordHasher passwordHasher;

        public ManageUserController()
        {
            this.manageUser = new ManageUser();
            this.addUserController = new AddUserController();
            this.deleteUserController = new DeleteUserController();
            this.updateUserController = new UpdateUserController();
            this.searchUserController = new SearchUserController();
            this.passwordHasher = new PasswordHasher(); 
        }


        public IActionResult Index()
        {
            ViewBag.IsManageUser = "true";
            List<UserStore> users = manageUser.getAllUserStores();
            return View("~/presentation_layer/Views/ManageUser/Index.cshtml",users);
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string password = Request.Form["password"];
            string phone = Request.Form["phone"];
            int accessInt = Int32.Parse(Request.Form["access"]);
            bool access = false;
            if(accessInt == 1) access = true;
            if(manageUser.isEmailExits(email)) return RedirectToAction("Index", "ManageUser");
            if(password.Length < 8) return RedirectToAction("Index", "ManageUser");

            UserStore user = new UserStore
            {
                Name = name,
                Email = email,
                Password = password,
                Address = address,
                Access = access,
                Phone = phone
            };

            addUserController.AddUser(user);

            return RedirectToAction("Index", "ManageUser");
        }

        [HttpPost]
        public IActionResult UpdateUser()
        {
            int userId = Int32.Parse(Request.Form["userIdUpdate"]);
            string name = Request.Form["nameUpdate"];
            string email = Request.Form["emailUpdate"];
            string address = Request.Form["addressUpdate"];
            string password = Request.Form["passwordUpdate"];
            string phone = Request.Form["phoneUpdate"];
            int accessInt = Int32.Parse(Request.Form["accessUpdate"]);
            bool access = false;
            if (accessInt == 1) access = true;
            if(!string.IsNullOrEmpty(password) && password.Length >= 8) password = passwordHasher.HashPassword(password);
            else password = password = manageUser.getUserById(userId).Password;

            UserStore user = new UserStore
            {
                UserId = userId,
                Name = name,
                Email = email,
                Password = password,
                Address = address,
                Access = access,
                Phone = phone
            };

            updateUserController.UpdateUser(user);

            return RedirectToAction("Index", "ManageUser");
        }

        public IActionResult SearchUser(string inputNameUser)
        {
            List<UserStore> users = searchUserController.SearchUser(inputNameUser);
            return View("~/presentation_layer/Views/ManageUser/Index.cshtml", users);
        }

        public IActionResult DeleteUser(int userId)
        {
            deleteUserController.DeleteUser(userId);
            return RedirectToAction("Index", "ManageUser");
        }
    }
}
