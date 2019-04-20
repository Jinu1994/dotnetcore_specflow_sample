using DotnetCoreBddExample.Models;
using DotnetCoreBddExample.Services.Interfaces;

namespace DotnetCoreBddExample.Services
{
    public class UserService : IUserService
    {
        public int Create(User user)
        {
            // Code to save user in DB here
            return 1; //return the new user Id saved
        }
    }
}
