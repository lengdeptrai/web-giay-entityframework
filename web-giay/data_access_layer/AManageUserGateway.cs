using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public abstract class AManageUserGateway : IManageUserGateway
    {
        public abstract void addUser(UserStore user);
        public abstract void deleteUser(int userId);
        public abstract UserStore FindUserByEmailAndPassword(string email, string password);
        public abstract List<UserStore> getAllUserStores();
        public abstract UserStore getUserById(int userId);
        public abstract List<UserStore> getUserByName(string userName);
        public abstract bool isEmailExits(string email);
        public abstract void updateUser(UserStore user);
    }
}
