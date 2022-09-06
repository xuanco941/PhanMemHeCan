
using Microsoft.EntityFrameworkCore;

namespace PhanMemHeCan
{
    public class Common
    {
        //public const string ConnectionString = @"Data Source=DESKTOP-P4IC2M8\SQLEXPRESS;Initial Catalog=PhanMemHeCan;User ID=sa;Password=942001xX";

        public const string ConnectionString = @"Data Source=DESKTOP-2DFVLQ2\SQLEXPRESS;Initial Catalog=PhanMemHeCan;Integrated Security=True";

        public const string SESSION_USERID = "SESSION_USERID";

        public static List<int> listIdUserHasDeleted = new List<int>();

    }
}
