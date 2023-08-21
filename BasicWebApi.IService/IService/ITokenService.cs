using BasicWebApi.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.IService
{
    public interface ITokenService
    {
         string generatetoken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken (string token);

    }
}
