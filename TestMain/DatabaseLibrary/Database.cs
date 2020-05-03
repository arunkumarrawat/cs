using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLibrary
{
    /// <summary>
    /// Database connection Library
    /// </summary>
    public class Database
    {
        private string host;
        private string databaseName;
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public Database(string host,string databaseName)
        {
            this.host = host;
            this.databaseName = databaseName;
        }
        #endregion

        #region
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
                //Data Source=ip;Initial Catalog=dbname;
                DataSet ds = null;
                string connectToSQL = "Data Source=" + host + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
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
            string connectToSQL = "Data Source=" + host + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectToSQL))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(spName, connection))
                {
                    SqlTransaction transaction;

                    // Start a local transaction.
                    transaction = connection.BeginTransaction("SampleTransaction");

                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    command.Connection = connection;
                    command.Transaction = transaction;

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
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception transactionException)
                    {
                        transaction.Rollback();
                    }
                    connection.Close();
                    return 0;
                }
            }
        }
        #endregion
    }
}
