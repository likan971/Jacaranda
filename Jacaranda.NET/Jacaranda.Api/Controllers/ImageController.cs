using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Jacaranda.Utilities.Interfaces;

namespace Jacaranda.Api.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageController : ApiController
    {
        private readonly ICloudStorage _cloudStorage;

        public ImageController(ICloudStorage cloudStorage)
        {
            _cloudStorage = cloudStorage;
        }


        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();

            using (var stream = _cloudStorage.GetFileStream(null, null))
            {
                if (stream == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }

                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}