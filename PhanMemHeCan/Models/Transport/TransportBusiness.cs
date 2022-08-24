using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using PhanMemHeCan.Models.Transport.ViewModels;

namespace PhanMemHeCan.Models.Transport
{
    public class TransportBusiness
    {

        public static int DeleteTransportFromID(TransportIDViewModel transportIDViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var transport = (from t in phanMemHeCanContext.Transport where t.TransportID == transportIDViewModel.TransportID select t).First();
            phanMemHeCanContext.Remove(transport);
            return phanMemHeCanContext.SaveChanges();
        }

        public static int AddTransport(AddTransportViewModel addTransportViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Transport.Add(new Transport { ProductName = addTransportViewModel.ProductName, Customer = addTransportViewModel.Customer, ProductWeight = addTransportViewModel.ProductWeight, CarWeight = addTransportViewModel.CarWeight, TotalWeight = addTransportViewModel.TotalWeight, NumberPlates = addTransportViewModel.NumberPlates, ImagePath = addTransportViewModel.ImagePath, UsernamePerformer = addTransportViewModel.UsernamePerformer });
            return phanMemHeCanContext.SaveChanges();
        }
    }
}
