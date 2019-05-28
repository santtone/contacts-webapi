using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Services;

namespace ContactsWebApiTest
{
    class ContactServiceFake : IContactService
    {
        private readonly List<Contact> _contacts;

        public ContactServiceFake()
        {
            _contacts = new List<Contact>
            {
                new Contact {Id = 1, FirstName = "Sami", LastName = "Anttonen"},
                new Contact {Id = 2, FirstName = "Joku", LastName = "Toinen"}
            };
        }

        public async Task<List<Contact>> Get()
        {
            return await Task.FromResult(_contacts);
        }

        public async Task<Contact> Get(int id)
        {
            return await Task.FromResult(_contacts.FirstOrDefault(c => c.Id == id));
        }

        public Task<Contact> Create(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> Update(int id, Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}