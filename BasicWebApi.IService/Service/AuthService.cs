using basicwebapi.Models;
using BasicWebApi.IService.IService;
using BasicWebApi.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public AuthService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }
        public Task<int> RegisterUser(UserVm userVm)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> SignIn(UserVm user)
        {
            if (!await _applicationDbContext.users.AnyAsync(a => a.Email == user.Email && a.Password == user.Password))
            {
                return null;
            }

       
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Email),
                new Claim(ClaimTypes.Role,user.Password)
            };
          var   token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
                 claims,

                 expires: DateTime.UtcNow.AddHours(10),
                 signingCredentials: credentials);


          var  tokenToRet =new JwtSecurityTokenHandler().WriteToken(token);

            return tokenToRet;

        }


        public Task SignOut()
        {
            throw new NotImplementedException();
        }
    }
}
