using System.Data;

namespace WepApplicationBarberShop.Repositories.IRepositories
{
    public interface IBarberRepository
    {
        Task<DataTable> GetPerfilsBD();
        Task<DataTable> GetUsersBD();
        Task<DataTable> GetBarbersBD();
        Task<bool> AddUserBD(int perfil, string paterno, string materno, string nombres, string UserLogin, string PasswordLogin, string trace);
        Task<bool> AddBarberBD(string paterno, string materno, string nombres, string alias, string trace);
        Task<DataTable> GetTurnsBD();
        Task<Tuple<TimeSpan, bool>> AddTurnBD(int interval, TimeSpan hourInit, string trace);
        Task<DataTable> GetClientsBD();
        Task<bool> AddClientBD(string lastName, string motherLastName, string names, string email, string cellphone, string trace);
        Task<bool> AddRelationBarberTurnBD(int barber, int turn, string date, string trace);
        Task<bool> AddReservationBarberBD(int client, int relationTurnBarber, string trace);
        Task<DataTable> GetAvailableTimesByBarberBD(int barber, string date, string trace);
        Task<DataTable> GetAvailableOrNotAvailableTimesBarbersBD(bool avaialable);
    }
}
