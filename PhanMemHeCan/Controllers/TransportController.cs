using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models;
using PhanMemHeCan.Models.Transport;
using PhanMemHeCan.Models.Transport.ViewModels;

namespace PhanMemHeCan.Controllers
{
    public class TransportController : Controller
    {
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
