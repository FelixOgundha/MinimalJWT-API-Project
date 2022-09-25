using DataAccess.Data;
using DataAccess.Entities;
using MinimalJWT.API.Models;
using System.Linq;

namespace MinimalJWT.API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public User Get(UserLogin userLogin)
        {
            User user = _context.Users.FirstOrDefault(o => o.UserName.Equals
            (userLogin.Username) && o.Password.Equals
            (userLogin.Password)
            );

            return user;
        }
    }
}
