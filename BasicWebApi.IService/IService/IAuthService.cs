using BasicWebApi.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.IService.IService
{
    public interface IAuthService
    {
        Task<int> RegisterUser(UserVm userVm);
        Task SignOut();
        Task<string> SignIn(UserVm user);

    }
}
