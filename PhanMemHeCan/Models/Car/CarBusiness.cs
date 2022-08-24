using PhanMemHeCan.Models.Car.ViewModels;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Car
{
    public class CarBusiness
    {
        public static List<Car> GetAllCars()
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            return (from car in phanMemHeCanContext.Car select car).ToList();
        }


        public static Car? GetGroupFromID(CarIDViewModel carIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            return (from car in phanMemHeCanContext.Car where car.CarID == carIDViewModel.CarID select car).FirstOrDefault();
        }


        // Them xe
        public static int AddCar(AddCarViewModel addCarViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Car.Add(new Car { DriverName = addCarViewModel.DriverName, NumberPlates = addCarViewModel.NumberPlates, CarWeight = addCarViewModel.CarWeight });
            return phanMemHeCanContext.SaveChanges();
        }

        // Sua xe
        public static int UpdateCar(Car car)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var carUpdate = (from c in phanMemHeCanContext.Car where c.CarID == car.CarID select c).First();
            carUpdate = car;
            return phanMemHeCanContext.SaveChanges();
        }

        public static int DeleteCar(CarIDViewModel carIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var carDelete = (from c in phanMemHeCanContext.Car where c.CarID == carIDViewModel.CarID select c).First();
            phanMemHeCanContext.Remove(carDelete);
            return phanMemHeCanContext.SaveChanges();
        }
    }
}
