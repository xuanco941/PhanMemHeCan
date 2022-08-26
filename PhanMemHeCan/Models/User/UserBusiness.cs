using PhanMemHeCan.Models.User.ViewModels;
using NinjaNye.SearchExtensions;
using System.Text;

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

        public static List<UserHasNameGroupViewModel> GetAllUsers()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var list = (from user in phanMemHeCanContext.User
                            join gr in phanMemHeCanContext.Group on user.GroupID equals gr.GroupID
                            select new UserHasNameGroupViewModel
                            {
                                UserID = user.UserID,
                                FullName = user.FullName,
                                Username = user.Username,
                                Password = user.Password,
                                GroupName = gr.GroupName
                            }).ToList();
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



        // chuyển tiếng việt có dấu thành không dấu
        private static string utf8Convert(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }


        // Them TK
        public static int AddUser(AddUserViewModel user)
        {
            User userAdd = new User(user.FullName, utf8Convert(user.Username).ToLower().Replace(" ", string.Empty), user.Password, user.GroupID);

            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.User.Add(userAdd);
            // số dòng thay đổi lớn hơn 0 thì đúng
            return phanMemHeCanContext.SaveChanges();

        }

        // Sua TK
        public static int UpdateUser(UserViewModel user)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userUpdate = phanMemHeCanContext.User.FirstOrDefault(u => u.UserID == user.UserID);
            if (userUpdate != null)
            {
                userUpdate.Username = utf8Convert(user.Username).ToLower().Replace(" ", string.Empty);
                userUpdate.Password = user.Password;
                userUpdate.FullName = user.FullName;
                userUpdate.GroupID = user.GroupID;
            }

            return phanMemHeCanContext.SaveChanges();
        }

        public static int DeleteUser(UserIDViewModel userIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var userDelete = phanMemHeCanContext.User.FirstOrDefault(u => u.UserID == userIDViewModel.UserID);
            if (userDelete != null)
            {
                phanMemHeCanContext.User.Remove(userDelete);
            }
            return phanMemHeCanContext.SaveChanges();

        }


        public static User? GetUserFromUsername(UserViewModel userViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            return phanMemHeCanContext.User.Where(u => u.Username == userViewModel.Username).FirstOrDefault();
        }

        public static List<string>? GetListUsername()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            return phanMemHeCanContext.User.Select(u => u.Username).ToList();
        }

    }


}
