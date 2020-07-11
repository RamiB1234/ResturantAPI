using System;

namespace ResturantAPI.Models.Entities
{
    public class Reservation
    {
        public string Meal { get; set; }
        public string Notes { get; set; }
        public DateTime date { get; set; }
    }
}
