using System;

namespace ResturantAPI.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Meal { get; set; }
        public string Notes { get; set; }
        public DateTime date { get; set; }
    }
}
