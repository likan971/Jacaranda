using Owin;
using System.IO;
using System.Web.Hosting;

namespace Jacaranda.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) => {
                if (ctx.Request.Path.Value == "/")
                {
                    var html = File.ReadAllText(HostingEnvironment.MapPath("~/HomePage.html"));
                    await ctx.Response.WriteAsync(html ?? "Home Page");
                }
                else
                {
                    await next();
                }
            });
        }

    }
}