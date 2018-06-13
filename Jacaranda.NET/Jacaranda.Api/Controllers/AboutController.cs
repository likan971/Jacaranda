using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Jacaranda.Api.Controllers
{
    public class AboutController : ApiController
    {
        [Route("about")]
        public IHttpActionResult Get()
        {
            return Ok("This is an ASP.NET Web Api Project");
        }
    }
}