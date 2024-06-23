namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateRelationBarberTurnRequest
    {
        public string trace { get; set; }
        public int idBarber { get; set; }
        public List<int> idTurns { get; set; }
        public string date { get; set; }
    }
}
