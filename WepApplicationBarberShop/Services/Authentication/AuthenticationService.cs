using BCP.Framework.Log;
using FirmasAPI.Models.Autorizacion;
using WepApplicationBarberShop.Commons.Service;
using WepApplicationBarberShop.Models.Authentication;

namespace WepApplicationBarberShop.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private static readonly string sectionNameAuth = "WebApiAuthentication";
        private readonly WebApiAuthenticationConfig _configAuth;
        private readonly IHttpService _serviceApi;

        public AuthenticationService(IConfiguration configuration, IHttpService serviceApi)
        {
            _configAuth = new WebApiAuthenticationConfig();
            configuration.GetSection(sectionNameAuth).Bind(_configAuth);
            _serviceApi = serviceApi;
        }
        public async Task<AuthenticationEntitie> Authenticate(string userName, string password, string token)
        {
            AuthenticationEntitie _response = new ();
            try
            {
                var _body = new
                {
                    publicToken = token,
                    appUserId = userName.Replace("_", "") + DateTime.Now.ToString("yyyyMMdd"),
                    date = DateTime.Now.ToString("yyyyMMdd"),
                    channel = userName
                };
                string url = _configAuth.url + _configAuth.metodo;
                var response = await _serviceApi.PostAsync<AuthenticationEntitie>("IAM", _body.appUserId, url, _body, true,  userName, password);
                if (!response.IsSuccessStatusCode)
                    Logger.Error($"[" + _body.appUserId + "], SERVICE IAM ERROR: [" + response.Message + "]");
                else
                    _response = response.Data;
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.State = "Exc";
                Logger.Error($"ERROR: {ex.Message}, DETAIL: {ex.StackTrace}");
            }
            return _response;
        }
    }
}
