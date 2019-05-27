using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Repositories;

namespace ContactsWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> Get()
        {
            return await _contactRepository.Get();
        }

        public async Task<Contact> Get(int id)
        {
            return await _contactRepository.Get(id);
        }

        public async Task<Contact> Create(Contact contact)
        {
            return await _contactRepository.Create(contact);
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