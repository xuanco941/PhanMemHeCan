namespace PhanMemHeCan.Models.User.ViewModels
{
    public class AddUserViewModel
    {
        public string FullName { get; set; }
        // username lower + trim
        public string Username { get; set; }
        public string Password { get; set; }
        public int GroupID { get; set; }
    }
}
