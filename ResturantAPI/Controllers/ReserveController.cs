﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models.Entities;
using ResturantAPI.Models.Repository;
using System;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReserveController : ControllerBase
    {
        private IReservationRepository reservationRepository;

        public ReserveController(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        // GET: api/reserve/1
        [HttpGet("{userId}")]
        [EnableCors("CorsPolicy")]
        public ActionResult GetReservations(int userId)
        {
            try
            {
                var reservations = reservationRepository.GetUserReservations(userId);
                return Ok(reservations);
            }
            catch
            {
                return StatusCode(400); // 400: Bad request
            }
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public ActionResult Post([FromBody] Reservation reservation)
        {
            try
            {
                // Server side validation:
                if(reservation.date< DateTime.Today)
                {
                    return StatusCode(400); // 400: Bad request
                }

                reservationRepository.SaveReservation(reservation);
                return StatusCode(201); // 201: Created
            }
            catch
            {
                return StatusCode(400); // 400: Bad request
            }
        }
    }
}
