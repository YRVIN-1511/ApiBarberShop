using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Response;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class InformationReservationResponse:CommonResult
    {
        public Information dataReservation{ get; set; } = new();
        public static InformationReservationResponse Ok(Information data)
        {
            return new InformationReservationResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                dataReservation = data
            };
        }
        public static InformationReservationResponse fatal()
        {
            return new InformationReservationResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static InformationReservationResponse Error(string code, string message)
        {
            return new InformationReservationResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class Information : InformationClient
    {
        public int idBarber { get; set; } = 0;
        public string aliasBarber { get; set; } = string.Empty;
        public string dateReservation { get; set; } = string.Empty;
    }
}
