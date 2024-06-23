namespace WepApplicationBarberShop.Commons.Service
{
    public interface IHttpService
    {
        Task<HttpMessageCustom<T>> PostAsync<T>(string nameService , string trace, string url, object request, bool authorization = false, string userName = "", string password = "", List<Tuple<string, string>>? header = default);
    }
}
