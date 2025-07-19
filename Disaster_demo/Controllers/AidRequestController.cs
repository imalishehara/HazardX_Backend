using Disaster_demo.Models.Entities;
using Disaster_demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Disaster_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AidRequestController : ControllerBase
    {
        private readonly IAidRequestServices _aidrequestServices;

        public AidRequestController(IAidRequestServices aidRequestServices)
        {
            this._aidrequestServices = (AidRequestServices)aidRequestServices;
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateAidRequest([FromBody] AidRequests request)
        {
            bool result = await _aidrequestServices.CreateAidRequestAsync(request);
            if (!result)
            {
                return BadRequest("Invalid request type.");
            }

            return Ok(new { message = "Aid request submitted!" });
        }



        //[HttpGet("pending")]
        //public async Task<IActionResult> GetPendingAidRequests([FromQuery] string divisionalSecretariat)
        //{
        //    if (string.IsNullOrEmpty(divisionalSecretariat))
        //    {
        //        return BadRequest("Divisional Secretariat is required.");
        //    }

        //    var result = await _aidrequestServices.getPendingAidRequests(divisionalSecretariat);
        //    return Ok(result);
        //}

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingAidRequests([FromQuery] string divisionalSecretariat)
        {
            if (string.IsNullOrEmpty(divisionalSecretariat))
            {
                return BadRequest("Divisional Secretariat is required.");
            }

            var result = await _aidrequestServices.getPendingAidRequests(divisionalSecretariat);
            return Ok(result);
        }





        [HttpPost("updateStatus")]
        public IActionResult UpdateGnStatus([FromBody] StatusUpdateModel model)
        {
            var success = _aidrequestServices.UpdateStatus(model);
            if (!success)
                return NotFound(new { message = "Aid request not found." });

            return Ok(new { message = "Status updated successfully." });
        }

        //[HttpGet("byDistrict/{district}")]
        //public async Task<IActionResult> GetAidRequestsByDistrict(string district)
        //{
        //    if (string.IsNullOrEmpty(district))
        //        return BadRequest("District is required.");

        //    var requests = await _aidrequestServices.GetAidRequestsByDistrict(district);
        //    return Ok(requests);
        //}

        //[HttpGet("dmc-approved")]
        //public async Task<ActionResult<List<AidRequests>>> GetDmcApprovedAidRequests()
        //{
        //    var result = await _aidrequestServices.GetDmcApprovedAidRequests();
        //    return Ok(result);
        //}

        //[HttpGet("all-dmc")]
        //public async Task<ActionResult<List<AidRequests>>> GetAllDmcRelatedAidRequests([FromQuery] string district)
        //{
        //    if (string.IsNullOrEmpty(district))
        //        return BadRequest("District is required.");

        //    var result = await _aidrequestServices.GetAllDmcRelatedAidRequests(district);
        //    return Ok(result);
        //}






    }
}
