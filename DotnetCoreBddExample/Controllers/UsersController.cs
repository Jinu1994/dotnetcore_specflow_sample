using DotnetCoreBddExample.Models;
using DotnetCoreBddExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreBddExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(new { id = _userService.Create(user)});
        }
    }
}
