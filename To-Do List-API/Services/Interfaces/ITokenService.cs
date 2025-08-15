using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Dtos;


namespace To_Do_List_API.Services.Interfaces
{
    public interface ITokenService
    {
        Task<IActionResult>GenerateToken(LoginDto loginDto);
  
    }
}
