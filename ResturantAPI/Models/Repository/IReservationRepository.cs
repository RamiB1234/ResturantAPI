using ResturantAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.Repository
{
    public interface IReservationRepository
    {
        void SaveReservation(Reservation reservation);
        IEnumerable<Reservation> GetUserReservations(int userId);
    }
}
