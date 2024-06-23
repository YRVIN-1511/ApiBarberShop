using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class TurnsResponse : CommonResult
    {
        public List<Turn> turns { get; set; } = new();
        public static TurnsResponse Ok(List<Turn> data)
        {
            return new TurnsResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                turns = data
            };
        }
        public static TurnsResponse fatal()
        {
            return new TurnsResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static TurnsResponse Error(string code, string message)
        {
            return new TurnsResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class Turn
    {
        public int idTurn { get; set; }
        public string turnInit { get; set; }
        public string turnEnd { get; set; }
    }
}
