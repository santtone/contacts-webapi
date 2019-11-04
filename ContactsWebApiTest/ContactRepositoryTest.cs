using System;
using System.Collections.Generic;
using System.Text;
using ContactsWebApi.Config;
using ContactsWebApi.Models;
using ContactsWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContactsWebApiTest
{
    public class ContactRepositoryTest
    {
        [Fact]
        public async void GetShouldReturnAllDbContacts()
        {
            // Arrange
            var contactRepository = new ContactRepository(GetDbContext());

            // Act
            var contacts = await contactRepository.Get();

            // Assert
            Assert.Equal(2, contacts.Count);
        }

        private static ContactsDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ContactsDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            var context = new ContactsDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Contact.AddRange(new List<Contact>
            {
                new Contact {FirstName = "Sami", LastName = "Anttonen"},
                new Contact {FirstName = "Joku", LastName = "Toinen"}
            });
            context.SaveChanges();

            return context;
        }
    }
}