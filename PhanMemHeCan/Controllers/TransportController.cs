using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Transport;
using PhanMemHeCan.Models.Transport.ViewModels;

namespace PhanMemHeCan.Controllers
{
    public class TransportController : Controller
    {

        public IActionResult Index([FromQuery(Name = "page")] int? page, [FromQuery(Name = "productname")] string? productname, 
            [FromQuery(Name = "timestart")] DateTime? timestart, [FromQuery(Name = "timeend")] DateTime? timeend,
            [FromQuery(Name = "productweightstart")] double? productweightstart, [FromQuery(Name = "productweightend")] double? productweightend)
        {
            int pagereal = page ?? 1;
            try
            {
                TransportPagination transportPagination = new TransportPagination();
                transportPagination.SearchTransport(pagereal, productname, timestart, timeend, productweightstart, productweightend);
                return Json(transportPagination);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

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
        [HttpPost]
        public IActionResult AddTransport([FromBody] AddTransportViewModel addTransportViewModel)
        {
            int rowChanged = 0;

            try
            {
                //trả về số dòng thay đổi trên database
                rowChanged = TransportBusiness.AddTransport(addTransportViewModel);
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
