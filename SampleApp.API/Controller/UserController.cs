using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using SampleApp.API.Validaions;

namespace SampleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var validator = new FluentValidator();
            var result = validator.Validate(user);
            if (result.IsValid)
            {
                throw new Exception("${result.Errors.First().ErrorMessage}");
            }
            _repo.CreateUser(user);
            return Created();
        }

        [HttpPut]
        public ActionResult UpdateUser(User user)
        {
            return Ok(_repo.EditUser(user, user.Id));
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            return Ok(_repo.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(Guid id) 
        {
            return Ok(_repo.FindUserById(id));
        }

        [HttpDelete]
        public ActionResult DeleteUser(Guid id) 
        {
            return Ok(_repo.DeleteUser(id));
        }
    }
}
