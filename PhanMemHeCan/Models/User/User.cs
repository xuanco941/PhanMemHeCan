
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemHeCan.Models.User
{
    [Table("User")]
    public class User
    {
        public User()
        {
        }

        public User(int userID, string fullName, string username, string password, int groupID)
        {
            UserID = userID;
            FullName = fullName;
            Username = username;
            Password = password;
            GroupID = groupID;
        }

        public User(string fullName, string username, string password, int groupID)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            GroupID = groupID;
        }

        [Key]
        public int UserID { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public int GroupID { get; set; }

        public Group.Group Group { get; set; }

        
    }

}
