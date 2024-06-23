using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class CreateClientResponse : CommonResult
    {
        public string idClient { get; set; } = string.Empty;
        public static CreateClientResponse Ok(string data)
        {
            return new CreateClientResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                idClient = data
            };
        }
        public static CreateClientResponse fatal()
        {
            return new CreateClientResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static CreateClientResponse Error(string code, string message)
        {
            return new CreateClientResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
}
