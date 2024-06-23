using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class AvailableTimesBarbersResponse : CommonResult
    {
        public List<AvilableTimesBarbers> avilablesTimesBarbers { get; set; } = new();
        public static AvailableTimesBarbersResponse Ok(List<AvilableTimesBarbers> data)
        {
            return new AvailableTimesBarbersResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                avilablesTimesBarbers = data
            };
        }
        public static AvailableTimesBarbersResponse fatal()
        {
            return new AvailableTimesBarbersResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static AvailableTimesBarbersResponse Error(string code, string message)
        {
            return new AvailableTimesBarbersResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class AvilableTimesBarbers
    {
        public int idAvailableTurn { get; set; } = 0;
        public string names { get; set; }
        public string date { get; set; }
        public string turnInit { get; set; }
        public string turnEnd { get; set; }
    }
}
