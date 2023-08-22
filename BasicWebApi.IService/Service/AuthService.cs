using AutoMapper;
using basicwebapi.constants;
using basicwebapi.Models;
using BasicWebApi.IService.IService;
using BasicWebApi.Model.Models;
using BasicWebApi.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthService(ApplicationDbContext applicationDbContext, ITokenService tokenService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        async public Task<int> RegisterUser(UserVm userVm)
        {
            try
            {
                User user1 =  UserExists(userVm);
                if (user1 != null)
                {
                    return 2;
                }
                // userVm.Password = Utilities.EncodeToBase64(userVm.Password);
                User userToIns = _mapper.Map<UserVm, User>(userVm);
                await _applicationDbContext.users.AddAsync(userToIns);
                return _applicationDbContext.SaveChanges();


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }


        /// <summary>
        /// used to login user with a access token and a refresh token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>returns the response data with token and refresh token</returns>
        public async Task<ResponseData> SignIn(UserVm user)
        {
            User user1 = UserExists(user);
            if (user1 == null)
            {
                return new ResponseData { token = null };
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user1.Email),
                new Claim(ClaimTypes.Role,user1.Role)
            };
            var token = _tokenService.generatetoken(claims);

            var refToken = _tokenService.GenerateRefreshToken();
            await _applicationDbContext.RefreshToken.AddAsync(new Model.Models.RefreshToken
            {
                Token = refToken,
                ExpirationTime = DateTime.UtcNow.AddDays(2),
                IsActive = true,
                RefreshCount = 0,
                UserId = user1.Id
            });

            await _applicationDbContext.SaveChangesAsync();
            return new ResponseData
            {
                token = token,
                RefreshToken = refToken
            };

        }


        public Task SignOut()
        {
            throw new NotImplementedException();
        }




        private User UserExists(UserVm user)
        {
            //  user.Password = Utilities.EncodeToBase64(user.Password);

            return _applicationDbContext.users.Where(a => a.Email == user.Email && a.Password == user.Password).First();
        }

        /// <summary>
        /// This method is used to refresh the access token and refresh token for the use of jwt with protected resources
        /// </summary>
        /// <returns></returns>
        async public Task<ResponseData> RefreshTheToken(TokenVm previoustoken)
        {
            IEnumerable<Claim> claims = _tokenService.GetClaimsPrincipalFromExpiredToken(previoustoken.Token).Claims;

            RefreshToken refreshToken = await _applicationDbContext.RefreshToken.FirstAsync(a => a.Token == previoustoken.RefreshToken);
            if (refreshToken.IsActive)
            {
                if (DateTime.UtcNow < refreshToken.ExpirationTime && refreshToken.RefreshCount <= 5)
                {
                    string accessToken = _tokenService.generatetoken(claims);
                    refreshToken.RefreshCount = refreshToken.RefreshCount + 1;

                    _applicationDbContext.RefreshToken.Update(refreshToken);
                    await _applicationDbContext.SaveChangesAsync();
                    return new ResponseData
                    {
                        token = accessToken,
                        RefreshToken = previoustoken.RefreshToken
                    };


                }
                else
                {
                    refreshToken.IsActive = false;
                    _applicationDbContext.RefreshToken.Update(refreshToken);
                    _applicationDbContext.SaveChanges();
                }
            }


            return new ResponseData { status = 401 };
        }
    }


}

