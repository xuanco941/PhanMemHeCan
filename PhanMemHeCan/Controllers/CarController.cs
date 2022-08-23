using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.Car;
using PhanMemHeCan.Models.Car.CarViewModel;

namespace PhanMemHeCan.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ViewBag.Cars = CarBusiness.GetAllCars();
            }
            catch
            {
                ViewBag.Cars = null;
                //Loi
            }
            return View();
        }
        //Thêm
        [HttpPost]
        public IActionResult AddCar([FromBody] AddCarViewModel addCarViewModel)
        {
            try
            {
                CarBusiness.AddCar(addCarViewModel);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }
        [HttpPost]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            try
            {
                CarBusiness.UpdateCar(car);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }
        [HttpPost]
        public IActionResult DeleteGroup([FromBody] CarIDViewModel carIDViewModel)
        {
            try
            {
                CarBusiness.DeleteCar(carIDViewModel.CarID);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }

    }
}
