using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Services;

namespace ContactsWebApiTest
{
    public class ContactServiceFake : IContactService
    {
        private readonly List<Contact> _contacts;


        public ContactServiceFake()
        {
            _contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1, FirstName = "Firstname", LastName = "Lastname", City = "Kouvola",
                    StreetAddress = "Käsityöläiskatu 4", PostCode = 45360
                },
                new Contact
                {
                    Id = 1, FirstName = "Someone", LastName = "Else", City = "Kouvola",
                    StreetAddress = "Käsityöläiskatu 4", PostCode = 45100
                }
            };
        }

        public async Task<List<Contact>> Get()
        {
            return await Task.FromResult(_contacts);
        }

        public async Task<Contact> Get(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(contact);
        }

        public Task<Contact> Create(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> Update(int id, Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}