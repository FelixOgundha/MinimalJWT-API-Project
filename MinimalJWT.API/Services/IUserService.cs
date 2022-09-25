using DataAccess.Entities;
using MinimalJWT.API.Models;

namespace MinimalJWT.API.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
