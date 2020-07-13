using ResturantAPI.Models.Entities;
using System.Linq;

namespace ResturantAPI.Models.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User ValidateUser(User user)
        {
            return context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
        }
    }
}
