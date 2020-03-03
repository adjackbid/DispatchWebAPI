using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DispatchWebAPI.Models;

namespace DispatchWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : ControllerBase
    {
        private readonly ILogger<APIController> _logger;

        public APIController(ILogger<APIController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public object Post(APIData JsonObj) //Request DataBinding to APIDataObj
        {
            //Get Target Method
            var func = this.GetType().GetMethod(JsonObj.FunctionName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (func == null)
            {
                JsonObj.returncode = "01";
                JsonObj.returnmessage = "Function Name Not Found!!";
                JsonObj.FunctionType = "R";
                return JsonObj;
            }
            return func.Invoke(this, new object[] { JsonObj}); 
        }

        private object DoSomething(APIData JsonObj)
        {
            //change to DoSomethingContentInput obj
            var content_input = JsonConvert.DeserializeObject<DoSomthingContentInput>(JsonObj.Content?.ToString());

            //Do Something
            var content_result = new DoSomeThingContentResult()
            {
                B = $"{content_input.A}",
                C = "CCC",
            };

            JsonObj.Content = content_result;
            JsonObj.FunctionType = "R";
            JsonObj.returncode = "00";
            JsonObj.returnmessage = "OK";
            return JsonObj;
        }

    }
}
