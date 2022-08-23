using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemHeCan.Models.Car
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int CarID { get; set; }
        [StringLength(100)]
        public string? NumberPlates { get; set; }
        [StringLength(100)]
        public string? DriverName { get; set; }
        public double? CarWeight { get; set; }

        public Car(int carID, string? numberPlates, string? driverName, double? carWeight)
        {
            CarID = carID;
            NumberPlates = numberPlates;
            DriverName = driverName;
            CarWeight = carWeight;
        }

        public Car()
        {
        }
    }
}
