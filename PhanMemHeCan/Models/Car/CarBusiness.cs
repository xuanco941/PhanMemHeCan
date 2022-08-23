using PhanMemHeCan.Models.Car.CarViewModel;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Car
{
    public class CarBusiness
    {
        public static List<Car> GetAllCars()
        {
            List<Car> list = new List<Car>();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            string sql = "select * from [Car]";
            var command = new SqlCommand(sql, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Car car = new Car(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDouble(3));
                list.Add(car);
            }
            sqlConnection.Close();
            return list;
        }


        public static Car GetGroupFromID(int CarID)
        {
            Car car = new Car();
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec GetCarFromID @CarID";
            command.Parameters.AddWithValue("CarID", CarID);
            command.Connection = sqlConnection;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                car = new Car(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetDouble(3));

            }
            sqlConnection.Close();
            return car;
        }


        // Them xe
        public static void AddCar(AddCarViewModel addCarViewModel)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec AddCar @NumberPlates, @DriverName, @CarWeight";
            command.Parameters.AddWithValue("NumberPlates", addCarViewModel.NumberPlates);
            command.Parameters.AddWithValue("DriverName", addCarViewModel.DriverName);
            command.Parameters.AddWithValue("CarWeight", addCarViewModel.CarWeight);


            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // Sua xe
        public static void UpdateCar(Car car)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = "exec UpdateCar @CarID, @NumberPlates, @DriverName, @CarWeight";

            command.Parameters.AddWithValue("CarID", car.CarID);
            command.Parameters.AddWithValue("NumberPlates", car.NumberPlates);
            command.Parameters.AddWithValue("DriverName", car.DriverName);
            command.Parameters.AddWithValue("CarWeight", car.CarWeight);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public static void DeleteCar(int CarID)
        {
            SqlConnection sqlConnection = new SqlConnection(Common.ConnectionString);
            sqlConnection.Open();
            var command = new SqlCommand();
            command.CommandText = $"exec DeleteCar @CarID";
            command.Parameters.AddWithValue("CarID", CarID);

            command.Connection = sqlConnection;

            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
