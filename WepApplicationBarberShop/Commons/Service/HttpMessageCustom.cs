using System.Net;

namespace WepApplicationBarberShop.Commons.Service
{
    public class HttpMessageCustom<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
