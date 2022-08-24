using Microsoft.EntityFrameworkCore;
using PhanMemHeCan.Models.User.ViewModels;
using NinjaNye.SearchExtensions;
using System.Reflection.Metadata.Ecma335;

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

        public static List<User> FindUserByFullNameOrUsername(NameViewModel nameViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (phanMemHeCanContext.User.Search(x => x.Username, x => x.FullName).Containing(nameViewModel.Name)).ToList();
            return list;
        }


        public static User? GetUserFromID(UserIDViewModel userIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var user = (from u in phanMemHeCanContext.User where (u.UserID == userIDViewModel.UserID) select u).FirstOrDefault();
            return user;
        }


        // Them TK
        public static int AddUser(AddUserViewModel user)
        {
            User userAdd = new User(user.FullName, user.Username, user.Password, user.GroupID);

            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.User.Add(userAdd);
            // số dòng thay đổi lớn hơn 0 thì đúng
            return phanMemHeCanContext.SaveChanges();

        }

        // Sua TK
        public static int UpdateUser(User user)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userUpdate = (from u in phanMemHeCanContext.User where (u.UserID == user.UserID) select u).First();

            userUpdate = user;
            return phanMemHeCanContext.SaveChanges();
        }

        public static int DeleteUser(UserIDViewModel userIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userDelete = (from u in phanMemHeCanContext.User where (u.UserID == userIDViewModel.UserID) select u).First();

            phanMemHeCanContext.Remove(userDelete);
            return phanMemHeCanContext.SaveChanges();

        }
    }


}
