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
            var transport = phanMemHeCanContext.Transport.FirstOrDefault(t => t.TransportID == transportIDViewModel.TransportID);
            if(transport != null)
            {
                phanMemHeCanContext.Remove(transport);
            }
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
