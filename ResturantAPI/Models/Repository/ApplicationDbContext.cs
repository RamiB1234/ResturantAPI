using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models.Entities;

namespace ResturantAPI.Models.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
