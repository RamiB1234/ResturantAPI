using System;
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

        public void SaveReservation(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();
        }
    }
}
