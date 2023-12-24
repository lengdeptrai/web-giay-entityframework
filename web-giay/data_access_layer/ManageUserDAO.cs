using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageUserDAO : AManageUserDAO
    {

        private AManageUserGateway gateway;

        public ManageUserDAO(AManageUserGateway gateway)
        {
            this.gateway = gateway;
        }

        public override void addUser(UserStore user)
        {
            this.gateway.addUser(user);
        }

        public override void deleteUser(int userId)
        {
           this.gateway.deleteUser(userId);
        }

        public override UserStore FindUserByEmailAndPassword(string email, string password)
        {
            return this.gateway.FindUserByEmailAndPassword(email, password);
        }

        public override List<UserStore> getAllUserStores()
        {
            return this.gateway.getAllUserStores();
        }

        public override UserStore getUserById(int userId)
        {
            return this.gateway.getUserById(userId);
        }

        public override List<UserStore> getUserByName(string userName)
        {
            return this.gateway.getUserByName(userName);
        }


        public override bool isEmailExits(string email)
        {
           return this.gateway.isEmailExits(email); 
        }

        public override void updateUser(UserStore user)
        {
            this.gateway.updateUser(user);
        }
    }
}
