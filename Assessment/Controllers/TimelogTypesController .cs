using Microsoft.AspNetCore.Mvc;
using Assessment.Models;


namespace Assessment.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TimelogTypesController : ControllerBase
    {
        private static List<TimelogTypeResponse> _timelogTypes = new List<TimelogTypeResponse>();

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
    }
}
