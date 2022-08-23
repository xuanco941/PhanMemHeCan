using Microsoft.AspNetCore.Mvc;
using PhanMemHeCan.Models.Transport;
using PhanMemHeCan.Models.Transport.TransportViewModel;

namespace PhanMemHeCan.Controllers
{
    public class TransportController : Controller
    {
        [HttpPost]
        public IActionResult DeleteTransport([FromBody] TransportIDViewModel transportIDViewModel)
        {
            try
            {
                TransportBusiness.DeleteTransportFromID(transportIDViewModel.TransportID);
                return Json("success");
            }
            catch
            {
                return Json("error");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
