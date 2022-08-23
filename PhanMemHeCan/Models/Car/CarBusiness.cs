using PhanMemHeCan.Models.Car.CarViewModel;
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


        public static Car? GetGroupFromID(int CarID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            return (from car in phanMemHeCanContext.Car where car.CarID == CarID select car).FirstOrDefault();
        }


        // Them xe
        public static bool AddCar(AddCarViewModel addCarViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Car.Add(new Car { DriverName = addCarViewModel.DriverName, NumberPlates = addCarViewModel.NumberPlates, CarWeight = addCarViewModel.CarWeight });
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Sua xe
        public static bool UpdateCar(Car car)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var carUpdate = (from c in phanMemHeCanContext.Car where c.CarID == car.CarID select c).First();
            carUpdate = car;
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool DeleteCar(int CarID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var carDelete = (from c in phanMemHeCanContext.Car where c.CarID == CarID select c).First();
            phanMemHeCanContext.Remove(carDelete);
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
