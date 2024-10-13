using BCP.Framework.Log;
using CROSS.DATABASE;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using WepApplicationBarberShop.Models.DTO.Request;
using WepApplicationBarberShop.Models.DTO.Response;
using WepApplicationBarberShop.Repositories.IRepositories;

namespace WepApplicationBarberShop.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly IManagerDataBase dataBase;
        private string _urlBase;
        public BarberRepository(IManagerDataBase dataBase, string urlBase)
        {
            this.dataBase = dataBase;
            _urlBase = urlBase;
        }
        public async Task<DataTable> GetPerfilsBD()
        {
            Logger.Information("GET PERFILS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetPerfils]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());                
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetServicesBarberBD()
        {
            Logger.Information("GET SERVICES BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetServices]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetServicesBarberBD(int idService)
        {
            Logger.Information("GET SERVICES BY ID BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetServicesById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", idService)
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetCombosBarberBD()
        {
            Logger.Information("GET COMBOS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetCombos]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetCombosBarberBD(int id)
        {
            Logger.Information("GET COMBOS BY ID BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetCombosById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id)
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetUsersBD()
        {
            Logger.Information("GET USERS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetUsers]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetUserBD(string id)
        {
            Logger.Information("GET USERS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetUsersById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id)
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> DeleteUserBD(string id)
        {
            Logger.Information("DELETE USER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[DeleteUsersById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id)
                };
                response = await this.dataBase.ExecuteStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetBarbersBD()
        {
            Logger.Information("GET BARBERS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetBarbers]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetBarberBD(string id)
        {
            Logger.Information("GET BARBERS BD BY ID");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetBarbersById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id)
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> DeleteBarberBD(string id)
        {
            Logger.Information("DELETE BARBER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[DeleteBarberById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id)
                };
                response = await this.dataBase.ExecuteStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetClientsByNamesBD(string lastName, string motherLastName, string names)
        {
            Logger.Information("GET CLIENTS BD BY NAMES");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetClients]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@FILTER", "NAMES"),
                    new SqlParameter("@LASTNAME", lastName),
                    new SqlParameter("@MOTHERLASTNAME", motherLastName),
                    new SqlParameter("@NAMES", names),
                    new SqlParameter("@EMAIL", ""),
                    new SqlParameter("@CELLPHONE", "")
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetClientsByEmialBD(string email)
        {
            Logger.Information("GET CLIENTS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetClients]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@FILTER", "EMAIL"),
                    new SqlParameter("@LASTNAME", ""),
                    new SqlParameter("@MOTHERLASTNAME", ""),
                    new SqlParameter("@NAMES", ""),
                    new SqlParameter("@EMAIL", email),
                    new SqlParameter("@CELLPHONE", "")
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetClientsByCellphoneBD(string cellphone)
        {
            Logger.Information("GET CLIENTS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetClients]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@FILTER", "CELLPHONE"),
                    new SqlParameter("@LASTNAME", ""),
                    new SqlParameter("@MOTHERLASTNAME", ""),
                    new SqlParameter("@NAMES", ""),
                    new SqlParameter("@EMAIL", ""),
                    new SqlParameter("@CELLPHONE", cellphone)
                };
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> AddUserBD(int perfil, string paterno, string materno, string nombres
                                          ,string UserLogin, string PasswordLogin, string trace)
        {
            Logger.Information("[" + trace + "], ADD USER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertUser]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_PERFIL", perfil),
                    new SqlParameter("@LAST_NAME", paterno),
                    new SqlParameter("@MOTHER_LAST_NAME", materno),
                    new SqlParameter("@NAMES", nombres),
                    new SqlParameter("@USER_A", UserLogin),
                    new SqlParameter("@PASSWORD_A", PasswordLogin)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;
                
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> UpdateUserBD(UpdateUserRequest dataUser)
        {
            Logger.Information("[" + dataUser.trace + "], ADD USER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[UpdateUser]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", dataUser.idUser),
                    new SqlParameter("@ID_PERFIL", dataUser.idPerfil),
                    new SqlParameter("@LAST_NAME", dataUser.dataBasic.lastName),
                    new SqlParameter("@MOTHER_LAST_NAME", dataUser.dataBasic.motherLastName),
                    new SqlParameter("@NAMES", dataUser.dataBasic.names),
                    new SqlParameter("@RESET_PASS", dataUser.resetPass)
                };
                Logger.Debug("[" + dataUser.trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + dataUser.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<Tuple<bool,string>> AddBarberBD(string paterno, string materno, string nombres, string alias, string trace)
        {
            Logger.Information("[" + trace + "], ADD BARBER BD");
            bool response = false;
            string nameImage = string.Empty;
            string _image = this._urlBase;
            try
            {
                string query = "[dbo].[InsertBarber]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@LAST_NAME", paterno),
                    new SqlParameter("@MOTHER_LAST_NAME", materno),
                    new SqlParameter("@NAMES", nombres),
                    new SqlParameter("@ALIAS", alias),
                    new SqlParameter("@IMAGE", _image),
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                nameImage = data.Rows[0][0].ToString();
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return Tuple.Create<bool, string>(response, nameImage);
        }
        public async Task<bool> UpdateBarberBD(int id, string paterno, string materno, string nombres, string alias, string trace)
        {
            Logger.Information("[" + trace + "], UPDATE BARBER BD");
            bool response = false;
            string _image = this._urlBase + "IM." + paterno + materno + nombres + ".jpeg";
            try
            {
                string query = "[dbo].[UpdateBarber]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", id),
                    new SqlParameter("@LAST_NAME", paterno),
                    new SqlParameter("@MOTHER_LAST_NAME", materno),
                    new SqlParameter("@NAMES", nombres),
                    new SqlParameter("@ALIAS", alias)                    
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<Tuple<bool, string>> AddClientBD(string lastName, string motherLastName, string names, string email, string cellphone, string trace)
        {
            Logger.Information("[" + trace + "], ADD CLIENT BD");
            try
            {
                string query = "[dbo].[InsertClient]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@LASTNAME", lastName),
                    new SqlParameter("@MOTHERLASTNAME", motherLastName),
                    new SqlParameter("@NAMES", names),
                    new SqlParameter("@EMAIL", email),
                    new SqlParameter("@CELLPHONE", cellphone)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                string id = data.Rows[0][0].ToString();
                return Tuple.Create(true, id);
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                return Tuple.Create(false, "");
            }            
        }
        public async Task<DataTable> GetTurnsBD()
        {
            Logger.Information("GET TURNS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetTurns]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<Tuple<TimeSpan,bool>> AddTurnBD(int interval, TimeSpan hourInit, string trace)
        {
            Logger.Information("[" + trace + "], ADD TURN BD");
            try
            {
                string query = "[dbo].[InsertTurn]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@StartTime", hourInit),
                    new SqlParameter("@IntervalMinutes", interval)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                if (data.Rows.Count > 0)
                    return Tuple.Create<TimeSpan, bool>((TimeSpan)data.Rows[0]["HOUR_END"], true);
                else
                    return Tuple.Create<TimeSpan, bool>(TimeSpan.MinValue, false);

            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                return Tuple.Create<TimeSpan, bool>(TimeSpan.MinValue, false);
            }
        }
        public async Task<bool> AddRelationBarberTurnBD(int barber, int turn, string date, string trace)
        {
            Logger.Information("[" + trace + "], ADD RELATION BARBER TURN BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertBarberTurnRelation]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_BARBER", barber),
                    new SqlParameter("@ID_TURN", turn),
                    new SqlParameter("@DATE", date)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<Tuple<bool,string>> AddReservationBarberBD(int client, int relationTurnBarber, string trace)
        {
            Logger.Information("[" + trace + "], ADD RESERVATION BD");
            Tuple<bool,string> response = Tuple.Create<bool, string>(false,"");
            try
            {
                string query = "[dbo].[InsertReservation]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_RELATION_BARBER", relationTurnBarber),
                    new SqlParameter("@ID_CLIENT", client)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                if (data.Rows.Count > 0)
                    response = Tuple.Create<bool,string>(true, data.Rows[0]["ID"].ToString());
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> AddRegisterPaymentBD(PaymentRegisterRequest payment)
        {
            Logger.Information("[" + payment.trace + "], ADD RESERVATION BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertPayment]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_RESERVATION", payment.idReservation),
                    new SqlParameter("@ID_CLIENT", payment.idClient),
                    new SqlParameter("@ID_BARBER", payment.idBarber),
                    new SqlParameter("@TOTAL", payment.total),
                    new SqlParameter("@CASH", payment.cash),
                    new SqlParameter("@CHANGE", payment.change)
                };
                Logger.Debug("[" + payment.trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                int idPayment = 0;
                if (data.Rows.Count > 0)
                {
                    idPayment = Convert.ToInt16(data.Rows[0]["ID_PAYMENT"]);
                    foreach (var item in payment.detail)
                    {
                        query = "[dbo].[InsertPaymentDetail]";
                        lstParameters = new List<SqlParameter>
                        {
                            new SqlParameter("@ID_PAYMENTS", idPayment),
                            new SqlParameter("@ID_TYPE_SERVICE", item.typeService),
                            new SqlParameter("@PRICE", item.price),
                            new SqlParameter("@QTY", item.qty),
                            new SqlParameter("@DISCOUNT", item.discount),
                            new SqlParameter("@SUB_TOTAL", item.subTotal)
                        };
                        Logger.Debug("[" + payment.trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                        await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                    }
                    response = true;
                }                    
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + payment.trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }

        public async Task<DataTable> GetAvailableTimesByBarberBD(int barber, string date, string trace)
        {
            Logger.Information("[" + trace + "], GET AVAILABLE TIME BY BARBER BD");
            DataTable response = new();
            try
            {
                string query = "[dbo].[GetAvailableTimesById]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_BARBER", barber),
                    new SqlParameter("@DATE_FIL", date)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetInformationReservationBD(string id)
        {
            Logger.Information("GET AVAILABLE TIME BY BARBER BD");
            DataTable response = new();
            try
            {
                string query = "[dbo].[GetDataByReservation]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_RESERVATION", id)
                };
                Logger.Debug("REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> GetAvailableOrNotAvailableTimesBarbersBD(bool avaialable)
        {
            Logger.Information("GET AVAILABLE OR NOT AVAILABLE TIME BARBERS BD");
            DataTable response = new();
            try
            {
                string query = "[dbo].[GetAvailableBarbers]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@AVAILABLE", avaialable)
                };
                Logger.Debug("REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> AddServiceBD(string service, string description, string trace)
        {
            Logger.Information("[" + trace + "], ADD USER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertServiceBarber]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@SERVICE", service),
                    new SqlParameter("@DESCRIPTION", "N'" + description)                    
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;

            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> AddComboBD(string description, string trace)
        {
            Logger.Information("[" + trace + "], ADD COMBO BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertComboService]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@DESCRIPTION", description)
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                var data = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);
                response = true;

            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
        }
        public async Task<DataTable> FilterBarberByService(string idService, string trace)
        {
            Logger.Information("[" + trace + "], FILTER BARBER BY SERVICES BD");            
            try
            {
                string query = "[dbo].[GetRelationServiceBarber]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID_SERVICE", idService)                    
                };
                Logger.Debug("[" + trace + "], REQUEST BD => SP: " + query + ", PARAMETERS: " + JsonConvert.SerializeObject(lstParameters));
                return await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, lstParameters);                
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
                return new DataTable();
            }            
        }
    }
}
