using SampleApp.MVVMLight.Models.APIModels;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Services.Interface
{
    public interface IHttpService
    {
        Task<ResponseModel<string>> SendRequestAsync(HttpMethod method, string url, string content = null, int timeout = 60);

    }
}
