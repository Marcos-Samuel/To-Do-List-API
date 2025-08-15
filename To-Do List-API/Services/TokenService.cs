

using To_Do_List_API.Context;
using To_Do_List_API.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using To_Do_List_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Dtos.Converters;

namespace To_Do_List_API.Services
{
    public class TokenService(IConfiguration confiuration, AppDbContext userRepository) : ITokenService
    {
        private readonly IConfiguration _confiuration = confiuration;
        private readonly AppDbContext _userRepository = userRepository;

        async Task<IActionResult> ITokenService.GenerateToken(LoginDto loginDto)
        {
            var existingUser = await _userRepository.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (existingUser == null) {
            
                return new UnauthorizedObjectResult("Usuário ou senha incorreta.");
            }
            var checkPassword = PasswordConverter.VerifyPassword(password: loginDto.Password, hashedPassword: existingUser.Password);


            if (existingUser == null || !checkPassword)
                return new UnauthorizedObjectResult("Usuário ou senha incorreta.");

            var secreKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confiuration["Jwt:Key"] ?? string.Empty));
            var issuer = _confiuration["Jwt:Issuer"];
            var audience = _confiuration["Jwt:Audience"];

            var signinCredentiais = new SigningCredentials(secreKey, algorithm: SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
               issuer: issuer,
               audience: audience,
               claims:
               [
                   new Claim(type: ClaimTypes.Email,  value:loginDto.Username)
               ],
               expires: DateTime.Now.AddHours(2),
               signingCredentials: signinCredentiais
               );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new OkObjectResult(new { existingUser.Id , existingUser.Username, token });

        }

    }
}

