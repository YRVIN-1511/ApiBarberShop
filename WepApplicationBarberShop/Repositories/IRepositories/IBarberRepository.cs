using System.Data;
using WepApplicationBarberShop.Models.DTO.Request;

namespace WepApplicationBarberShop.Repositories.IRepositories
{
    public interface IBarberRepository
    {
        Task<DataTable> GetPerfilsBD();
        Task<DataTable> GetUsersBD();
        Task<DataTable> GetUserBD(string id);
        Task<bool> DeleteUserBD(string id);
        Task<DataTable> GetBarbersBD();
        Task<DataTable> GetBarberBD(string id);
        Task<bool> DeleteBarberBD(string id);
        Task<bool> AddUserBD(int perfil, string paterno, string materno, string nombres, string UserLogin, string PasswordLogin, string trace);
        Task<bool> UpdateUserBD(UpdateUserRequest dataUser);
        Task<Tuple<bool, string>> AddBarberBD(string paterno, string materno, string nombres, string alias, string trace);
        Task<bool> UpdateBarberBD(int id, string paterno, string materno, string nombres, string alias, string trace);
        Task<DataTable> GetTurnsBD();
        Task<Tuple<TimeSpan, bool>> AddTurnBD(int interval, TimeSpan hourInit, string trace);
        Task<DataTable> GetClientsByNamesBD(string lastName, string motherLastName, string names);
        Task<DataTable> GetClientsByEmialBD(string email);
        Task<DataTable> GetClientsByCellphoneBD(string cellphone);
        Task<Tuple<bool, string>> AddClientBD(string lastName, string motherLastName, string names, string email, string cellphone, string trace);
        Task<bool> AddRelationBarberTurnBD(int barber, int turn, string date, string trace);
        Task<bool> AddReservationBarberBD(int client, int relationTurnBarber, string trace);
        Task<DataTable> GetAvailableTimesByBarberBD(int barber, string date, string trace);
        Task<DataTable> GetAvailableOrNotAvailableTimesBarbersBD(bool avaialable);
    }
}
