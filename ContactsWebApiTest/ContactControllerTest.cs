using System;
using System.Collections.Generic;
using ContactsWebApi.Controllers;
using ContactsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ContactsWebApiTest
{
    public class ContactControllerTest
    {
        [Fact]
        public async void ListShouldReturnListOfContacts()
        {
            // Arrange
            var contactController = GetContactController();

            // Act
            var action = await contactController.List();

            // Assert
            var result = Assert.IsType<JsonResult>(action);
            var contacts = Assert.IsType<List<Contact>>(result.Value);
            Assert.Equal(2, contacts.Count);
        }

        [Fact]
        public async void GetShouldReturnSpecifiedContact()
        {
            // Arrange
            var contactController = GetContactController();
            const int id = 1;

            // Act
            var action = await contactController.Get(id);

            // Assert
            var result = Assert.IsType<JsonResult>(action);
            var contact = Assert.IsType<Contact>(result.Value);
            Assert.Equal(id, contact.Id);
        }

        [Fact]
        public async void GetShouldReturnNotFoundResultIfSpecifiedContactNotFound()
        {
            // Arrange
            var contactController = GetContactController();
            const int id = 123;

            // Act
            var action = await contactController.Get(id);

            // Assert
            Assert.IsType<NotFoundResult>(action);
        }

        private ContactController GetContactController()
        {
            var contactService = new ContactServiceFake();
            return new ContactController(contactService);
        }
    }
}