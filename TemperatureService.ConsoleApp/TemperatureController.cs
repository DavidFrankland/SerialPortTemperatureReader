using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using TemperatureService.Domain;

namespace TemperatureService.ConsoleApp
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TemperatureController : ApiController
    {
        // GET api/values 
        public JsonResult<TemperatureViewModel> Get()
        {
            var model = Startup.SerialPortReader.TemperatureViewModel;
            return Json(model);
        }

        /*
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("{Temperature:1.23,Message:\"OK\"}", Encoding.UTF8, "application/json")
            };
        }
        */

        /*
        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
        */
    }
}