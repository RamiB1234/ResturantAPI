using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResturantAPI.Models.Entities;
using ResturantAPI.Models.Repository;
using ResturantAPI.Models.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ResturantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private IConfiguration configuration;
        private IUserRepository userRepository;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Route("register")]
        public ActionResult Register([FromBody] User user)
        {
            // TO-DO: check if user already exists here
            try
            {
                var foundUser = userRepository.CheckDuplicateEmail(user);
                if(foundUser!= null)
                {
                    return StatusCode(406); // Not Acceptable
                }
                userRepository.AddUser(user);
                return StatusCode(201); // 201: Created
            }
            catch
            {
                return StatusCode(400); // 400: Bad request
            }
        }

        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var foundUser= userRepository.ValidateUser(user);

            if(foundUser!=null)
            {
                var tokenString = GenerateJWT();
                return Ok(new LoggedUser { FullName = foundUser.FullName, userId = foundUser.Id, Token = tokenString });
            }
            else
            {
                return StatusCode(401); // Unauthorized
            }
        }

        private string GenerateJWT()
        {
            var issuer = configuration["JwtIssuer"];
            var audience = configuration["JwtAudience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(configuration["JwtKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }
}
