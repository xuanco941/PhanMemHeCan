using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Transport
{
    public class TransportPagination
    {
        //Không chọn tên Machine, không chọn ngày, không chọn chỉ số
        public static int Count_NoProductName_NoDate_NoProductWeight()
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "exec Count_NoProductName_NoDate_NoProductWeight";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }
        public static List<Transport> Pagination_NoProductName_NoDate_NoProductWeight(int page, int NUM_ELM)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            string sql = $"exec Pagination_NoProductName_NoDate_NoProductWeight {page}, {NUM_ELM}";

            SqlCommand command = new SqlCommand(sql, sqlConnection);
            //loi
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }




        //--Chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
        public static int Count_YesProductName_YesDate_YesProductWeight
            (string ProductName, string TimeStart, string TimeEnd, double ProductWeightStart, double ProductWeightEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_YesDate_YesProductWeight @ProductName , @TimeStart , @TimeEnd , @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_YesProductName_YesDate_YesProductWeight
            (int page, int NUM_ELM, string ProductName, string TimeStart, string TimeEnd, double ProductWeightStart, double ProductWeightEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_YesDate_YesProductWeight @page, @NUM_ELM, @ProductName , @TimeStart , @TimeEnd , @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }








        //có tên nhiên liệu, không có ngày, không có cân nặng sản phẩm

        public static int Count_YesProductName_NoDate_NoProductWeight
            (string ProductName)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_NoDate_NoProductWeight @ProductName";
            command.Parameters.AddWithValue("ProductName", ProductName);

            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_YesProductName_NoDate_NoProductWeight
            (int page, int NUM_ELM, string ProductName)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_YesProductName_NoDate_NoProductWeight @page, @NUM_ELM, @ProductName";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("ProductName", ProductName);

            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }


        //--không có tên nhiên liệu, có ngày, không có cân nặng sản phẩm
        public static int Count_NoProductName_YesDate_NoProductWeight
            (string TimeStart, string TimeEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_YesDate_YesProductWeight @TimeStart , @TimeEnd ";
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);

            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_NoProductName_YesDate_NoProductWeight
            (int page, int NUM_ELM, string TimeStart, string TimeEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_NoProductName_YesDate_NoProductWeight @page, @NUM_ELM, @TimeStart , @TimeEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);

            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }




        //--không có tên nhiên liệu, không có ngày, có cân nặng sản phẩm
        public static int Count_NoProductName_NoDate_YesProductWeight
          (double ProductWeightStart, double ProductWeightEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_NoProductName_NoDate_YesProductWeight @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_NoProductName_NoDate_YesProductWeight
            (int page, int NUM_ELM, double ProductWeightStart, double ProductWeightEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_NoProductName_NoDate_YesProductWeight @page, @NUM_ELM, @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }



        //--có product name, có date, không có cân nặng product
        public static int Count_YesProductName_YesDate_NoProductWeight
          (string ProductName, string TimeStart, string TimeEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_YesDate_NoProductWeight @ProductName , @TimeStart , @TimeEnd";
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);

            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_YesProductName_YesDate_NoProductWeight
            (int page, int NUM_ELM, string ProductName, string TimeStart, string TimeEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_YesProductName_YesDate_NoProductWeight @page, @NUM_ELM, @ProductName , @TimeStart , @TimeEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }


        //--có product name, không có date, có cân nặng
        public static int Count_YesProductName_NoDate_YesProductWeight
        (string ProductName, double ProductWeightStart, double ProductWeightEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_NoDate_YesProductWeight @ProductName, @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }

        public static List<Transport> Pagination_YesProductName_NoDate_YesProductWeight
            (int page, int NUM_ELM, string ProductName, double ProductWeightStart, double ProductWeightEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_YesProductName_NoDate_YesProductWeight @page, @NUM_ELM, @ProductName , @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("ProductName", ProductName);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }


        //-- không product name, có date, có cân nặng product

        public static int Count_NoProductName_YesDate_YesProductWeight
     (string TimeStart, string TimeEnd, double ProductWeightStart, double ProductWeightEnd)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Count_YesProductName_YesDate_YesProductWeight @TimeStart , @TimeEnd , @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            int num = 0;
            while (sqlDataReader.Read())
            {
                num = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return num;
        }



        public static List<Transport> Pagination_NoProductName_YesDate_YesProductWeight
            (int page, int NUM_ELM, string TimeStart, string TimeEnd, double ProductWeightStart, double ProductWeightEnd)
        {
            List<Transport> list = new List<Transport>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = "exec Pagination_NoProductName_YesDate_YesProductWeight @page, @NUM_ELM , @TimeStart , @TimeEnd , @ProductWeightStart, @ProductWeightEnd";
            command.Parameters.AddWithValue("page", page);
            command.Parameters.AddWithValue("NUM_ELM", NUM_ELM);
            command.Parameters.AddWithValue("TimeStart", TimeStart);
            command.Parameters.AddWithValue("TimeEnd", TimeEnd);
            command.Parameters.AddWithValue("ProductWeightStart", ProductWeightStart);
            command.Parameters.AddWithValue("ProductWeightEnd", ProductWeightEnd);


            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Transport transport = new Transport(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDouble(3), sqlDataReader.GetDouble(4), sqlDataReader.GetDouble(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetDateTime(9));
                list.Add(transport);
            }
            sqlConnection.Close();
            return list;
        }




    }
}
