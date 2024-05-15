using Microsoft.AspNetCore.Mvc;
using Assessment.Models;


namespace Assessment.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TimelogTypesController : ControllerBase
    {
        private static List<TimelogTypeResponse> _timelogTypes = new List<TimelogTypeResponse>
        {
            new TimelogTypeResponse { timelogTypeId = 1, timelogType = "Entwicklung", budget = 120 },
            new TimelogTypeResponse { timelogTypeId = 2, timelogType = "Design", budget = 100 },
            new TimelogTypeResponse { timelogTypeId = 3, timelogType = "Projektmanagement", budget = 90.5 },
            new TimelogTypeResponse { timelogTypeId = 4, timelogType = "Ferien", budget = 111 },
            new TimelogTypeResponse { timelogTypeId = 5, timelogType = "Umzug", budget = 230 }
        };
        [HttpGet]
        public ActionResult<List<TimelogTypeResponse>> GetTimelogTypes()
        {
            return _timelogTypes;
        }

        [HttpPut]
        public IActionResult CreateTimelogType([FromBody] TimelogTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            var newTimelogType = new TimelogTypeResponse
            {
                timelogTypeId = request.timelogTypeId,
                timelogType = request.timelogType,
                budget = request.budget
            };

            _timelogTypes.Add(newTimelogType);
            return Ok(newTimelogType); 
        }
        [HttpGet("{timelogTypeId}")]
        public ActionResult<TimelogTypeResponse> GetTimelogType(int timelogTypeId)
        {
            var timelogType = _timelogTypes.FirstOrDefault(t => t.timelogTypeId == timelogTypeId);
            if (timelogType == null)
            {
                return NotFound();
            }
            return timelogType;
        }
    }
}
