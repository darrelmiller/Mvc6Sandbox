using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using System.Threading.Tasks;
using System.IO;

namespace Mvc6Sandbox
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

          app.UseServices(services =>
                {

                    services.AddMvc();
          });

          app.UseMiddleware(typeof(BufferingMiddleware));

          app.UseMvc();
        }
    }

public class BufferingMiddleware
    {
        private RequestDelegate _next;

        public BufferingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext ctx)
        {
          var networkStream = ctx.Response.Body;
          var bufferedStream = new MemoryStream();
          ctx.Response.Body = bufferedStream;
          await _next(ctx);
          bufferedStream.Position = 0;
          ctx.Response.ContentLength = bufferedStream.Length;
          await bufferedStream.CopyToAsync(networkStream);
        }
    }
}
