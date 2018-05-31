using System.Web.Http;
using Jacaranda.Owin.Security.Wechat;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Jacaranda.Owin.Test.Startup))]
namespace Jacaranda.Owin.Test
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            #region Test owin middleware here

            app.UseWechatAuthentication(new WechatAuthenticationOptions());

            #endregion

            app.UseWebApi(GetHttpConfiguration());
        }

        private HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            return config;
        }
    }
}
