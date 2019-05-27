using System.Threading.Tasks;
using ContactsWebApi.Models;

namespace ContactsWebApi.Services
{
    public interface IAuthenticationService
    {
        Task<AccessToken> GetToken(string username, string password);
    }
}