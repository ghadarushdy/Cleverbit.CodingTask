using Cleverbit.CodingTask.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IGame _game;

        public PingController(IGame game)
        {
            _game = game;
        }

        [HttpGet]
        [Route("GetRandomNumber")]
        public int GetRandomNumber(int max)
        {
            return _game.GenerateNumber(max);
        }

        [HttpPost]
        [Authorize]
        [Route("SaveUserRandomNumber")]
        public IActionResult SaveUserRandomNumber(UserMatchGeneratedNumber userMatchGeneratedNumber)
        {
            return Ok(_game.SaveUserRandomNumber(userMatchGeneratedNumber));
        }

        [HttpGet]
        [Route("GetAllMatchesWinners")]        
        public IActionResult GetAllMatchesWinners()
        {
            return Ok(_game.GetAllMatchesWinners());
        }


        [HttpGet]
        [Route("GetActiveMatch")]
        public IActionResult GetActiveMatch()
        {
            return Ok(_game.GetActiveMatch());
        }

        // GET: api/ping
        [HttpGet]
        public string Get()
        {
            return "Ping received";
        }

        // GET api/ping/with-auth
        [HttpGet("with-auth")]
        [Authorize]
        public string GetWithAuth()
        {
            return $"Ping received with successful authorization. User Name : {User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value}";
        }
    }
}
