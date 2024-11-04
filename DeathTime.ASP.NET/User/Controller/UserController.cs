using DeathTime.ASP.NET.User.DTOs;
using DeathTime.ASP.NET.User.Model;
using DeathTime.ASP.NET.User.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeathTime.ASP.NET.User.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _service;
        public UserController(UserServices service)
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
            return await this._service.GetById(id);
        }
        //Create Mapping 
        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(CreateUserDTO user)
        {
            try 
            {
                var body = await this._service.CreateUser(user);
                return CreatedAtAction(nameof(GetAllUser), new { id = body.Id }, body);
            }
            catch (Exception ex) {
                return Conflict(ex.Message);
            }
      
        }
        //Update user by Id Mapping 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO user)
        {
            if (!await this._service.UpdateUser(id, user))
            {
                return NotFound();
            }
            return NoContent();
        }
        //Delete user by Id Mapping 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await this._service.DeleteUser(id))
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
