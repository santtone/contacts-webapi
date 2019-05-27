using System.Threading.Tasks;
using ContactsWebApi.Controllers.Resources;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationResource authenticationResource)
        {
            var token = await _authenticationService.GetToken(authenticationResource.Username,
                authenticationResource.Password);
            if (token == null)
            {
                return new UnauthorizedResult();
            }

            return new JsonResult(token);
        }
    }
}