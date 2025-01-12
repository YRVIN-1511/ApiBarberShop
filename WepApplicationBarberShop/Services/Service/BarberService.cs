﻿using AutoMapper;
using BCP.Framework.Log;
using Newtonsoft.Json;
using System.Data;
using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;
using WepApplicationBarberShop.Models.DTO.Response;
using WepApplicationBarberShop.Repositories.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WepApplicationBarberShop.Services.Service
{
    public class BarberService : IBarberService
    {
        private readonly IMapper _mapper;
        private readonly IBarberRepository _repository;
        private readonly IConfiguration _configuration;
        public BarberService(IConfiguration configuration, IMapper mapper, IBarberRepository _repository)
        {
            _mapper = mapper;
            this._repository = _repository;
            _configuration = configuration;
        }
        public async Task<PerfilsResponse> getPerfils()
        {
            PerfilsResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET PERFILS]");
                var responseStatus = await _repository.GetPerfilsBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<Perfil> perfils = new List<Perfil>();
                    foreach (DataRow item in responseStatus.Rows)
                        perfils.Add(new Perfil { id = item.Field<int>("ID"), perfil = item.Field<string>("PERFIL").Trim() });
                    _response = PerfilsResponse.Ok(perfils);
                }
                else
                    _response = PerfilsResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = PerfilsResponse.fatal();
            }
            return _response;
        }
        public async Task<UsersResponse> getUsers()
        {
            UsersResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET USERS]");
                var responseStatus = await _repository.GetUsersBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<InformationUser> infoUser = new List<InformationUser>();
                    foreach (DataRow item in responseStatus.Rows)
                        infoUser.Add(new InformationUser {
                            perfil = new Perfil { id = item.Field<int>("ID_PERFIL"), perfil = item.Field<string>("PERFIL").Trim() },
                            information = new User { id  = item.Field<int>("ID"), lastName = item.Field<string>("LAST_NAME").Trim(), motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(), names = item.Field<string>("NAMES").Trim()
                                            , state = item.Field<string>("STATE").Trim(), dateCreated = item.Field<string>("DATE_CREATED")},
                            loginInfo = new AuthenticationUser { userName = item.Field<string>("USER_A").Trim(), passwordName = item.Field<string>("PASSWORD_A").Trim()}
                        });                            
                    _response = UsersResponse.Ok(infoUser);
                }
                else
                    _response = UsersResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = UsersResponse.fatal();
            }
            return _response;
        }
        public async Task<UsersResponse> getUser(string idUser)
        {
            UsersResponse _response = null;
            try
            {                
                Logger.Error($"REQUEST Receive [GET USERS BY ID]");
                var responseStatus = await _repository.GetUserBD(idUser);
                if (responseStatus.Rows.Count > 0)
                {
                    List<InformationUser> infoUser = new List<InformationUser>();
                    foreach (DataRow item in responseStatus.Rows)
                        infoUser.Add(new InformationUser
                        {
                            perfil = new Perfil { id = item.Field<int>("ID_PERFIL"), perfil = item.Field<string>("PERFIL").Trim() },
                            information = new User
                            {
                                id = item.Field<int>("ID"),
                                lastName = item.Field<string>("LAST_NAME").Trim(),
                                motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(),
                                names = item.Field<string>("NAMES").Trim()
                                            ,
                                state = item.Field<string>("STATE").Trim(),
                                dateCreated = item.Field<string>("DATE_CREATED")
                            },
                            loginInfo = new AuthenticationUser { userName = item.Field<string>("USER_A").Trim(), passwordName = item.Field<string>("PASSWORD_A").Trim() }
                        });
                    _response = UsersResponse.Ok(infoUser);
                }
                else
                    _response = UsersResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = UsersResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> deleteUser(string idUser)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [DELETE USER BY ID]");
                _response = await _repository.DeleteUserBD(idUser) == true ? CommonResult.Ok() : CommonResult.Error("100", "USER NOT DELETED");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = UsersResponse.fatal();
            }
            return _response;
        }
        public async Task<BarbersResponse> getBarbers()
        {
            BarbersResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET BARBERS]");
                var responseStatus = await _repository.GetBarbersBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<Barber> infoBarber = new List<Barber>();
                    foreach (DataRow item in responseStatus.Rows)
                        infoBarber.Add(new Barber
                        {
                            id = item.Field<int>("ID"),
                            lastName = item.Field<string>("LAST_NAME").Trim(),
                            motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(),
                            names = item.Field<string>("NAMES").Trim(),
                            image = item.Field<string>("IMAGES") ?? string.Empty,
                            state = item.Field<string>("STATE").Trim(),
                            alias = item.Field<string>("ALIAS").Trim()
                        });
                    _response = BarbersResponse.Ok(infoBarber);
                }
                else
                    _response = BarbersResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = BarbersResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> deleteBarber(string idBarber)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [DELETE USER BY ID]");
                _response = await _repository.DeleteBarberBD(idBarber) == true ? CommonResult.Ok() : CommonResult.Error("100", "USER NOT DELETED");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = UsersResponse.fatal();
            }
            return _response;
        }
        public async Task<BarbersResponse> getBarber(string id)
        {
            BarbersResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET BARBER] " + id);
                var responseStatus = await _repository.GetBarberBD(id);
                if (responseStatus.Rows.Count > 0)
                {
                    List<Barber> infoBarber = new List<Barber>();
                    foreach (DataRow item in responseStatus.Rows)
                        infoBarber.Add(new Barber
                        {
                            id = item.Field<int>("ID"),
                            lastName = item.Field<string>("LAST_NAME").Trim(),
                            motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(),
                            names = item.Field<string>("NAMES").Trim(),
                            image = item.Field<string>("IMAGES") ?? string.Empty,
                            state = item.Field<string>("STATE").Trim(),
                            alias = item.Field<string>("ALIAS").Trim()
                        });
                    _response = BarbersResponse.Ok(infoBarber);
                }
                else
                    _response = BarbersResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = BarbersResponse.fatal();
            }
            return _response;
        }
        public async Task<ClientsResponse> getClients(FilterClientRequest _request)
        {
            ClientsResponse _response = null;
            try
            {
                DataTable responseStatus = new();
                if (_request.typeFilter == "NAMES")
                {
                    if (_request.lastName.Trim() == "" && _request.motherLastName.Trim() == "" && _request.names.Trim() == "")
                        return ClientsResponse.Error("011", "FILTER INVALID - NAMES");
                    else
                    {
                        Logger.Error($"REQUEST Receive [GET CLIENTS BY NAMES]");
                        responseStatus = await _repository.GetClientsByNamesBD(_request.lastName, _request.motherLastName, _request.names);
                    }
                }
                else if (_request.typeFilter == "EMAIL")
                {
                    if (_request.email.Trim() == "")
                        return ClientsResponse.Error("012", "FILTER INVALID - EMAIL");
                    else
                    {
                        Logger.Error($"REQUEST Receive [GET CLIENTS BY EMAIL]");
                        responseStatus = await _repository.GetClientsByEmialBD(_request.email);
                    }
                }
                else if (_request.typeFilter == "CELLPHONE")
                {
                    if (_request.cellphone.Trim() == "")
                        return ClientsResponse.Error("013", "FILTER INVALID - CELLPHONE");
                    else
                    {
                        Logger.Error($"REQUEST Receive [GET CLIENTS BY CELPHONE]");
                        responseStatus = await _repository.GetClientsByCellphoneBD(_request.cellphone);
                    }
                }                
                if (responseStatus.Rows.Count > 0)
                {
                    List<InformationClient> infoClient = new List<InformationClient>();
                    foreach (DataRow item in responseStatus.Rows)
                        infoClient.Add(new InformationClient
                        {
                            id = item.Field<int>("ID"),
                            names = item.Field<string>("NAMES").Trim(),
                            lastName = item.Field<string>("LAST_NAME").Trim(),
                            motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(),
                            email = item.Field<string>("EMAIL").Trim(),
                            cellphone = item.Field<string>("CELLPHONE").Trim()                            
                        });
                    _response = ClientsResponse.Ok(infoClient);
                }
                else
                    _response = ClientsResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = ClientsResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addUserAsync(CreateUserRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var responseRegister = await _repository.AddUserBD(_request.idPerfil, _request.user.lastName, _request.user.motherLastName, _request.user.names
                                                                    , _request.loginUser.userName, _request.loginUser.passwordName, _request.trace);
                _response = responseRegister == true ? CommonResult.Ok() : CommonResult.Error("100", "USER NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> updateUserAsync(UpdateUserRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var responseRegister = await _repository.UpdateUserBD(_request);
                _response = responseRegister == true ? CommonResult.Ok() : CommonResult.Error("100", "USER NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addBarberAsync(CreateBarberRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var responseRegister = await _repository.AddBarberBD(_request.barber.lastName, _request.barber.motherLastName, _request.barber.names, _request.barber.alias, _request.trace);
                if (responseRegister.Item1)
                {
                    string _route = _configuration.GetValue<string>("dataFileServerConfiguration:pathAttachments");
                    SaveBase64AsFile(_route, _request.barber.image, responseRegister.Item2);
                } 
                _response = responseRegister.Item1 == true ? CommonResult.Ok() : CommonResult.Error("150", "BARBER NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> updateBarberAsync(UpdateBarberRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var responseRegister = await _repository.UpdateBarberBD(_request.barber.id, _request.barber.lastName, _request.barber.motherLastName, _request.barber.names, _request.barber.alias, _request.trace);
                if (responseRegister)
                {
                    string _route = _configuration.GetValue<string>("dataFileServerConfiguration:pathAttachments");
                    DeleteFile(_route, "IM-" + _request.barber.id + ".jpeg");
                    SaveBase64AsFile(_route, _request.barber.image, "IM-" + _request.barber.id + ".jpeg");
                }
                _response = responseRegister == true ? CommonResult.Ok() : CommonResult.Error("151", "BARBER NOT UPDATE");                
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CreateClientResponse> addClientAsync(CreateClientRequest _request)
        {
            CreateClientResponse _response = new();
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var responseRegister = await _repository.AddClientBD(_request.lastName.ToUpper().Trim(), _request.motherLastName.ToUpper().Trim(), _request.names.ToUpper().Trim(), _request.email.ToUpper().Trim(), _request.cellphone, _request.trace);
                _response = responseRegister.Item1 == true ? CreateClientResponse.Ok(responseRegister.Item2) : CreateClientResponse.Error("100", "USER NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CreateClientResponse.fatal();
            }
            return _response;
        }
        public async Task<TurnsResponse> getTurns()
        {
            TurnsResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET TURNS]");
                var responseStatus = await _repository.GetTurnsBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<Turn> turn = new List<Turn>();
                    foreach (DataRow item in responseStatus.Rows)
                        turn.Add(new Turn
                        {
                            idTurn = item.Field<int>("ID"),
                            turnInit = item.Field<string>("HOUR_INIT"),
                            turnEnd = item.Field<string>("HOUR_END")
                        });                        
                    _response = TurnsResponse.Ok(turn);
                }
                else
                    _response = TurnsResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = TurnsResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addTurnsAsync(CreateTurnRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                TimeSpan currentTime;
                TimeSpan endTime;
                bool conversionExitosa = TimeSpan.TryParse(_request.hourInit, out currentTime);
                if(!conversionExitosa) return CommonResult.Error("101", "ERROR HOUR INIT");
                conversionExitosa = TimeSpan.TryParse(_request.hourEnd, out endTime);
                if (!conversionExitosa) return CommonResult.Error("101", "ERROR HOUR END");                
                while (currentTime < endTime)
                {
                    var _responseInsert = await _repository.AddTurnBD(_request.interval,currentTime, _request.trace);
                    if (_responseInsert.Item2)
                        currentTime = _responseInsert.Item1;
                    else
                        return CommonResult.Error("100", "TURN NOT REGISTER");
                }
                _response = CommonResult.Ok();
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addRelationBarberTurnAsync(CreateRelationBarberTurnRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                foreach (int turn in _request.idTurns)
                {
                    var _responseInsert = await _repository.AddRelationBarberTurnBD(_request.idBarber, turn,_request.date, _request.trace);
                    if (!_responseInsert)
                        return CommonResult.Error("102", "RELATION NOT REGISTER");
                }
                _response = CommonResult.Ok();
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<ReservationResponse> addReservationAsync(ReservationRequest _request)
        {
            ReservationResponse _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var _responseInsert = await _repository.AddReservationBarberBD(_request.idClient, _request.idRelationBarberTurn, _request.trace);
                if( _responseInsert.Item1) _response = ReservationResponse.Ok("RV-" + _responseInsert.Item2); else _response = ReservationResponse.Error("103", "RESERVATION NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = ReservationResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addRegisterPayment(PaymentRegisterRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var _responseInsert = await _repository.AddRegisterPaymentBD(_request);
                if (_responseInsert) _response = CommonResult.Ok(); else _response = CommonResult.Error("303", "PAYMENT NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }

        public async Task<AvailableTimesBarberResponse> GetAvailableTimesByIdBarber(AvailableTimesBarberRequest _request)
        {
            AvailableTimesBarberResponse _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var _responseBD = await _repository.GetAvailableTimesByBarberBD(_request.idBarber, _request.date, _request.trace);
                if (_responseBD.Rows.Count > 0)
                {
                    List<AvilableTimesBarber> availableTimes = new();
                    foreach (DataRow item in _responseBD.Rows)
                        availableTimes.Add(new AvilableTimesBarber
                        {
                            idAvailableTurn = item.Field<int>("ID"),
                            turnInit = item.Field<string>("HOUR_INIT"),
                            turnEnd = item.Field<string>("HOUR_END")
                        });
                    _response = AvailableTimesBarberResponse.Ok(availableTimes);
                }
                else
                    _response = AvailableTimesBarberResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = AvailableTimesBarberResponse.fatal();
            }
            return _response;
        }
        public async Task<InformationReservationResponse> GetInformationReservation(string id)
        {
            InformationReservationResponse _response = null;
            try
            {                
                Logger.Error($"REQUEST id Receive [" + id + "]");
                id = id.Replace("RV-", "");
                var _responseBD = await _repository.GetInformationReservationBD(id);
                if (_responseBD.Rows.Count > 0)
                {
                    foreach (DataRow item in _responseBD.Rows)
                    {                        
                        Information _data = new() { 
                            id = item.Field<int>("ID"),
                            lastName = item.Field<string>("LAST_NAME").Trim(),
                            motherLastName = item.Field<string>("MOTHER_LAST_NAME").Trim(),
                            names = item.Field<string>("NAMES").Trim(),
                            email = item.Field<string>("EMAIL").Trim(),
                            cellphone = item.Field<string>("CELLPHONE").Trim(),
                            idBarber = item.Field<int>("ID_BARBER"),
                            aliasBarber = item.Field<string>("BARBER").Trim(),
                            dateReservation = item.Field<string>("DATE_RESERVATION").Trim()
                        };
                        _response = InformationReservationResponse.Ok(_data);
                    }
                }
                else
                    _response = InformationReservationResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = InformationReservationResponse.fatal();
            }
            return _response;
        }
        public async Task<AvailableTimesBarbersResponse> GetAvailableTimesBarbers(bool available)
        {
            AvailableTimesBarbersResponse _response = null;
            try
            {
                var _responseBD = await _repository.GetAvailableOrNotAvailableTimesBarbersBD(available);
                if (_responseBD.Rows.Count > 0)
                {
                    List<AvilableTimesBarbers> availableTimes = new();
                    foreach (DataRow item in _responseBD.Rows)
                        availableTimes.Add(new AvilableTimesBarbers
                        {
                            idAvailableTurn = item.Field<int>("ID"),
                            names = item.Field<string>("NAMES").ToUpper(),
                            date = item.Field<string>("DATE"),
                            turnInit = item.Field<string>("HOUR_INIT"),
                            turnEnd = item.Field<string>("HOUR_END")
                        });
                    _response = AvailableTimesBarbersResponse.Ok(availableTimes);
                }
                else
                    _response = AvailableTimesBarbersResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = AvailableTimesBarbersResponse.fatal();
            }
            return _response;
        }
        public static bool SaveBase64AsFile(string _route, string _documentStructure, string nameFile)
        {
            try
            {
                string _routeDocument = Path.Combine(_route, nameFile);
                if (!Directory.Exists(_route))
                    Directory.CreateDirectory(_route);
                if (File.Exists(_routeDocument))
                    File.Delete(_routeDocument);
                byte[] _fileDocument = Convert.FromBase64String(_documentStructure);
                File.WriteAllBytes(_routeDocument, _fileDocument);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DeleteFile(string _route, string nameFile)
        {
            try
            {
                string _routeDocument = Path.Combine(_route, nameFile);
                if (File.Exists(_routeDocument))
                {
                    File.Delete(_routeDocument);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<ServicesResponse> getServices()
        {
            ServicesResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET SERVICES]");
                var responseStatus = await _repository.GetServicesBarberBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<serviceBarber> perfils = new ();
                    foreach (DataRow item in responseStatus.Rows)
                        perfils.Add(new serviceBarber { id = item.Field<int>("ID"), description = item.Field<string>("DESCRIPTION").Trim().Split('|').ToList(), service= item.Field<string>("SERVICE") });
                    _response = ServicesResponse.Ok(perfils);
                }
                else
                    _response = ServicesResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = ServicesResponse.fatal();
            }
            return _response;
        }
        public async Task<ServicesResponse> getServices(int idService)
        {
            ServicesResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET SERVICES BY ID]");
                var responseStatus = await _repository.GetServicesBarberBD(idService);
                if (responseStatus.Rows.Count > 0)
                {
                    List<serviceBarber> perfils = new();
                    foreach (DataRow item in responseStatus.Rows)
                        perfils.Add(new serviceBarber { id = item.Field<int>("ID"), description = item.Field<string>("DESCRIPTION").Trim().Split('|').ToList(), service = item.Field<string>("SERVICE") });
                    _response = ServicesResponse.Ok(perfils);
                }
                else
                    _response = ServicesResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = ServicesResponse.fatal();
            }
            return _response;
        }
        public async Task<CombosResponse> getCombos()
        {
            CombosResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET COMBOS]");
                var responseStatus = await _repository.GetCombosBarberBD();
                if (responseStatus.Rows.Count > 0)
                {
                    List<comboBarber> combos = new();
                    foreach (DataRow item in responseStatus.Rows)
                        combos.Add(new comboBarber { id = item.Field<int>("ID"), description = item.Field<string>("DESCRIPTION").Trim() });
                    _response = CombosResponse.Ok(combos);
                }
                else
                    _response = CombosResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CombosResponse.fatal();
            }
            return _response;
        }
        public async Task<CombosResponse> getCombos(int idCombo)
        {
            CombosResponse _response = null;
            try
            {
                Logger.Error($"REQUEST Receive [GET COMBOS BY ID]");
                var responseStatus = await _repository.GetCombosBarberBD(idCombo);
                if (responseStatus.Rows.Count > 0)
                {
                    List<comboBarber> combos = new();
                    foreach (DataRow item in responseStatus.Rows)
                        combos.Add(new comboBarber { id = item.Field<int>("ID"), description = item.Field<string>("DESCRIPTION").Trim() });
                    _response = CombosResponse.Ok(combos);
                }
                else
                    _response = CombosResponse.Error("001", "DATA NOT FOUND");
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CombosResponse.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addServiceBarber(ServiceCreateRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var _responseInsert = await _repository.AddServiceBD(_request.service,_request.description, _request.trace);                
                if (_responseInsert) _response = CommonResult.Ok(); else _response = CommonResult.Error("303", "SERVICE NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<CommonResult> addComboBarber(ComboCreateRequest _request)
        {
            CommonResult _response = null;
            try
            {
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                var _responseInsert = await _repository.AddComboBD(_request.description, _request.trace);
                if (_responseInsert) _response = CommonResult.Ok(); else _response = CommonResult.Error("303", "COMBO NOT REGISTER");
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = CommonResult.fatal();
            }
            return _response;
        }
        public async Task<filterBarbersByServicesResponse> filterBarbersByService(FilterBarberByService _request)
        {
            filterBarbersByServicesResponse _response;
            try
            {
                List<ServicesAvailables> aux_services = new();
                Logger.Error($"[" + _request.trace + "], REQUEST Receive [" + JsonConvert.SerializeObject(_request) + "]");
                foreach (var item in _request.idServices)
                {
                    ServicesAvailables _services = new();
                    _services.idService = item;
                    var _resp = await _repository.FilterBarberByService(item, _request.trace);
                    if (_resp.Rows.Count > 0)
                    {
                        _services.available = true;
                        foreach (DataRow row in _resp.Rows)
                        {
                            _services.barbers.Add(new Barber
                            {
                                id = row.Field<int>("ID"),
                                lastName = row.Field<string>("LAST_NAME").Trim(),
                                motherLastName = row.Field<string>("MOTHER_LAST_NAME").Trim(),
                                names = row.Field<string>("NAMES").Trim(),
                                image = row.Field<string>("IMAGES") ?? string.Empty,
                                alias = row.Field<string>("ALIAS").Trim(),
                                price = row.Field<decimal>("PRICE")
                            });                            
                        }
                    }
                    aux_services.Add(_services);
                }
                if (aux_services.Count(s => s.available == true)>0)                    
                    _response = filterBarbersByServicesResponse.Ok(aux_services);
                else
                    _response = filterBarbersByServicesResponse.Error("002","NOT BARBERS AVAILABLES");                
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + _request.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                _response = filterBarbersByServicesResponse.fatal();
            }
            return _response;
        }
    }
}
