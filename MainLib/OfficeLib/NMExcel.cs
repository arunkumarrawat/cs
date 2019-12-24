using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace OfficeLib
{
    /// <summary>
    /// NMExcel
    /// </summary>
    public class NMExcel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public DataTable ConnectToExcel(string excelPath)
        {
            DataTable result = null;
            try
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + excelPath + "';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "TestTable");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                result = DtSet.Tables[0];
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        /*
         * TODO: query multiTable
         */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        public DataTable ConnectToExcelNewVersion(string excelPath)
        {
            DataTable result = null;
            try
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0 Xml;HDR=NO;'";
                string sql = "SELECT * FROM [SheetName$]";
                OleDbConnection objConnection = new OleDbConnection(connectionString);
                OleDbDataAdapter oda = new OleDbDataAdapter(sql, objConnection);
                DataTable dt = new DataTable();
                oda.Fill(result);
                objConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        /// <summary>
        /// Connect to CSV
        /// </summary>
        /// <param name="csvPath">path to csv</param>
        /// <returns></returns>
        public DataTable ConnectToCSV(string csvPath)
        {
            DataTable dataTable = null;

            FileInfo file = new FileInfo(csvPath);

            using (OleDbConnection con =
                new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                                    file.DirectoryName + "\";Extended Properties='text;HDR=Yes;FMT=Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format
                    ("SELECT * FROM [{0}]", file.Name), con))
                {
                    con.Open();

                    // Using a DataReader to process the data
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the current reader entry...
                        }
                    }

                    // Using a DataTable to process the data
                    using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable("MyTable");
                        adp.Fill(tbl);

                        dataTable = tbl;

                        //foreach (DataRow row in tbl.Rows)
                        //{
                        //    // Process the current row...
                        //}
                    }
                }
            }
            return dataTable;
        }
    }
}
