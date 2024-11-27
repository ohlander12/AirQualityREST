using Microsoft.AspNetCore.Mvc;
using Luftkvalitet;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQualityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualitiesController : ControllerBase
    {
        // GET: api/<AirQualitiesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AirQualitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AirQualitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AirQualitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirQualitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
