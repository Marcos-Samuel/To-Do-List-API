using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Dtos;
using To_Do_List_API.Services.Interfaces;

namespace To_Do_List_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost]
        public Task<IActionResult> Login(LoginDto loginDto) => _tokenService.GenerateToken(loginDto);

    }
}
