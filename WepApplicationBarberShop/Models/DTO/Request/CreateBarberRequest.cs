namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateBarberRequest
    {
        public string? trace { get; set; } = string.Empty;        
        public DataBarber? barber { get; set; } = new ();
    }
    public class DataBarber : DataBasicUser
    {
        public string? alias { get; set; } = string.Empty;
    }
}
