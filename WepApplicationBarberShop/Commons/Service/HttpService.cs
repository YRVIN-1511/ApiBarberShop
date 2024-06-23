using BCP.Framework.Log;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WepApplicationBarberShop.Commons.Service
{
    public class HttpService : IHttpService
    {
        private HttpClient httpClient;
        private void CreateHttpClient()
        {
            // Disables the default cache
            if (httpClient != null)
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            else
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                httpClient = new HttpClient(clientHandler);
                httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.Timeout = TimeSpan.FromSeconds(120);
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            }
        }
        public async Task<HttpMessageCustom<T>> PostAsync<T>(string nameService, string trace, string url, object request, bool authorization = false, string userName = "", string password = "", List<Tuple<string, string>>? header = default)
        {
            try
            {
                HttpMessageCustom<T> response = new HttpMessageCustom<T>();
                Logger.Information(string.Format("["+ trace +"] ,SERVICE {0} URL SERVICE => {1}", nameService, url));
                CreateHttpClient();
                string _response = string.Empty;
                string myContent = JsonConvert.SerializeObject(request);
                byte[] buffer = Encoding.UTF8.GetBytes(myContent);
                ByteArrayContent byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                if (authorization)
                {
                    string authenticationString = $"{userName}:{password}";
                    string base64EncodedAuthenticationString = Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationString));
                    httpClient.DefaultRequestHeaders.Add($"Authorization", $"Basic {base64EncodedAuthenticationString}");
                }
                if (header != null)
                {
                    foreach (Tuple<string, string> item in header)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Item1, item.Item2);
                    }
                }
                Logger.Information($"["+ trace +"] ,SERVICE " + nameService + " REQUEST => " + myContent);
                HttpResponseMessage data = await httpClient.PostAsync(url, byteContent);
                using (HttpContent content = data.Content)
                {
                    _response = await content.ReadAsStringAsync();
                }
                response.StatusCode = data.StatusCode;
                response.IsSuccessStatusCode = data.IsSuccessStatusCode;
                response.Message = string.Empty;
                if (data.IsSuccessStatusCode)                    
                {
                    Logger.Information($"[" + trace + "] ,SERVICE " + nameService + " RESPONSE => " + _response);
                    response.Data = JsonConvert.DeserializeObject<T>(_response);
                }
                else
                    response.Message = _response;
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
