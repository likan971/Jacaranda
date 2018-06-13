using System.Data.Entity;
using System.Web;
using System.Web.Http;
using Jacaranda.Data;

namespace Jacaranda.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<JacarandaDbContext>(null);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.Configure);
        }
    }
}
