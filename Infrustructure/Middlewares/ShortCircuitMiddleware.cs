using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore_Settings.Infrustructure.Middlewares
{
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public ShortCircuitMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["EdgeBrowser"] as bool? == true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _nextRequestDelegate.Invoke(httpContext);
            }
        }
    }
}
