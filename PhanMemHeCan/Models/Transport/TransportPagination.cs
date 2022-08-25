using System.Collections;
using System.Data.SqlClient;

namespace PhanMemHeCan.Models.Transport
{
    public class TransportPagination
    {
        public int numberResultOnPage { get; set; } = 50;
        public int pageCurrent { get; set; }
        public int totalPages { get; set; }
        public int totalResults { get; set; }
        public List<Transport>? listTransport { get; set; }

        //public static int CountResultSearch(string? ProductName, DateTime? TimeStart, DateTime? TimeEnd, double? ProductWeightStart, double? ProductWeightEnd)
        //{
        //    PhanMemHeCanContext phanMemHeCanContext = new PhanMemHeCanContext();
        //    int num = phanMemHeCanContext.Transport.OrderByDescending(e => e.TransportID).ToList().Count;
        //    return 1;
        //}
        public void SearchTransport(int page, string? ProductName, DateTime? TimeStart, DateTime? TimeEnd, double? ProductWeightStart, double? ProductWeightEnd, int? NumberResultOnPage)
        {
            PhanMemHeCanContext context = new PhanMemHeCanContext();

            if (NumberResultOnPage != null)
            {
                this.numberResultOnPage = NumberResultOnPage ?? 50;
            }


            int position = (page - 1) * numberResultOnPage;
            if (ProductName != null && (TimeStart != null && TimeEnd != null) && (ProductWeightStart != null && ProductWeightEnd != null))
            {
                this.totalResults = context.Transport
                .Where(t => t.ProductName == ProductName && (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => t.ProductName == ProductName && (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            //1
            else if (ProductName != null && (TimeStart == null || TimeEnd == null) && (ProductWeightStart == null || ProductWeightEnd == null))
            {
                this.totalResults = context.Transport
                .Where(t => t.ProductName == ProductName)
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => t.ProductName == ProductName)
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            else if (ProductName == null && (TimeStart != null && TimeEnd != null) && (ProductWeightStart == null || ProductWeightEnd == null))
            {
                this.totalResults = context.Transport
                .Where(t => t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd)
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd)
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            else if (ProductName == null && (TimeStart == null || TimeEnd == null) && (ProductWeightStart != null && ProductWeightEnd != null))
            {
                this.totalResults = context.Transport
                .Where(t => t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd)
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd)
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            //2
            else if (ProductName != null && (TimeStart != null && TimeEnd != null) && (ProductWeightStart == null || ProductWeightEnd == null))
            {
                this.totalResults = context.Transport
                .Where(t => (t.ProductName == ProductName) && (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd))
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => (t.ProductName == ProductName) && (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd))
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            else if (ProductName != null && (TimeStart == null || TimeEnd == null) && (ProductWeightStart != null && ProductWeightEnd != null))
            {
                this.totalResults = context.Transport
                .Where(t => (t.ProductName == ProductName) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => (t.ProductName == ProductName) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            else if (ProductName == null && (TimeStart != null && TimeEnd != null) && (ProductWeightStart != null && ProductWeightEnd != null))
            {
                this.totalResults = context.Transport
                .Where(t => (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Where(t => (t.CreateAt >= TimeStart && t.CreateAt <= TimeEnd) && (t.ProductWeight >= ProductWeightStart && t.ProductWeight <= ProductWeightEnd))
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }
            else
            {
                this.totalResults = context.Transport
                .Count();

                this.listTransport = context.Transport.OrderByDescending(t => t.TransportID)
                .Skip(position)
                .Take(numberResultOnPage)
                .ToList();
            }

            this.pageCurrent = page;
            this.totalPages = (int)Math.Ceiling((float)this.totalResults / (float)numberResultOnPage);


        }




    }
}
