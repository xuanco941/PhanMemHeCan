namespace PhanMemHeCan.Models.Transport.ViewModels
{
    public class AddTransportFileViewModel
    {
        public string? ProductName { get; set; }
        public string? Customer { get; set; }
        public double? ProductWeight { get; set; }
        public double? CarWeight { get; set; }
        public double? TotalWeight { get; set; }
        public string? NumberPlates { get; set; }
        public IFormFile? File { get; set; }
        public string? UsernamePerformer { get; set; }
    }
}
