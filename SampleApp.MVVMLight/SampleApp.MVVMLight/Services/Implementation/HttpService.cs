using SampleApp.MVVMLight.Models.APIModels;
using SampleApp.MVVMLight.Services.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class HttpService : IHttpService
    {
        public Task<ResponseModel<string>> SendRequestAsync(HttpMethod method, string url, string content = null, int timeout = 60)
        {
            throw new NotImplementedException();
        }
    }
}
