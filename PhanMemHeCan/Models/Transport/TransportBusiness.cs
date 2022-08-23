using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using PhanMemHeCan.Models.Transport.TransportViewModel;

namespace PhanMemHeCan.Models.Transport
{
    public class TransportBusiness
    {

        public static bool DeleteTransportFromID(int TransportID)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            var transport = (from t in phanMemHeCanContext.Transport where t.TransportID == TransportID select t).First();
            phanMemHeCanContext.Remove(transport);
            if (phanMemHeCanContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddTransport(AddTransportViewModel addTransportViewModel)
        {
            PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
            phanMemHeCanContext.Transport.Add(new Transport { ProductName = addTransportViewModel.ProductName, Customer = addTransportViewModel.Customer, ProductWeight = addTransportViewModel.ProductWeight, CarWeight = addTransportViewModel.CarWeight, TotalWeight = addTransportViewModel.TotalWeight, NumberPlates = addTransportViewModel.NumberPlates, ImagePath = addTransportViewModel.ImagePath, UsernamePerformer = addTransportViewModel.UsernamePerformer });
            return phanMemHeCanContext.SaveChanges() > 0 ? true : false;
        }
    }
}
