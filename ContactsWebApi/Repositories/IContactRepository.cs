using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsWebApi.Models;

namespace ContactsWebApi.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> Get();
        Task<Contact> Get(int id);
        Task<Contact> Create(Contact contact);
        Task<Contact> Update(int id, Contact contact);
        Task Delete(int id);
    }
}