using AirQualityREST.Luftkvalitet;
using Luftkvalitet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics.Metrics;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirQualityREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirQualitiesController : ControllerBase
    {
        //private readonly MeasurmentsRepoDB meassurements = new MeasurmentsRepoDB();

        private MeasurmentsRepoDB meassurements;

        public AirQualitiesController(MeasurmentsRepoDB measurmentsRepo)
        {
            meassurements = measurmentsRepo;
        }

        
        // GET: api/<AirQualitiesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Measurement>> Get([FromQuery] string? Location, [FromQuery] DateTime? dateTimeLower, [FromQuery] DateTime? dateTimeUpper)
        {
            List<Measurement> result = meassurements.GetAll(Location, dateTimeLower, dateTimeUpper);

            if(result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
            
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

        //POST api/<AirQualitiesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Measurement> Post([FromBody] Measurement newMeasurement)
        {
            Measurement createdMeasurement = meassurements.Add(newMeasurement);
            if (createdMeasurement == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("Measurement created", createdMeasurement);
            }
        }
        
        // DELETE api/<AirQualitiesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Measurement> Delete(int id)
        {
            var record = meassurements.GetById(id);
            if (record == null)
            {
                return NotFound("Measurement not found.");
            }
            meassurements.Delete(id);
            return NoContent();
        }

        [HttpGet("last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Measurement> GetResult()
        {
            Measurement? measurement = meassurements.GetLatestId();
            if (measurement == null)
            {
                return NotFound("Can't find measurement:");
            }
            else
            {
                return Ok(measurement);
            }
        }

    }
}
