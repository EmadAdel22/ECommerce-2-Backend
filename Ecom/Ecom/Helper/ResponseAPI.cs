namespace Ecom.Api.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string message = null)
        {
            this.statusCode = statusCode;
            this.message = message?? GetMessagefromStatusCode(statusCode);
        }

        private string GetMessagefromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "OK",
                201 => "Created",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status Code"
            };
        }

        public int  statusCode { get; set; }

        public string? message { get; set; }
    }
}
