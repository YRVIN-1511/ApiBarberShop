using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class AvailableTimesBarberResponse : CommonResult
    {
        public List<AvilableTimesBarber> avilablesTimesBarber { get; set; } = new();
        public static AvailableTimesBarberResponse Ok(List<AvilableTimesBarber> data)
        {
            return new AvailableTimesBarberResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                avilablesTimesBarber = data
            };
        }
        public static AvailableTimesBarberResponse fatal()
        {
            return new AvailableTimesBarberResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static AvailableTimesBarberResponse Error(string code, string message)
        {
            return new AvailableTimesBarberResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class AvilableTimesBarber
    {
        public int idAvailableTurn { get; set; } = 0;
        public string turnInit { get; set; }
        public string turnEnd { get; set; }
    }
}
