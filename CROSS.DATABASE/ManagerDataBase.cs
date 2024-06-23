using BCP.Framework.Log;
using BCP.SLK.DATABASE;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CROSS.DATABASE
{
    public class ManagerDataBase : IManagerDataBase
    {
        private readonly IDBOptions dBOption;

        public ManagerDataBase(IDBOptions optionsDB)
        {
            dBOption = optionsDB;
        }

        public async Task<Tuple<bool, string>> Check(string name)
        {
            Tuple<bool, string> conexion = new Tuple<bool, string>(false, string.Empty);
            DBOptionItems item = dBOption.getItemOptions(name);
            using (SqlConnection sqlConnection = new SqlConnection(item.ConnectionString))
            {
                try
                {
                    try
                    {
                        await sqlConnection.OpenAsync();
                        conexion = new Tuple<bool, string>(true, $"BATABASE: {item.DataBase}; SERVER: {item.Server}; USER: {item.User}");
                    }
                    catch (Exception ex)
                    {
                        conexion = new Tuple<bool, string>(false, $"COULD NOT CONNECT TO DATABASE: {item.DataBase} SERVER: {item.Server}; USER: {item.User}; EXCEPTION: {ex.Message.ToUpper()}");
                    }
                    finally
                    {
                        sqlConnection.Close();
                        SqlConnection.ClearAllPools();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Exception:  " + ex.Message, ex);
                    conexion = new Tuple<bool, string>(false, $"CONFIG PARMETER DATABASE: {name}; EXCEPTION: {ex.Message.ToUpper()}");
                }

                return conexion;
            }
        }

        public async Task<bool> ExecuteStoredProcedure(string name, string query, List<SqlParameter> parameter)
        {
            using (SqlConnection conexion = new SqlConnection(this.dBOption.getItemOptions(name).ConnectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 600000,
                    };
                    foreach (SqlParameter item in parameter)
                    {
                        if (item.Value == null)
                        {
                            item.Value = DBNull.Value;
                        }

                        comando.Parameters.Add(item);
                    }

                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                    return true;
                }
                catch (SqlException error)
                {
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                    Logger.Error("Exception:  " + error.Message, error);
                    return false;
                }
            }
        }

        public async Task<bool> Execute(string name, string query)
        {
            using (SqlConnection conexion = new SqlConnection(this.dBOption.getItemOptions(name).ConnectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion)
                    {
                        CommandType = CommandType.Text,
                        CommandTimeout = 600000,
                    };
                    await conexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                    return true;
                }
                catch (SqlException error)
                {
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                    Logger.Error("Exception:  " + error.Message, error);
                    return false;
                }
            }
        }

        public async Task<DataTable> SelectStoredProcedure(string name, string query, List<SqlParameter> parameter)
        {
            DataTable consulta = new DataTable();
            using (SqlConnection conexion = new SqlConnection(this.dBOption.getItemOptions(name).ConnectionString))
            {
                try
                {
                    SqlConnection.ClearAllPools();
                    SqlDataAdapter comando = new SqlDataAdapter(query, conexion);
                    comando.SelectCommand.CommandType = CommandType.StoredProcedure;
                    comando.SelectCommand.CommandTimeout = 3600000;
                    foreach (SqlParameter item in parameter)
                    {
                        if (item.Value == null)
                        {
                            item.Value = DBNull.Value;
                        }

                        comando.SelectCommand.Parameters.Add(item);
                    }

                    await conexion.OpenAsync();
                    comando.Fill(consulta);
                }
                catch (SqlException error)
                {
                    Logger.Error("Exception:  " + error.Message, error);
                    throw;
                }
                finally
                {
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                }

                return consulta;
            }
        }

        public async Task<DataTable> Select(string name, string query)
        {
            DataTable consulta = new DataTable();
            using (SqlConnection conexion = new SqlConnection(this.dBOption.getItemOptions(name).ConnectionString))
            {
                try
                {
                    SqlConnection.ClearAllPools();
                    SqlDataAdapter comando = new SqlDataAdapter(query, conexion);
                    comando.SelectCommand.CommandType = CommandType.Text;
                    comando.SelectCommand.CommandTimeout = 3600000;
                    await conexion.OpenAsync();
                    comando.Fill(consulta);
                }
                catch (SqlException error)
                {
                    Logger.Error("Exception:  " + error.Message, error);
                }
                finally
                {
                    conexion.Close();
                    SqlConnection.ClearAllPools();
                }

                return consulta;
            }
        }
    }
}
