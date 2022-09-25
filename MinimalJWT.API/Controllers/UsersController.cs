using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalJWT.API.Models;
using MinimalJWT.API.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalJWT.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;

        public UsersController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLogin user)
        {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = _userService.Get(user);

                if(loggedInUser == null) return NotFound("No user");

                //Define Claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,loggedInUser.UserName),
                    new Claim(ClaimTypes.Email,loggedInUser.EmailAddress),
                    new Claim(ClaimTypes.GivenName,loggedInUser.EmailAddress),
                    new Claim(ClaimTypes.Surname,loggedInUser.Surname),
                    new Claim(ClaimTypes.Role,loggedInUser.Role),
                };

                //Create a token
                var token = new JwtSecurityToken
                    (
                        issuer: _config["Jwt:Issuer"],
                        audience: _config["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey
                                (Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256)

                    ) ;

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenString);
            }

            return NotFound();
        }
    }
}
