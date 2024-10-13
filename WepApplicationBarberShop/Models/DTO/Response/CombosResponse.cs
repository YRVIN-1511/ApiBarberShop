using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class CombosResponse : CommonResult
    {
        public List<comboBarber> combos { get; set; } = new();
        public static CombosResponse Ok(List<comboBarber> data)
        {
            return new CombosResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                combos = data
            };
        }
        public static CombosResponse fatal()
        {
            return new CombosResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static CombosResponse Error(string code, string message)
        {
            return new CombosResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class comboBarber
    {
        public int id { get; set; } = 0;
        public string description { get; set; } = string.Empty;
    }
}

