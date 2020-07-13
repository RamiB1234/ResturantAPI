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
            // Hashing password before saving:
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;

            context.Users.Add(user);
            context.SaveChanges();
        }

        public User CheckDuplicateEmail(User user)
        {
            return context.Users.FirstOrDefault(u => u.Email == user.Email);

        }

        public User ValidateUser(User user)
        {
            var foundUser = context.Users.FirstOrDefault(u => u.Email == user.Email);

            if(foundUser!=null)
            {
                // check a password
                bool validPassword = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);

                return validPassword == true ? foundUser : null;
            }

            // User not found by email:
            return null;

        }

        
    }
}
