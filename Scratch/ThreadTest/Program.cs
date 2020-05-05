using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        public static DataTable SQLConnect_command(string spName,params object[] parameterValues)
        {
            //Data Source=ip;Initial Catalog=dbname;
            DataTable dt = null;
            string connectToSQL = "Data Source=localhost;Initial Catalog=Firebird;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectToSQL))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spName";
                    //command.Parameters.Add("@int", SqlDbType.Int);
                    for(int i=0;i<parameterValues.Length;i++)
                        command.Parameters[i].Value = parameterValues[i];
                    using (SqlDataAdapter reader = new SqlDataAdapter(command))
                    {
                        dt = new DataTable();
                        reader.Fill(dt);
                    }
                }
            }
            return dt;
        }




        static void Main(string[] args)
        {
            //DataTable dt = SQLConnect_command();
            Thread t = new Thread(WriteY);          // Kick off a new thread
            t.Start();                               // running WriteY()

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) 
                Console.Write("x");
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) 
                Console.Write("y");
        }

        /*
         You can do the same thing almost as easily in C# 2.0 with anonymous methods:

        new Thread (delegate()
        {
          ...
        }).Start();
         */
    }
}
