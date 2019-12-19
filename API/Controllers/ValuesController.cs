using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet] //GET api/values
        public ActionResult<IEnumerable<string>> Get()
            { 
            return new string[] {"value1", "value2"};
            }

        [HttpGet("{id}")] //GET api/values/5
        public ActionResult<string> GetAction(int id)
        {
            return "value";
        }

        [HttpPost] //POST api/values
        public void Post([FromBody] string value)
        {}

        [HttpPut("{id}")] //PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {}

        [HttpDelete("{id}")] //DELETE api/values/5
        public void Delete(int id)
        {}
    }
}

