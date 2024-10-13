using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class filterBarbersByServicesResponse:CommonResult
    {

        public List<ServicesAvailables> services { get; set; } = new();
        public static filterBarbersByServicesResponse Ok(List<ServicesAvailables> data)
        {
            return new filterBarbersByServicesResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                services = data
            };
        }
        public static filterBarbersByServicesResponse fatal()
        {
            return new filterBarbersByServicesResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static filterBarbersByServicesResponse Error(string code, string message)
        {
            return new filterBarbersByServicesResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class ServicesAvailables
    {
        public string idService { get; set; } = string.Empty;
        public bool available { get; set; } = false;
        public List<Barber> barbers { get; set; } = new();
    }
}
