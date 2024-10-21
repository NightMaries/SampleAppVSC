using System.Data.Common;
using System.Security.Cryptography;
using System.Text;
using SampleApp.API.Data;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Repositories;

namespace SampleApp.Tests;
public class UserRepositoryTests
{
    private readonly UserRepository _userRepository;

    public HMACSHA512 hmac = new HMACSHA512();
    public UserRepositoryTests(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [Fact]
    public void CreateUser_ShouldReturnNewUserWithGeneratedId()
    {
        // Arrange
        var newUser = new User {
        Name = "Test User",
        Login = "Login",
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
        PasswordSalt = hmac.Key
        };

        //Act
        var createdUser = _userRepository.CreateUser(newUser);
        // Assert
        Assert.NotNull(createdUser);
        Assert.Equal(newUser.Name, createdUser.Name);
    }

    [Fact]
    public void DeleteUser_ShouldReturnTrueAndRemoveUser()
    {
        var userRepository = _userRepository;
        // Arrange
        var testUser = new User { 
            Id = 4,
            Name = "Test User",
            Login ="Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
         };
        userRepository.CreateUser(testUser);

        // Act
        bool result = userRepository.DeleteUser(testUser.Id);

        // Assert
        Assert.True(result);
        Assert.Empty(userRepository.GetUsers());
    }

    [Fact]
    public void EditUser_ShouldUpdateExistingUser()
    {
        // Arrange
        var userRepository = _userRepository;
        var originalUser = new User 
        {    
            Name = "Original User",
            Login = "Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
        };
        // Act
        var editedUser = new User
        { 
            Id = originalUser.Id,
            Name = "Edited User",
            Login = "Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
        };
        var result = userRepository.EditUser(editedUser, originalUser.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Edited User", result.Name);
        Assert.Single(userRepository.GetUsers());
    }

    [Fact]
    public void FindUserById_ShouldReturnUserByValidId()
    {
        // Arrange
        var userRepository =_userRepository;
        var testUser = new User 
        { 
            Id = 3, 
            Name = "Edited User",
            Login = "Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
        };
            userRepository.CreateUser(testUser);

        // Act
        var foundUser = userRepository.FindUserById(testUser.Id);

        // Assert
        Assert.NotNull(foundUser);
        Assert.Equal(testUser.Id, foundUser.Id);
        Assert.Equal(testUser.Name, foundUser.Name);
    }

    [Fact]
    public void FindUserById_ShouldThrowExceptionForInvalidId()
    {
        // Arrange
        var userRepository = _userRepository;

        // Act & Assert
        Assert.Throws<Exception>(() => userRepository.FindUserById(3));
    }

    [Fact]
    public void GetUsers_ShouldReturnAllUsers()
    {
        // Arrange
        var userRepository = _userRepository;
        var testUser1 = new User 
        {
            Id = 1, 
            Name = "User1",
            Login = "Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
        
        };
        var testUser2 = new User 
        {   
            Id = 2, 
            Name = "User2",
            Login = "Login",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
            PasswordSalt = hmac.Key
        };
        userRepository.CreateUser(testUser1);
        userRepository.CreateUser(testUser2);

        // Act
        var users = userRepository.GetUsers();

        // Assert
        Assert.NotNull(users);
        Assert.Equal(2,2);
        Assert.Contains(testUser1, users);
        Assert.Contains(testUser2, users);
    }

    [Fact]
    public void FindUserById_ShouldThrowExceptionForNonExistentId()
    {
        // Arrange
        var userRepository = _userRepository;

        // Act & Assert
        Assert.Throws<Exception>(() => userRepository.FindUserById(1));
    }
}