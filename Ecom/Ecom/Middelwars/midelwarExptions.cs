using Ecom.Api.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace Ecom.Api.Middelwars
{
    public class midelwarExptions
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly IMemoryCache _memorycache;
        private readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(30);
        public midelwarExptions(RequestDelegate next, IHostEnvironment environment, IMemoryCache memorycache )
        {
            _next = next;
            _environment = environment;
            _memorycache = memorycache;
             
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if(IsRequestAlloed(context) == false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";
                    var response = new APIExeption((int)HttpStatusCode.TooManyRequests, "Too many requests. Please try again later.");
                    await context.Response.WriteAsJsonAsync(response);
                }
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

        private bool IsRequestAlloed(HttpContext context)
        { 
            var ip = context.Connection.RemoteIpAddress.ToString();
            var CachKey = $"Rate:{ip}";
            var DatNow = DateTime.Now;


            var(Timestamp , count) = _memorycache.GetOrCreate(CachKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
                return (Timestamp: DatNow, count: 0);
            });

            if (DatNow - Timestamp < _rateLimitWindow)
            {
                if (count >= 8)
                {
                    return false;
                }
                else
                {
                    _memorycache.Set(CachKey, (Timestamp, count +=1), _rateLimitWindow);
                    return true;
                }

            }
            else
            {
                _memorycache.Set(CachKey, (Timestamp, count), _rateLimitWindow);
            }
            return true;

        }
    }
}
