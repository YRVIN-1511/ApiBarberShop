namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class ReservationRequest
    {
        public string trace { get; set; }
        public int idRelationBarberTurn { get; set; }
        public int idClient { get; set; }

    }
}
