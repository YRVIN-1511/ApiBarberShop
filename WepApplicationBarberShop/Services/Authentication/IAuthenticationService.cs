using WepApplicationBarberShop.Models.Authentication;

namespace WepApplicationBarberShop.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationEntitie> Authenticate(string userName, string password, string token);
    }
}
