using System.IO.Compression;
using ContactsWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Controllers
{
    [Authorize]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        /// <summary>
        /// Lists all Contacts
        /// </summary>
        /// <returns>List of contacts</returns>
        [HttpGet]
        public ActionResult<string> List()
        {
            return new JsonResult("test");
        }

        /// <summary>
        /// Find Contact by Id
        /// </summary>
        /// <param name="id">Id of Contact</param>
        /// <returns>Contact object or empty</returns>
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            return new JsonResult(new Contact {Id = 1, FirstName = "test", LastName = "test"});
        }
    }
}