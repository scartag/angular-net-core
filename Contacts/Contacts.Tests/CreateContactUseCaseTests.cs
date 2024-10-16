using Contacts.Application.DTOs;
using Contacts.Application.UseCases;
using Contacts.Core.Entities;
using Contacts.Core.Repositories;
using Moq;

namespace Contacts.Tests
{
    public class CreateContactUseCaseTests
    {
        [Fact]
        public async void Execute_ShouldSaveContact_WhenContactDtoIsValid()
        {
            // Arrange
            var name = "Benjen Stark";
            var contactDto = new ContactDto { Name = name };
            var mockRepository = new Mock<IContactRepository>();
            var useCase = new CreateContactUseCase(mockRepository.Object);

            // Act
            await useCase.Execute(contactDto);

            // Assert
            mockRepository.Verify(repo => repo.AddAsync(It.Is<Contact>(o => o.Name == name)), Times.Once);
        }


        [Fact]
        public async void Execute_ShouldThrowArgumentNullException_WhenContactDtoIsNull()
        {
            // Arrange
            var mockRepository = new Mock<IContactRepository>();
            var useCase = new CreateContactUseCase(mockRepository.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => useCase.Execute(null));
        }


        [Fact]
        public async void Execute_ShouldThrowException_WhenRepositoryFailsToSave()
        {
            // Arrange
            var contactDto = new ContactDto { Name = "Catlyn Stark" };
            var mockRepository = new Mock<IContactRepository>();
            mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Contact>())).Throws(new Exception("Database error"));
            var useCase = new CreateContactUseCase(mockRepository.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => useCase.Execute(contactDto));
            Assert.Equal("Database error", exception.Message);
        }


    }
}