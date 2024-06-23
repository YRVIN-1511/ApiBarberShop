using BCP.Framework.Log;
using CROSS.DATABASE;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WepApplicationBarberShop.Repositories.IRepositories;

namespace WepApplicationBarberShop.Repositories
{
    public class BarberRepository : IBarberRepository
    {
        private readonly IManagerDataBase dataBase;
        public BarberRepository(IManagerDataBase dataBase)
        {
            this.dataBase = dataBase;
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
        public async Task<DataTable> GetClientsBD()
        {
            Logger.Information("GET CLIENTS BD");
            DataTable response = new DataTable();
            try
            {
                string query = "[dbo].[GetClients]";
                response = await this.dataBase.SelectStoredProcedure("BRB.BD.BARBERSHOP", query, new List<SqlParameter>());
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
        public async Task<bool> AddBarberBD(string paterno, string materno, string nombres, string alias, string trace)
        {
            Logger.Information("[" + trace + "], ADD BARBER BD");
            bool response = false;
            try
            {
                string query = "[dbo].[InsertBarber]";
                List<SqlParameter> lstParameters = new List<SqlParameter>
                {
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
        public async Task<bool> AddClientBD(string lastName, string motherLastName, string names, string email, string cellphone, string trace)
        {
            Logger.Information("[" + trace + "], ADD CLIENT BD");
            bool response = false;
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
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
            }
            return response;
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
        public async Task<bool> AddReservationBarberBD(int client, int relationTurnBarber, string trace)
        {
            Logger.Information("[" + trace + "], ADD RESERVATION BD");
            bool response = false;
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
                response = true;
            }
            catch (Exception ex)
            {
                Logger.Error($"[" + trace + "], ERROR: " + ex.Message + ", STACK:" + ex.StackTrace);
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
    }
}
