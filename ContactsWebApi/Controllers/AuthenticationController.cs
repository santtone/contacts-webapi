using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Controllers.Resources;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Controllers
{
    [Route("api/authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticationResource resource)
        {
            var token = await _authenticationService.GetToken(resource.Username, resource.Password);
            return new JsonResult(token);
        }
    }
}
