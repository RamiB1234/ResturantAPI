using ResturantAPI.Models.Entities;

namespace ResturantAPI.Models.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User ValidateUser(User user);
        User CheckDuplicateEmail(User user);
    }
}
