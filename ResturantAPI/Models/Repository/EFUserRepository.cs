using System;
using ResturantAPI.Models.Entities;

namespace ResturantAPI.Models.Repository
{
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        void IUserRepository.AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
