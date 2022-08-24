﻿using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Car;
using PhanMemHeCan.Models.Car.ViewModels;

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
            int rowChanged = 0;
            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = CarBusiness.AddCar(addCarViewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Car> { status = true, message = "Thêm thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Car> { status = false, message = "Thêm không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Car> { status = false, message = "Lỗi hệ thống, không thể thêm xe.", rowsNumberChanged = rowChanged, data = null });
            }
        }
        [HttpPost]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            int rowChanged = 0;
            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = CarBusiness.UpdateCar(car);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Car> { status = true, message = "Cập nhật thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Car> { status = false, message = "Cập nhật không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Car> { status = false, message = "Lỗi hệ thống, không thể cập nhật.", rowsNumberChanged = rowChanged, data = null });
            }
        }
        [HttpPost]
        public IActionResult DeleteCar([FromBody] CarIDViewModel carIDViewModel)
        {
            int rowChanged = 0;
            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = CarBusiness.DeleteCar(carIDViewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Car> { status = true, message = "Xóa thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Car> { status = false, message = "Xóa không thành công.", rowsNumberChanged = rowChanged, data = null });
                }
            }
            catch
            {
                return Json(new ResponseViewModel<Car> { status = false, message = "Lỗi hệ thống, không thể xóa.", rowsNumberChanged = rowChanged, data = null });
            }
        }

    }
}
