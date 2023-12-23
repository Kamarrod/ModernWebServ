using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Auth.Controllers
{
    [Route("api/polz")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _service;
        public UserController(IServiceManager service) => _service = service;

        //[HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.UserService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _service.UserService.GetUserByIdAsync(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto userForUpdateDto)
        {
            if (userForUpdateDto is null)
                return BadRequest("UserForUpdateDto object is null");

            await _service.UserService.UpdateUserAsync(id, userForUpdateDto, trackChanges: true);
            return NoContent();
        }
    }
}
