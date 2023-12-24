using Microsoft.EntityFrameworkCore;
using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageUserGateway : AManageUserGateway
    {
        public override void addUser(UserStore user)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public override void deleteUser(int userId)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var userDelete = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
                    if (userDelete != null)
                    {
                        dbContext.Users.Remove(userDelete);
                        dbContext.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public override UserStore FindUserByEmailAndPassword(string email, string password)
        {
            UserStore user = new UserStore();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                     user = dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return user;
        }

        public override List<UserStore> getAllUserStores()
        {
            List<UserStore> users = new List<UserStore>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    users = dbContext.Users.ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return users;
        }

        public override UserStore getUserById(int userId)
        {
            UserStore userStore = new UserStore();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                   userStore = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return userStore;
        }

        public override List<UserStore> getUserByName(string userName)
        {
            List<UserStore> users = new List<UserStore>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    users = dbContext.Users.Where(u => EF.Functions.Like(u.Name, $"%{userName}%")).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return users;
        }


        public override bool isEmailExits(string email)
        {
            bool isEmailExits = false;
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                   isEmailExits =  dbContext.Users.Any(u => u.Email == email);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return isEmailExits;
        }

        public override void updateUser(UserStore user)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var existingUser = dbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
                    if (existingUser != null)
                    {
                        existingUser.Name = user.Name;
                        existingUser.Address = user.Address;
                        existingUser.Phone = user.Phone;
                        existingUser.Email = user.Email;
                        existingUser.Access = user.Access;
                        existingUser.Password = user.Password;
                        Console.WriteLine(existingUser.Password);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("ko thấy");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
