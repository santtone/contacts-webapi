using ContactsWebApi.Controllers;
using ContactsWebApi.Models;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContactsWebApiTest
{
    public class ContactControllerMoqTest
    {
        [Fact]
        public async void GetShouldReturnSpecifiedContact()
        {
            //Arrange
            const int id = 1;
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(contactService => contactService.Get(id))
                .ReturnsAsync(new Contact
                {
                    Id = id,
                    FirstName = "Hei",
                    LastName = "Moi"
                });
            var contactController = new ContactController(mockContactService.Object);

            //Act
            var action = await contactController.Get(id);

            //Assert
            var result = Assert.IsType<JsonResult>(action);
            var contact = Assert.IsType<Contact>(result.Value);
            Assert.Equal(id, contact.Id);
        }
    }
}