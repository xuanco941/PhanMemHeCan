using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemHeCan.Models.Transport
{
    [Table("Transport")]
    public class Transport
    {
        [Key]
        public int TransportID { get; set; }
        [StringLength(100)]
        public string? ProductName { get; set; }
        [StringLength(100)]
        public string? Customer { get; set; }
        public double? ProductWeight { get; set; }
        public double? CarWeight { get; set; }
        public double? TotalWeight { get; set; }
        [StringLength(100)]
        public string? NumberPlates { get; set; }
        public string? ImagePath { get; set; }
        [StringLength(100)]
        public string? UsernamePerformer { get; set; }
        public DateTime? CreateAt { get; set; }

        public Transport(int transportID, string? productName, string? customer, double? productWeight, double? carWeight, double? totalWeight, string? numberPlates, string? imagePath, string? usernamePerformer, DateTime? createAt)
        {
            TransportID = transportID;
            ProductName = productName;
            Customer = customer;
            ProductWeight = productWeight;
            CarWeight = carWeight;
            TotalWeight = totalWeight;
            NumberPlates = numberPlates;
            ImagePath = imagePath;
            UsernamePerformer = usernamePerformer;
            CreateAt = createAt;
        }

        public Transport()
        {
        }
    }

}
