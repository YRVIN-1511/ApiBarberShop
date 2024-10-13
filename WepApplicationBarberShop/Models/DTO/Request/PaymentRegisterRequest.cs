namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class PaymentRegisterRequest
    {
        public string trace { get; set; } = string.Empty;
        public int idReservation { get; set; } = 0;
        public int idClient { get; set; } = 0;
        public int idBarber { get; set; } = 0;
        public decimal total { get; set; } = 0M;
        public decimal cash { get; set; } = 0M;
        public decimal change { get; set; } = 0M;
        public List<DetailPayment> detail { get; set; } = new();
    }
    public class DetailPayment
    {
        public int typeService { get; set; } = 0;
        public decimal price { get; set; } = 0M;
        public int qty { get; set; } = 0;
        public decimal discount { get; set; } = 0M;
        public decimal subTotal { get; set; } = 0M;        
    }
}
