using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hosamhemaily.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserManagerAppService _tokenService;

        public AccountController(IUserManagerAppService tokenService)
        {
            _tokenService = tokenService;
        }

        // POST: api/account/login
        [HttpPost("logincustom")]
        public async Task<IActionResult> LoginCustomAsync([FromBody] LoginDTO input)
        {
            // Your login logic here
            var token = await _tokenService.CreateTokenAync(input);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { Token = token });
        }
    }
}
