using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsWebApi.Config;
using ContactsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;

        public ContactRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> Get()
        {
            return await _context.Contact.ToListAsync();
        }

        public async Task<Contact> Get(int id)
        {
            return await _context.Contact.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Contact> Create(Contact contact)
        {
            var created = await _context.Contact.AddAsync(contact);
            await _context.SaveChangesAsync();
            return created.Entity;
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