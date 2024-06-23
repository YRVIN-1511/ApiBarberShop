using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class BarbersResponse:CommonResult
    {
        public List<InformationBarber> user { get; set; } = new();
        public static BarbersResponse Ok(List<InformationBarber> data)
        {
            return new BarbersResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                user = data
            };
        }
        public static BarbersResponse fatal()
        {
            return new BarbersResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static BarbersResponse Error(string code, string message)
        {
            return new BarbersResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class InformationBarber
    {
        public Barber? barber { get; set; } = new();
    }
    public class Barber: DataBasicUser
    {
        public int id { get; set; }
        public string state { get; set; } = string.Empty;
        public string alias { get; set; } = string.Empty;
    }
}
