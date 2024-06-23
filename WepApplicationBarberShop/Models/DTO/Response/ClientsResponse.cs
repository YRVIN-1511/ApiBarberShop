using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class ClientsResponse: CommonResult
    {
        public List<InformationClient> client { get; set; } = new();
        public static ClientsResponse Ok(List<InformationClient> data)
        {
            return new ClientsResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                client = data
            };
        }
        public static ClientsResponse fatal()
        {
            return new ClientsResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static ClientsResponse Error(string code, string message)
        {
            return new ClientsResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class InformationClient
    {
        public int id { get; set; }
        public string names { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string cellphone { get; set; } = string.Empty;
    }
}

