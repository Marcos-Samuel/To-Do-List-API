using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Dtos;
using To_Do_List_API.Entities;


namespace To_Do_List_API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> RegisterUserAsync(RegisterUserDto user);
        Task<IActionResult> EditUserAsync(int id, User user);
        Task<IActionResult> GetUserByIdAsync(int id);
    }

}
