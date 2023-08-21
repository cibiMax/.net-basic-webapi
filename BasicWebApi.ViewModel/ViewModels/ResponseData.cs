using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.ViewModel.ViewModels
{
    public class ResponseData
    {
        public int status { get; set; }
        public string token { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public string RefreshToken { get; set; }

    }
}
