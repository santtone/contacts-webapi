using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Lists all Contacts
        /// </summary>
        /// <returns>List of Contact Objects</returns>
        /// <response code="200">Returns List of Contact Objects</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> List()
        {
            var contacts = await _contactService.Get();
            return new JsonResult(contacts);
        }


        /// <summary>
        /// Finds Contact By Id
        /// </summary>
        /// <param name="id">Id of the Contact</param>
        /// <returns>Specified Contact object</returns>
        /// <response code="200">Returns Specified Contact object</response>
        /// <response code="404">Returned if specified contact by id not found</response>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _contactService.Get(id);
            if (contact == null)
            {
                return new NotFoundResult();
            }

            return new JsonResult(contact);
        }

        [HttpPut("{id}")]
        public string Update(string id, [FromBody] string someObject)
        {
            return "Update id:" + id;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contact contact)
        {
            var created = await _contactService.Create(contact);
            return new JsonResult(created);
        }

        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            return "Delete by id:" + id;
        }
    }
}