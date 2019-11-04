using System.Collections.Generic;
using ContactsWebApi.Controllers;
using ContactsWebApi.Models;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContactsWebApiTest
{
    public class ContactsControllerMoqTest
    {
        [Fact]
        public async void ListShouldReturnListOfContacts()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(contactService => contactService.Get())
                .ReturnsAsync(new List<Contact>
                {
                    new Contact {Id = 1, FirstName = "Sami", LastName = "Anttonen"},
                    new Contact {Id = 2, FirstName = "Joku", LastName = "Toinen"}
                });
            var contactController = new ContactController(mockContactService.Object);

            // Act
            var action = await contactController.List();

            // Assert
            var result = Assert.IsType<JsonResult>(action);
            var contacts = Assert.IsType<List<Contact>>(result.Value);
            Assert.Equal(2, contacts.Count);
        }
    }
}