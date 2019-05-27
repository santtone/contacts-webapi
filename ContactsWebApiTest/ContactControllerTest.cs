using System.Collections.Generic;
using ContactsWebApi.Controllers;
using ContactsWebApi.Models;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ContactsWebApiTest
{
    public class ContactControllerTest
    {
        private readonly ContactController _contactController;

        public ContactControllerTest()
        {
            IContactService contactService = new ContactServiceFake();
            _contactController = new ContactController(contactService);
        }

        [Fact]
        public async void ListShouldReturnTwoContacts()
        {
            //Act
            var action = await _contactController.List();

            //Assert
            var result = Assert.IsType<JsonResult>(action);
            var contacts = Assert.IsType<List<Contact>>(result.Value);
            Assert.Equal(2, contacts.Count);
        }

        [Fact]
        public async void GetShouldReturnSpecifiedContact()
        {
            //Arrange
            const int id = 1;

            //Act
            var action = await _contactController.Get(id);

            //Assert
            var result = Assert.IsType<JsonResult>(action);
            var contact = Assert.IsType<Contact>(result.Value);
            Assert.Equal(id, contact.Id);
        }

        [Fact]
        public async void GetShouldReturnNotFoundResultIfContactNotExists()
        {
            //Arrange
            const int id = 123;

            //Act
            var action = await _contactController.Get(id);

            //Assert
            Assert.IsType<NotFoundResult>(action);
        }
    }
}