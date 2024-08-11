using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class ReservationResponse : CommonResult
    {
        public string idReservation { get; set; } = string.Empty;
        public static ReservationResponse Ok(string data)
        {
            return new ReservationResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                idReservation = data
            };
        }
        public static ReservationResponse fatal()
        {
            return new ReservationResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static ReservationResponse Error(string code, string message)
        {
            return new ReservationResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
}
