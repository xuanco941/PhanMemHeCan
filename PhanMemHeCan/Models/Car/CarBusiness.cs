using PhanMemHeCan.Models.Car.ViewModels;
using PhanMemHeCan.Models.Group.ViewModels;
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
            var carUpdate = phanMemHeCanContext.Car.FirstOrDefault(car => car.CarID == car.CarID);
            if (carUpdate != null)
            {
                carUpdate.CarWeight = car.CarWeight;
                carUpdate.NumberPlates = car.NumberPlates;
                carUpdate.DriverName = car.DriverName;
            }
            return phanMemHeCanContext.SaveChanges();
        }

        public static int DeleteCar(CarIDViewModel carIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var carDelete = phanMemHeCanContext.Car.FirstOrDefault(car => car.CarID == carIDViewModel.CarID);
            if (carDelete != null)
            {
                phanMemHeCanContext.Car.Remove(carDelete);
            }
            return phanMemHeCanContext.SaveChanges();
        }
    }
}
