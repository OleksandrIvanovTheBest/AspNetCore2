using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_Settings.Infrustructure.Middlewares
{
    public class ContentMiddleware
    {
        private RequestDelegate _nextDelegate;
        private readonly UptimeService _uptimeService;

        public ContentMiddleware(RequestDelegate next, UptimeService uptimeService)
        {
            _nextDelegate = next;
            _uptimeService = uptimeService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().ToLower() == "/middleware")
            {
                await httpContext.Response.WriteAsync("This is from the content middleware" +
                    $"(uptime: {_uptimeService.Uptime}ms)", Encoding.UTF8);
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }
    }
}
