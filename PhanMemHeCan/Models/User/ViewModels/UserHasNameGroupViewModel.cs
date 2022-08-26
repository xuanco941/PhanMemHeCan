namespace PhanMemHeCan.Models.User.ViewModels
{
    public class UserHasNameGroupViewModel
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        //username lower + trim
        public string Username { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }
    }
}
