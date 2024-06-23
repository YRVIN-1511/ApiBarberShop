using WepApplicationBarberShop.Models.Common;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class PerfilsResponse : CommonResult
    {
        public List<Perfil> perfils { get; set; } = new();
        public static PerfilsResponse Ok(List<Perfil> data)
        {
            return new PerfilsResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                perfils = data
            };
        }
        public static PerfilsResponse fatal()
        {
            return new PerfilsResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static PerfilsResponse Error(string code, string message)
        {
            return new PerfilsResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class Perfil
    {
        public int id { get; set; }
        public string perfil { get; set; }
    }
}