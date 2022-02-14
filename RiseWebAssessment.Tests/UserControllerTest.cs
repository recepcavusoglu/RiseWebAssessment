using RiseWebAssessment.Controllers;
using RiseWebAssessment.Model.DTO;
using RiseWebAssessment.Service.ServiceAbstracts;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RiseWebAssessment.Tests
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> repositoryStub = new();

        [Fact]
        public void GetUserWithId_WithUnexistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<int>())).Returns((UserDto)null);
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetUserById(999);
            // Assert
            Assert.Null(result.Result.Value);
        }
        [Fact]
        public void GetUserWithId_WithExistingItemUser()
        {
            var user = new UserDto();
            // Arrange
            repositoryStub.Setup(repo => repo.GetUser(It.IsAny<int>())).Returns(user);
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetUserById(1);
            // Assert
            Assert.IsType<Task<ActionResult<UserDto>>>(result);
        }

        [Fact]
        public void UserExist_WithUnexistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.UserExist(It.IsAny<int>())).Returns(false);
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetUserById(999);
            // Assert

            Assert.IsType<ActionResult<UserDto>>(result.Result);
        }
        [Fact]
        public void UserExist_WithExistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.UserExist(It.IsAny<int>())).Returns(true);
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetUserById(2);
            // Assert
            Assert.IsType<ActionResult<UserDto>>(result.Result);
        }
        [Fact]
        public void ChangeUserStatus_WithExistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.ChangeUserStatus(It.IsAny<int>()));
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.ChangeUserStatus(2);
            // Assert

            Assert.IsType<ActionResult<UserDto>>(result.Result);
        }
        [Fact]
        public void ChangeUserStatus_WithUnExistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.ChangeUserStatus(It.IsAny<int>()));
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.ChangeUserStatus(999);
            // Assert
            Assert.IsType<ActionResult<UserDto>>(result.Result);
        }
        [Fact]
        public void GetUserWithContact_WithUnExistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.GetUserWithContact(It.IsAny<int>()));
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetUserWithContact(999);
            // Assert
            Assert.IsType<ActionResult<UserWithContactDto>>(result.Result);
        }
        [Fact]
        public void GetAllActiveUsers()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.GetAllActiveUsers());
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.GetAllActiveUsers();
            // Assert
            Assert.IsType<ActionResult<List<UserDto>>>(result.Result);
        }
        [Fact]
        public void DeleteUser_WithUnExistingUser()
        {
            // Arrange
            repositoryStub.Setup(repo => repo.DeleteUser(It.IsAny<int>()));
            var controller = new UserController(repositoryStub.Object);
            // Act
            var result = controller.DeleteUser(999);
            // Assert
            Assert.IsType<ActionResult<string>>(result.Result);
        }
    }
}
