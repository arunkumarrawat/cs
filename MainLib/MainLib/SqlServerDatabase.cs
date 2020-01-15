using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// SQL Server database operation
    /// </summary>
    public class SqlServerDatabase
    {
        private string host;
        private string databaseName;
        private string connectToSQL;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public SqlServerDatabase(string host, string databaseName)
        {
            this.host = host;
            this.databaseName = databaseName;

            connectToSQL = "Data Source=" + host + ";Initial Catalog=" + databaseName;
        }

        /// <summary>
        /// sql server database
        /// </summary>
        /// <param name="host"></param>
        /// <param name="databaseName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SqlServerDatabase(string host, string databaseName, string username, string password)
        {
            this.host = host;
            this.databaseName = databaseName;

            connectToSQL = "Data Source=" + host + ";Initial Catalog=" + databaseName + ";User ID=" + username + ";Password=" + password;
        }

        /// <summary>
        /// connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlServerDatabase(string connectionString)
        {
            //TODO: try to parse connection String
            this.host = "";
            this.databaseName = "";

            connectToSQL = connectionString;
        }

        /// <summary>
        /// read connection string from config file
        /// </summary>
        public SqlServerDatabase()
        {
            connectToSQL = ConfigurationManager
              .ConnectionStrings["db"]
              .ConnectionString;
        }

        #endregion

        #region

        /// <summary>
        /// Check wether database is connectable.
        /// </summary>
        /// <returns></returns>
        public bool isConnectable()
        {
            try
            {
                using (var cn = new SqlConnection(connectToSQL))
                {
                    cn.Open();
                    var version = cn.ServerVersion;
                    System.Diagnostics.Debug.WriteLine(version);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get Data From Database
        /// In: Stored Procedure Name, parameters
        /// Out: DataTable
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public DataSet SQLConnect_command(string spName, params object[] parameterValues)
        {
            try
            {
                // connection string example
                //Data Source=ip;Initial Catalog=dbname;
                DataSet ds = null;
                using (SqlConnection con = new SqlConnection(connectToSQL))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(spName, con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(command);
                        command.CommandText = spName;
                        //command.Parameters.Add("@int", SqlDbType.Int);
                        //foreach (SqlParameter p in command.Parameters)
                        //{
                        //    Console.WriteLine(p.ParameterName);
                        //}
                        command.Parameters.RemoveAt(0);
                        for (int i = 0; i < parameterValues.Length; i++)
                            command.Parameters[i].Value = parameterValues[i];
                        using (SqlDataAdapter reader = new SqlDataAdapter(command))
                        {
                            ds = new DataSet();
                            reader.Fill(ds);
                        }
                    }
                }
                return ds;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Execute Command Directly Without return DataTable
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public int SQLConnect_ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            //Data Source=ip;Initial Catalog=dbname;
            //string connectToSQL = "Data Source=localhost;Initial Catalog=Firebird;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectToSQL))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(spName, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(command);
                    command.CommandText = spName;
                    //command.Parameters.Add("@int", SqlDbType.Int);
                    foreach (SqlParameter p in command.Parameters)
                    {
                        Console.WriteLine(p.ParameterName);
                    }
                    command.Parameters.RemoveAt(0);
                    for (int i = 0; i < parameterValues.Length; i++)
                        command.Parameters[i].Value = parameterValues[i];

                    int result = command.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public void executesql(string sql)
        {
            SqlConnection conn = new SqlConnection(connectToSQL);
            conn.Open();
            string commandString = sql;//"select count(*) from IPRange";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                Console.WriteLine(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Execute sql and return datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable executesqlforDataTable(string sql)
        {
            DataTable dt = null ;
            SqlConnection conn = new SqlConnection(connectToSQL);
            conn.Open();
            string commandString = sql;//"select count(*) from IPRange";
            using (SqlCommand cmd = new SqlCommand(commandString, conn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt = new DataTable();
                    dt.Load(dr);
                    
                    return dt;
                }
            }
        }
        #endregion
    }
}
