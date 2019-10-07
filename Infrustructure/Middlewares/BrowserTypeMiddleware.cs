using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Settings.Infrustructure.Middlewares
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate _nextRequestDelegate;

        public BrowserTypeMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(value => value.ToLower().Contains("edge"));

            await _nextRequestDelegate.Invoke(httpContext);
        }
    }
}
