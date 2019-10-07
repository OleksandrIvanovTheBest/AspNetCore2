using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Settings.Infrustructure.Middlewares
{
    public class ErrorMiddleware
    {
        private RequestDelegate _nextRequestDelegate;

        public ErrorMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _nextRequestDelegate.Invoke(httpContext);

            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("Edge is not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
