using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models.Entities;
using ResturantAPI.Models.Repository;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private IReservationRepository reservationRepository;

        public ReserveController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult Post([FromBody] Reservation reservation)
        {
            reservationRepository.SaveReservation(reservation);
            return StatusCode(200);
        }
    }
}
