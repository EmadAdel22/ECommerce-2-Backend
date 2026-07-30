using Ecom.Api.Helper;
using System.Net;
using System.Text.Json;

namespace Ecom.Api.Middelwars
{
    public class midelwarExptions
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        public midelwarExptions(RequestDelegate next, IHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode =(int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = _environment.IsDevelopment() ?
                    new APIExeption((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    :new APIExeption((int)HttpStatusCode.InternalServerError, ex.Message);
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
