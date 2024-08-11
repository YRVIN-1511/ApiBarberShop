using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class ServicesResponse : CommonResult
    {
        public List<serviceBarber> services { get; set; } = new();
        public static ServicesResponse Ok(List<serviceBarber> data)
        {
            return new ServicesResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                services = data
            };
        }
        public static ServicesResponse fatal()
        {
            return new ServicesResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static ServicesResponse Error(string code, string message)
        {
            return new ServicesResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class serviceBarber
    {
        public int id { get; set; } = 0;
        public string description { get; set; } = string.Empty;
        public decimal price { get; set; } = 0M;
    }
}

