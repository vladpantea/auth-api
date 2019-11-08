using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Auth.API.Model;
using Auth.API.Helper;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtHelper _jwtHelper;
        private readonly IAuthSettings _authSettings;

        public AuthController(ILogger<AuthController> logger, IJwtHelper jwtHelper, IAuthSettings authSettings)
        {
            _logger = logger;
            _jwtHelper = jwtHelper;
            _authSettings = authSettings;
        }

        [HttpPost]
        public ActionResult<string> Login([FromBody] Login data)
        {
            if(string.IsNullOrEmpty(data.username) || string.IsNullOrEmpty(data.password))
            {
                return BadRequest();
            }

            if(data.username != _authSettings.Username && data.password != _authSettings.Password)
            {
                return BadRequest();
            }

            var token = _jwtHelper.Sign(data.username);

            return token;
        }
    }
}
