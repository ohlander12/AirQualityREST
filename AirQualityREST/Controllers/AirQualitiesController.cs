using Luftkvalitet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQualityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualitiesController : ControllerBase
    {
        private readonly MeasurementRepo meassurements = new MeasurementRepo();

        // GET: api/<AirQualitiesController>
        [HttpGet]
        public IEnumerable<Measurement> Get([FromQuery] string? Location, [FromQuery] DateTime? dateTimeLower, [FromQuery] DateTime? dateTimeUpper)
        {
            return meassurements.GetAll(Location, dateTimeLower, dateTimeUpper);
        }

        // GET api/<AirQualitiesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Measurement> Get(int id)
        {
            Measurement? measurement = meassurements.GetById(id);
            if (measurement == null)
            {
                return NotFound("No measurement found:" + id);
            }
            else
            {
                return Ok(measurement);
            }
        }

        // POST api/<AirQualitiesController>
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<Measurement> Post([FromBody] Measurement newMeasurement)
        //{
        //    Measurement createdMeasurement = meassurements.Add(newMeasurement);
        //    if (createdMeasurement == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return Created("Measurement created", createdMeasurement);
        //    }
        //}

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
