using System.Web.Http;

namespace Jacaranda.Owin.Test
{
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Web Api Works");
        }
    }
}
