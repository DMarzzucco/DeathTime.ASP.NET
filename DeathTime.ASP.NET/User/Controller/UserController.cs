using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeathTime.ASP.NET.User.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServicesImpl _service;
        public UserController(IUserServicesImpl service)
        {
            _service = service;
        }

        //Get Mapping 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUser()
        {
            return Ok(await this._service.GetAll());
        }
        //Get  by Id Mapping
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            var user = await this._service.GetById(id);
            return Ok(user);
        }
        //Create Mapping 
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(CreateUserDTO user)
        {
            var body = await this._service.CreateUser(user);
            return CreatedAtAction(nameof(GetAllUser), new { id = body.Id }, body);
        }
        //Update user by Id Mapping 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO user)
        {
            await this._service.UpdateUser(id, user);
            return NoContent();
        }
        //Delete user by Id Mapping 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await this._service.DeleteUser(id);
            return NoContent();
        }

    }
}
