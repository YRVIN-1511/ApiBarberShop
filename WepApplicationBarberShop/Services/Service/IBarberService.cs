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
        Task<UsersResponse> getUser(string idUser);
        Task<CommonResult> deleteUser(string idUser);
        Task<BarbersResponse> getBarbers();
        Task<BarbersResponse> getBarber(string id);
        Task<CommonResult> deleteBarber(string idBarber);
        Task<CommonResult> addUserAsync(CreateUserRequest _request);
        Task<CommonResult> updateUserAsync(UpdateUserRequest _request);
        Task<CommonResult> addBarberAsync(CreateBarberRequest _request);
        Task<CommonResult> updateBarberAsync(UpdateBarberRequest _request);
        Task<TurnsResponse> getTurns();
        Task<CommonResult> addTurnsAsync(CreateTurnRequest _request);
        Task<ClientsResponse> getClients(FilterClientRequest _request);
        Task<CreateClientResponse> addClientAsync(CreateClientRequest _request);
        Task<CommonResult> addRelationBarberTurnAsync(CreateRelationBarberTurnRequest _request);
        Task<ReservationResponse> addReservationAsync(ReservationRequest _request);
        Task<CommonResult> addRegisterPayment(PaymentRegisterRequest _request);
        Task<InformationReservationResponse> GetInformationReservation(string id);
        Task<AvailableTimesBarberResponse> GetAvailableTimesByIdBarber(AvailableTimesBarberRequest _request);
        Task<AvailableTimesBarbersResponse> GetAvailableTimesBarbers(bool available);
        Task<ServicesResponse> getServices();
        Task<ServicesResponse> getServices(int idService);
        Task<CombosResponse> getCombos();
        Task<CombosResponse> getCombos(int idCombo);
        Task<CommonResult> addServiceBarber(ServiceCreateRequest _request);
        Task<CommonResult> addComboBarber(ComboCreateRequest _request);
        Task<filterBarbersByServicesResponse> filterBarbersByService(FilterBarberByService _request);
    }
}

