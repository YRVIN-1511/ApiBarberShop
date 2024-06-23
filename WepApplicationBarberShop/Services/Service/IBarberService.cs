using System.Data;
using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;
using WepApplicationBarberShop.Models.DTO.Response;

namespace WepApplicationBarberShop.Services.Service
{
    public interface IBarberService
    {
        Task<PerfilsResponse> getPerfils();
        Task<UsersResponse> getUsers();
        Task<BarbersResponse> getBarbers();
        Task<CommonResult> addUserAsync(CreateUserRequest _request);
        Task<CommonResult> addBarberAsync(CreateBarberRequest _request);
        Task<TurnsResponse> getTurns();
        Task<CommonResult> addTurnsAsync(CreateTurnRequest _request);
        Task<ClientsResponse> getClients();
        Task<CommonResult> addClientAsync(CreateClientRequest _request);
        Task<CommonResult> addRelationBarberTurnAsync(CreateRelationBarberTurnRequest _request);
        Task<CommonResult> addReservationAsync(ReservationRequest _request);
        Task<AvailableTimesBarberResponse> GetAvailableTimesByIdBarber(AvailableTimesBarberRequest _request);
        Task<AvailableTimesBarbersResponse> GetAvailableTimesBarbers(bool available);
    }
}

