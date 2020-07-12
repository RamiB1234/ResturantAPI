using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResturantAPI.Models.Entities;
using ResturantAPI.Models.Repository;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private IUserRepository userRepository;

        public AuthController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("register")]
        public ActionResult Register([FromBody] User user)
        {
            try
            {
                userRepository.AddUser(user);
                return StatusCode(201); // 201: Created
            }
            catch
            {
                return StatusCode(400); // 400: Bad request
            }
        }

    }
}
