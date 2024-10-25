using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Dto;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Validaions;

namespace SampleApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ITokenService _tokenService;
        HMACSHA256 hmac = new HMACSHA256();

        public UserController(IUserRepository repo, ITokenService tokenService)
        {

            _tokenService = tokenService;
            _repo = repo;
        }




    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    ///     

        [HttpPost("Login")]
        public ActionResult Login(UserDto userDto)
        {
            var user = _repo.FindUserByLogin(userDto.Login);
            return CheckPasswordHash(userDto, user);

        }

        [HttpPost]
        public ActionResult CreateUser(UserDto userDto)
        {
            User user = new User
            {
                Login = userDto.Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                PasswordSalt = hmac.Key,
                Token = _tokenService.CreateToken(userDto.Login),
                RoleId = 1
            };

            ValidUser(user);

            

            _repo.CreateUser(user);
          
            return Created("$http://localhost:5066/{user.Id}",user);
        }


        [HttpPut]
        public ActionResult UpdateUser(User user)
        {
            return Ok(_repo.EditUser(user, user.Id));
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id) 
        {
            return Ok(_repo.FindUserById(id));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id) 
        {
            return Ok(_repo.DeleteUser(id));
        }
        [HttpDelete]
        public ActionResult DeleteAllUsers() 
        {
            return Ok(_repo.DeleteAllUsers());
        }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <exception cref="Exception"> Ошибки проверки через FluentValidation</exception> <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    
        
        private void ValidUser(User user)
        {
            var validator = new FluentValidator();
            var result = validator.Validate(user);

            if (result.IsValid)
            {
                throw new Exception("${result.Errors.First().ErrorMessage}");
            }               
        }


        
        /// <summary>
        /// Метод проверки пароля
        /// </summary>
        /// <param name="userDto"></param>
        /// <param name="user"></param> 
        /// <returns></returns>    
        
        private ActionResult CheckPasswordHash(UserDto userDto, User user)
        {
            using var hmac = new HMACSHA256(user.PasswordSalt);
            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
            
            for(int i = 0; i< ComputedHash.Length; i++)
            {
                if(ComputedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized($"Неправильный пароль");
                }
            }

            return Ok(user);

        }

        
        [HttpGet("{code:int}")]
        public ActionResult GetError([FromRoute]int code){
            return StatusCode(code);
        }


    }
}
