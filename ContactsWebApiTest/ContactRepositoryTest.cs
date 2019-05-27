using System;
using System.Collections.Generic;
using System.Linq;
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
        public ContactRepositoryTest()
        {
        }

        private static ContactsDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ContactsDbContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            var context = new ContactsDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(new List<Contact>
            {
                new Contact {FirstName = "ContactFirstName", LastName = "ContactLastName"},
                new Contact {FirstName = "OtherContactFirstName", LastName = "OtherContactLastName"}
            });
            context.SaveChanges();
            return context;
        }

        [Fact]
        private async void GetShouldReturnAllContacts()
        {
            //Arrange
            var context = GetDbContext();
            IContactRepository contactRepository = new ContactRepository(context);

            //Act
            var contacts = await contactRepository.Get();

            //Assert
            Assert.Equal(contacts.Count, context.Contact.ToList().Count);
        }
    }
}