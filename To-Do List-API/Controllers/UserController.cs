using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using To_Do_List_API.Dtos;
using To_Do_List_API.Entities;
using To_Do_List_API.Services.Interfaces;

namespace To_Do_List_API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            return await _userService.RegisterUserAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] User user)
        {
            return await _userService.EditUserAsync(id, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListUserForId(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }
    }
}
