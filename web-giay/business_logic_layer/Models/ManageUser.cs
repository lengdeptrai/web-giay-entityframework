
using web_giay.data_access_layer;

namespace web_giay.business_logic_layer.Models
{
    public class ManageUser : AManageUser
    {

        private AManageUserDAO manageUserDAO;

        public ManageUser() { 
            this.manageUserDAO = new ManageUserDAO(new ManageUserGateway());
        }
        public override void addUser(UserStore user)
        {
            this.manageUserDAO.addUser(user);
        }

        public override void deleteUser(int userId)
        {
            manageUserDAO.deleteUser(userId);
        }

        public override UserStore FindUserByEmailAndPassword(string email, string password)
        {
            return this.manageUserDAO.FindUserByEmailAndPassword(email,password);
        }

        public override List<UserStore> getAllUserStores()
        {
            return this.manageUserDAO.getAllUserStores();
        }

        public override UserStore getUserById(int userId)
        {
            return this.manageUserDAO.getUserById(userId);
        }

        public override List<UserStore> getUserByName(string userName)
        {
            return this.manageUserDAO.getUserByName(userName);
        }

        public override bool isEmailExits(string email)
        {
            return this.manageUserDAO.isEmailExits(email);
        }

        public override void updateUser(UserStore user)
        {
            this.manageUserDAO.updateUser(user);
        }
    }
}
