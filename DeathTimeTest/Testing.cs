using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.User.Controller;
using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Services;
using DeathTime.ASP.NET.User.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DeathTimeTest
{
    public class Testing
    {
        private readonly Mock<IUserServicesImpl> _mockService;
        private readonly UserController _controller;
        public Testing()
        {
            this._mockService = new Mock<IUserServicesImpl>();
            this._controller = new UserController(this._mockService.Object);
        }
        //Get All
        [Fact]
        public async Task GetAllUser_ReturnOkResult_WithListofUser()
        {
            var users = new List<UserModel>
            {
                new UserModel {Id = 1, Age = "32",Email = "Nd@gmail.com", Name= "Andr"},
                new UserModel {Id = 3, Age = "32",Email = "ad@gmail.com", Name= "Lerk"}
            };
            this._mockService.Setup(s => s.GetAll()).ReturnsAsync(users);

            var result = await this._controller.GetAllUser();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<List<UserModel>>(okResult.Value);
            Assert.Equal(2, returnUsers.Count);
        }
        //Get By Id
        [Fact]
        public async Task GetUserById_UserExist_ReturnOkResult()
        {
            // Arrange
            var user = new UserModel { Id = 1, Age = "32", Email = "ad@gmail.com", Name = "Lerk" };
            this._mockService.Setup(s => s.GetById(1)).ReturnsAsync(user);
            //Act
            var result = await this._controller.GetUserById(1);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUser = Assert.IsType<UserModel>(okResult.Value);
            Assert.Equal(user.Id, returnUser.Id);

        }
        //Get by id Not found
        [Fact]
        public async Task GetUserById_UserNotExist_ReturnNotFound()
        {
            this._mockService.Setup(s => s.GetById(1)).ThrowsAsync(new KeyNotFoundException());

            var result = await this._controller.GetUserById(1);

            Assert.IsType<NotFoundResult>(result.Result);
        }
        //Create User
        [Fact]
        public async Task CreateAUser_ReturnUser()
        {
            var newUser = new CreateUserDTO { Name = "Lert", Age = "23", Email = "Le@gmail.com" };
            var createdUser = new UserModel { Id = 1, Name = "Lert", Age = "23", Email = "Le@gmail.com" };
            this._mockService.Setup(s => s.CreateUser(newUser)).ReturnsAsync(createdUser);

            var result = await this._controller.CreateUser(newUser);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnUser = Assert.IsType<UserModel>(createdResult.Value);
            Assert.Equal(createdUser.Id, returnUser.Id);
        }
        //Create User Duplicate Value
        [Fact]
        public async Task CreateAUser_DuplicateValue_ReturnConflict()
        {
            var newUser = new CreateUserDTO { Name = "Lert", Age = "23", Email = "Le@gmail.com" };
            this._mockService.Setup(s => s.CreateUser(newUser)).ThrowsAsync(new Exception("This Username already exists"));

            var result = await this._controller.CreateUser(newUser);

            var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);
            Assert.Equal("This Username already exists", conflictResult.Value);

        }
        // Update User
        [Fact]
        public async Task UpdateUser_UserExists_ReturnNoContent()
        {
            var updateUser = new UpdateUserDTO { Name = "Lert", Age = "23", Email = "Le@gmail.com" };
            this._mockService.Setup(s => s.UpdateUser(1, updateUser)).ReturnsAsync(true);

            var result = await this._controller.UpdateUser(1, updateUser);

            Assert.IsType<NoContentResult>(result);
        }
        // Update User Not Found
        [Fact]
        public async Task UpdateUser_UserNotFound_ReturnNotFound()
        {
            var updateUser = new UpdateUserDTO { Name = "Lert", Age = "23", Email = "Le@gmail.com" };
            this._mockService.Setup(s => s.UpdateUser(1, updateUser)).ReturnsAsync(false);
            var result = await this._controller.UpdateUser(1, updateUser);

            Assert.IsType<NotFoundResult>(result);
        }
        // Delete User
        [Fact]
        public async Task DeleteUser_UserExist_ReturnNoConTent()
        {
            this._mockService.Setup(s => s.DeleteUser(1)).ReturnsAsync(true);
            var result = await this._controller.DeleteUser(1);

            Assert.IsType<NoContentResult>(result);
        }
        // Delte User Not Found
        [Fact]
        public async Task DeleteUser_UserNotFound_ReturnNotFound ()
        {
            this._mockService.Setup(s => s.DeleteUser(1)).ReturnsAsync(false);

            var result = await this._controller.DeleteUser(1);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}