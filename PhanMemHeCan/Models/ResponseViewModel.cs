namespace PhanMemHeCan.Models
{
    public class ResponseViewModel<T>
    {
        public bool? status { get; set; }
        public string? message { get; set; }
        public int? rowsNumberChanged { get; set; }
        public T? data { get; set; } 
    }
}
