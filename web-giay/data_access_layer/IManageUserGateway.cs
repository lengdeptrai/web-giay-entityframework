using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public interface IManageUserGateway
    {
        public void addUser(UserStore user);

        public void updateUser(UserStore user);

        public void deleteUser(int userId);

        public UserStore getUserById(int userId);

        public List<UserStore> getUserByName(String userName);

        public bool isEmailExits(String email);
        public UserStore FindUserByEmailAndPassword(string email, string password);
        public List<UserStore> getAllUserStores();
    }
}
