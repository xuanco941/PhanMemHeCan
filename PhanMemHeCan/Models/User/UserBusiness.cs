using Microsoft.EntityFrameworkCore;
using PhanMemHeCan.Models.User.UserViewModel;
using NinjaNye.SearchExtensions;
namespace PhanMemHeCan.Models.User
{

    public class UserBusiness
    {
        public static User? AuthLogin(string username, string password)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            User? user = (from u in phanMemHeCanContext.User where (u.Username == username.Trim() && u.Password == password.Trim()) select u).FirstOrDefault();
            return user;

        }

        public static List<User> GetAllUsers()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (from user in phanMemHeCanContext.User select user).ToList();
            return list;
        }

        public static List<User> FindUserByFullNameOrUsername(string name)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (phanMemHeCanContext.User.Search(x => x.Username,x => x.FullName).Containing(name)).ToList();
            return list;
        }


        public static User? GetUserFromID(int UserID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var user = (from u in phanMemHeCanContext.User where (u.UserID == UserID) select u).FirstOrDefault();
            return user;
        }


        // Them TK
        public static async Task AddUser(AddUserViewModel user)
        {
            User userAdd = new User(user.FullName, user.Username, user.Password, user.GroupID);

            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            await phanMemHeCanContext.User.AddAsync(userAdd);
            await phanMemHeCanContext.SaveChangesAsync();

        }

        // Sua TK
        public static async Task UpdateUser(User user)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userUpdate = await (from u in phanMemHeCanContext.User where (u.UserID == user.UserID) select u).FirstOrDefaultAsync();
            if (userUpdate != null)
            {
                userUpdate = user;
                await phanMemHeCanContext.SaveChangesAsync();
            }
        }

        public static async Task DeleteUser(int UserID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userDelete = await(from u in phanMemHeCanContext.User where (u.UserID == UserID) select u).FirstOrDefaultAsync();
            if (userDelete != null)
            {
                phanMemHeCanContext.Remove(userDelete);
                await phanMemHeCanContext.SaveChangesAsync();
            }
        }
    }


}
