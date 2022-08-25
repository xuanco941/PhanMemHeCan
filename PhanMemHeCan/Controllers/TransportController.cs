using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Transport;
using PhanMemHeCan.Models.Transport.ViewModels;

namespace PhanMemHeCan.Controllers
{
    public class TransportController : Controller
    {

        public IActionResult Index([FromQuery(Name = "page")] int? page, [FromQuery(Name = "productName")] string? productName, 
            [FromQuery(Name = "timeStart")] DateTime? timeStart, [FromQuery(Name = "timeEnd")] DateTime? timeEnd,
            [FromQuery(Name = "productWeightStart")] double? productWeightStart, [FromQuery(Name = "productWeightEnd")] double? productWeightEnd, [FromQuery(Name = "numberResultOnPage")] int? numberResultOnPage)
        {
            int pagereal = page ?? 1;
            try
            {
                TransportPagination transportPagination = new TransportPagination();
                transportPagination.SearchTransport(pagereal, productName, timeStart, timeEnd, productWeightStart, productWeightEnd, numberResultOnPage);
                return Json(transportPagination);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public IActionResult AddTransport()
        {
            return View();
        }





        [HttpPost]
        public IActionResult DeleteTransport([FromBody] TransportIDViewModel transportIDViewModel)
        {
            int rowChanged = 0;
            try
            {
                rowChanged = TransportBusiness.DeleteTransportFromID(transportIDViewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Transport> { status = true, message = "Xóa thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                return Json(new ResponseViewModel<Transport> { status = false, message = "Xóa không thành công.", rowsNumberChanged = rowChanged, data = null });
            }
            catch
            {
                return Json(new ResponseViewModel<Transport> { status = false, message = "Lỗi hệ thống, không thể xóa chuyến hàng này.", rowsNumberChanged = rowChanged, data = null });
            }
        }



        //
        private readonly IWebHostEnvironment webHostEnvironment;
        public TransportController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }
        [HttpPost]
        public IActionResult AddTransport(AddTransportViewModel viewModel, IFormFile file)
        {
            if (file != null)
            {
                string folderSave = "images/"+DateTime.Now.Year.ToString()+"/"+ DateTime.Now.Month.ToString()+"/"+DateTime.Now.Day;
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folderSave);
                //nếu không tồn tại folder này thì tạo
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                viewModel.ImagePath = folderSave+"/"+uniqueFileName;
            }

            int rowChanged = 0;

            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = TransportBusiness.AddTransport(viewModel);
                if (rowChanged > 0)
                {
                    return Json(new ResponseViewModel<Transport> { status = true, message = "Thêm thành công.", rowsNumberChanged = rowChanged, data = null });
                }
                else
                {
                    return Json(new ResponseViewModel<Transport> { status = false, message = "Thêm không thành công.", rowsNumberChanged = rowChanged, data = null });
                }

            }
            catch(Exception ex)
            {
                return Json(new ResponseViewModel<Transport> { status = false, message = ex.Message , rowsNumberChanged = rowChanged, data = null });
            }
        }
    }
}
