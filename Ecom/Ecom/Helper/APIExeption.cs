namespace Ecom.Api.Helper
{
    public class APIExeption : ResponseAPI
    {
        public APIExeption(int statusCode, string message = null, string details = null ) : base(statusCode, message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
