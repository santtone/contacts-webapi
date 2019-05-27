using System.ComponentModel.DataAnnotations;

namespace ContactsWebApi.Controllers.Resources
{
    public class AuthenticationResource
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}