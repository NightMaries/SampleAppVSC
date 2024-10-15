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


    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            role.Id = Guid.NewGuid();
            _repo.CreateRole(role);
            return Created();
        }

        [HttpPut]
        public ActionResult UpdateRole(Role role)
        {
            return Ok(_repo.EditRole(role, role.Id));
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            return Ok(_repo.GetRoles());
        }

        [HttpGet("{id}")]
        public ActionResult GetRoleById(Guid id) 
        {
            return Ok(_repo.FindRoleById(id));
        }

        [HttpDelete]
        public ActionResult DeleteRole(Guid id) 
        {
            return Ok(_repo.DeleteRole(id));
        }
    }
}
