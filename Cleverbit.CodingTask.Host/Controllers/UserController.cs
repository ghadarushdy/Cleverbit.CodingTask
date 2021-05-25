using Cleverbit.CodingTask.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        
        [Route("AuthenticateUser")]
        public IActionResult AuthenticateUser(string userName, string password)
        {
            return Ok(_userService.AuthenticateUser(userName,password));
        }
    }
}
