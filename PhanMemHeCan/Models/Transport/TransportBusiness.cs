using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Transport
{
    public class TransportBusiness
    {

        public static async Task DeleteTransportFromID(int TransportID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var transport = await (from t in phanMemHeCanContext.Transport where t.TransportID == TransportID select t).FirstOrDefaultAsync();
            if (transport != null)
            {
                phanMemHeCanContext.Remove(transport);
                await phanMemHeCanContext.SaveChangesAsync();
            }
        }

        public static void AddTransport(string ProductName,string Customer,double ProductWeight,double CarWeight,double TotalWeight,string NumberPlates,string ImagePath,string UsernamePerformer)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec AddTransport @ProductName,@Customer,@ProductWeight,@CarWeight,@TotalWeight,@NumberPlates,@ImagePath,@UsernamePerformer";
            command.Parameters.AddWithValue("ProductName",ProductName);
            command.Parameters.AddWithValue("Customer", Customer);
            command.Parameters.AddWithValue("ProductWeight", ProductWeight);
            command.Parameters.AddWithValue("CarWeight", CarWeight);
            command.Parameters.AddWithValue("TotalWeight", TotalWeight);
            command.Parameters.AddWithValue("NumberPlates", NumberPlates);
            command.Parameters.AddWithValue("ImagePath", ImagePath);
            command.Parameters.AddWithValue("UsernamePerformer", UsernamePerformer);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
