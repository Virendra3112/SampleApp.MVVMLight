using SampleApp.MVVMLight.Models.APIModels;
using SampleApp.MVVMLight.Services.Interface;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.MVVMLight.Services.Implementation
{
    public class HttpService : IHttpService
    {
        public async Task<ResponseModel<string>> SendRequestAsync(HttpMethod method, string url, string content = null, int timeout = 60)
        {
            var response = new ResponseModel<string>();
            using (var handler = new HttpClientHandler { UseDefaultCredentials = true })
            {
                using (var client = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(timeout) })
                {
                    //var uri = new Uri(string.Format(url, new Guid()));
                    using (var request = new HttpRequestMessage(method, url))
                    {
                        if (method == HttpMethod.Post)
                        {
                            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                        }

                        try
                        {
                            using (var httpResponse = await client.SendAsync(request))
                            {
                                response.Status = httpResponse.StatusCode;
                                response.Result = await httpResponse.Content.ReadAsStringAsync();
                            }
                        }
                        catch (TaskCanceledException ex)
                        {
                            Debug.WriteLine($"Error message: {ex.Message}");
                            response.Status = System.Net.HttpStatusCode.RequestTimeout;
                        }
                        catch (HttpRequestException e)
                        {
                            Debug.WriteLine($"Error message: {e.InnerException.Message}");
                            response.Status = System.Net.HttpStatusCode.RequestTimeout;
                        }
                        catch (Exception ex)
                        {
                            //Acr.UserDialogs.UserDialogs.Instance.Alert($"RequestSender.SendRequestAsync {ex.Message}");
                        }
                    }
                }
                return response;
            }
        }
    }
}


