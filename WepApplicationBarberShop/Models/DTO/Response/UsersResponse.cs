using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Models.DTO.Response
{
    public class UsersResponse:CommonResult
    {
        public List<InformationUser> user { get; set; } = new();
        public static UsersResponse Ok(List<InformationUser> data)
        {
            return new UsersResponse
            {
                respCode = "00",
                detailMessage = "PROCESS COMPLETE",
                user = data
            };
        }
        public static UsersResponse fatal()
        {
            return new UsersResponse
            {
                respCode = "99",
                detailMessage = "INTERNAL APPLICATION ERROR"
            };
        }
        public static UsersResponse Error(string code, string message)
        {
            return new UsersResponse
            {
                respCode = code,
                detailMessage = message
            };
        }
    }
    public class InformationUser
    {
        public Perfil perfil { get; set; } = new(); 
        public User? information { get; set; } = new();
        public AuthenticationUser? loginInfo { get; set; } = new();
    }
    public class User: DataBasicUser
    {
        public int id { get; set; }
        public string state { get; set; } = string.Empty;
        public DateTime dateCreated { get; set; }
    }
}
