using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Context;
using To_Do_List_API.Dtos;
using To_Do_List_API.Dtos.Converters;
using To_Do_List_API.Entities;
using To_Do_List_API.Services.Interfaces;

namespace To_Do_List_API.Services
{
    public class UserService(AppDbContext context) : IUserService
    {

        private readonly AppDbContext _context = context;

        public async Task<IActionResult> RegisterUserAsync(RegisterUserDto userDto)
        {
           
            var existingUsername = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == userDto.Username);
            if (existingUsername != null)
                return new StatusCodeResult(409);

         
            var user = new User
            {
                Username = userDto.Username,
                Password = PasswordConverter.HashPassword(userDto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { user.Id, user.Username });
        }

        public async Task<IActionResult>EditUserAsync(int id, User user)
        {
            var userBD = await _context.Users.FindAsync(id);


            if (userBD == null)
            {
                return new NotFoundObjectResult("Usuario não encontrado");
            }

            var existingEmail = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username   );

            if (existingEmail != null && user.Id != existingEmail.Id)
            {
                return new ConflictObjectResult("Username já foi cadastrado");
            }

            string hashedPassword = PasswordConverter.HashPassword(user.Password);

            
            userBD.Username = user.Username;
            userBD.Password = hashedPassword;

            _context.Update(userBD);

            return new OkObjectResult(userBD);
        }



        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return new NotFoundObjectResult("Usuario não encontrado");
            }
            return new OkObjectResult(users);
        }

    }
}
