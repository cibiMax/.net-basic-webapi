using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.ViewModel.ViewModels
{
    public class TokenVm
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
