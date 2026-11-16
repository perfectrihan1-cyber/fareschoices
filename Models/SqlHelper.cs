using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Viman.Models
{
    public class SqlHelper
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                builder.ConnectTimeout = 3;
                return new SqlConnection(builder.ConnectionString);
            }
            catch
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
        }
        public static SqlConnection GetConnectionFlightoffice()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConnectionStringFlightoffice"].ConnectionString);
                builder.ConnectTimeout = 3;
                return new SqlConnection(builder.ConnectionString);
            }
            catch
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringFlightoffice"].ConnectionString);
            }
        }
        private static DateTime _dbDisabledUntil = DateTime.MinValue;

        public static bool IsDbEnabled()
        {
            string enableDb = ConfigurationManager.AppSettings["EnableRemoteDb"];
            if (string.Equals(enableDb, "false", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return DateTime.UtcNow >= _dbDisabledUntil;
        }

        public static DataSet ExecuteDataset(string commandText, params SqlParameter[] commandParameters)
        {
            if (!IsDbEnabled())
            {
                return null;
            }

            try
            {
                SqlConnection connection = GetConnection();
                if (connection == null) return null;

                SqlCommand cmd = new SqlCommand();
                bool mustCloseConnection = false;

                if (connection.State != ConnectionState.Open)
                {
                    mustCloseConnection = true;
                    connection.Open();
                }
                else
                {
                    mustCloseConnection = false;
                }

                cmd.Connection = connection;
                cmd.CommandTimeout = 120;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                if (commandParameters != null)
                {
                    foreach (SqlParameter param in commandParameters)
                    {
                        if (param != null)
                        {
                            if ((param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Input) && (param.Value == null))
                            {
                                param.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(param);
                        }
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        connection.Close();

                    return ds;
                }
            }
            catch (Exception)
            {
                _dbDisabledUntil = DateTime.UtcNow.AddMinutes(5);
                return null;
            }
        }

        public static DataSet ExecuteDatasetFlightoffice(string commandText, params SqlParameter[] commandParameters)
        {
            if (!IsDbEnabled())
            {
                return null;
            }

            try
            {
                SqlConnection connection = GetConnectionFlightoffice();
                if (connection == null) return null;

                SqlCommand cmd = new SqlCommand();
                bool mustCloseConnection = false;

                if (connection.State != ConnectionState.Open)
                {
                    mustCloseConnection = true;
                    connection.Open();
                }
                else
                {
                    mustCloseConnection = false;
                }

                cmd.Connection = connection;
                cmd.CommandTimeout = 120;
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                if (commandParameters != null)
                {
                    foreach (SqlParameter param in commandParameters)
                    {
                        if (param != null)
                        {
                            if ((param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Input) && (param.Value == null))
                            {
                                param.Value = DBNull.Value;
                            }
                            cmd.Parameters.Add(param);
                        }
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();

                    da.Fill(ds);
                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        connection.Close();

                    return ds;
                }
            }
            catch (Exception)
            {
                _dbDisabledUntil = DateTime.UtcNow.AddMinutes(5);
                return null;
            }
        }
    }
}