namespace PhanMemHeCan.Models
{
    public class ResponseViewModel<T>
    {
        public bool? status;
        public string? message;
        public int? rowsNumberChanged; 
        public T? data;
    }
}
