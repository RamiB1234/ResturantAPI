using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models.Entities;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult Post([FromBody] Reservation reservation)
        {
            return StatusCode(200);
        }
    }
}
