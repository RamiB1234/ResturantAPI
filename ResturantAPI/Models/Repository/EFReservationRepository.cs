using System;
using System.Collections.Generic;
using System.Linq;
using ResturantAPI.Models.Entities;

namespace ResturantAPI.Models.Repository
{
    public class EFReservationRepository : IReservationRepository
    {
        private ApplicationDbContext context;

        public EFReservationRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Reservation> GetUserReservations(int userId)
        {
            return context.Reservations.Where(r => r.UserId == userId).OrderBy(x=> x.Id).ToList();
        }

        public void SaveReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }
    }
}
