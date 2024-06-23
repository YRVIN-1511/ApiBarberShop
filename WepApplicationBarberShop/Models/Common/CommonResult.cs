namespace WepApplicationBarberShop.Models.Common
{
    public class CommonResult
    {
        public string respCode { get; set; }
        public string detailMessage { get; set; }
        public static CommonResult Ok()
        {
            return new CommonResult
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE"
            };
        }
        public static CommonResult fatal()
        {
            return new CommonResult
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static CommonResult Error(string code, string message)
        {
            return new CommonResult
            {
                respCode = code,
                detailMessage = message
            };
        }
        public static CommonResult NoAuthorized()
        {
            return new CommonResult
            {
                respCode = "01",
                detailMessage = "El canal o aplicativo no cuenta con accesos"
            };
        }
    }
}
