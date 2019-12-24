using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// DataTable 
    /// </summary>
    public class NMDataTable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NMDataTable()
        {
        }

        #region DataTable To XML
        /// <summary>
        /// Convert DataTable to XML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string DataTableToXML(DataTable dt)
        {
            StringWriter stringWriter = new StringWriter();
            dt.WriteXml(stringWriter);

            string xml = stringWriter.ToString();

            return xml;
        }

        /// <summary>
        /// Add New Row and Convert DataTable to XML
        /// </summary>
        private void DataTableToXMLTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("roomCode");
            dt.Columns.Add("roomNo");
            dt.Columns.Add("hotelCode");

            DataRow dr;

            dr = dt.NewRow();
            dr["roomCode"] = "1";
            dr["roomNo"] = "MKavs";
            dr["hotelCode"] = "222";

            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["roomCode"] = "2";
            dr["roomNo"] = "232";
            dr["hotelCode"] = "33";


            dt.Rows.Add(dr);

            DataSet ds = new DataSet("abc");
            ds.Tables.Add(dt);
            //write to file            
            dt.WriteXml("C:\\workspace\\awork\\1.xml");

            //write to string
            StringWriter stringWriter = new StringWriter();
            dt.WriteXml(stringWriter);

            string xml = stringWriter.ToString();
            System.Diagnostics.Debug.WriteLine(xml);
        }
        #endregion

        #region DataRow Comparing
        /// <summary>
        /// Compare Two DataRow
        /// </summary>
        /// <param name="rowOne"></param>
        /// <param name="rowTwo"></param>
        /// <returns></returns>
        public bool DataRowComparing(DataRow rowOne,DataRow rowTwo)
        {
            IEqualityComparer<DataRow> comparer = DataRowComparer.Default;

            bool isMatch = comparer.Equals(rowOne, rowTwo);

            return isMatch;
        }

        /// <summary>
        /// DataRow comparing Test
        /// </summary>
        public void DataRowComparingTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof (int));
            dt.Columns.Add("Name", typeof (string));

            dt.Rows.Add(1, "name 1");
            dt.Rows.Add(2, "name 2");
            dt.Rows.Add(1, "name 1");

            System.Diagnostics.Trace.WriteLine(DataRowComparing(dt.Rows[0], dt.Rows[1]));
            System.Diagnostics.Trace.WriteLine(DataRowComparing(dt.Rows[0], dt.Rows[2]));
        }

        /// <summary>
        /// to create a dataTable, inputDirec
        /// </summary>
        /// <param name="inputDictionary">Input Dictionary</param>
        /// <returns></returns>
        public DataTable CreateDataTable(Dictionary<string,Type> inputDictionary)
        {
            DataTable t = new DataTable();
            if (inputDictionary == null) return t;
            foreach (string s in inputDictionary.Keys)
            {
                //s is column, 
                t.Columns.Add(s, inputDictionary[s]);
            }
            return t;
        }

        #endregion

        #region DataTable Sort
        /// <summary>
        /// Sort By View
        /// </summary>
        /// <param name="locationTable">DataTable</param>
        /// <param name="columnName"></param>
        /// <param name="isASC"></param>
        /// <returns></returns>
        public DataTable SortByView(DataTable locationTable,string columnName, bool isASC)
        {
            if (locationTable.Columns.Contains(columnName) == false) return null;

            DataView view = new DataView(locationTable);

            // Sort by State and ZipCode column in descending order
            //view.Sort = "State ASC, ZipCode ASC";
            view.Sort = string.Format("{0} {1}",columnName,isASC? "ASC":"DESC");

            return view.ToTable();
        }

        /// <summary>
        /// Sort By Linq
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>s
        public DataTable SortByLinq<T>(DataTable dt,string columnName)
        {
            var newDataTable = dt.AsEnumerable()
                .OrderBy(r => r.Field<T>(columnName))
                .ThenBy(r=>r.Field<T>(columnName))
                .CopyToDataTable();

            return newDataTable;
        }

        /// <summary>
        /// Sort By DataView
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="sortExpression">Sort Expression</param>
        /// <returns></returns>
        public DataTable SortByDataView(DataTable dt, string sortExpression)
        {
            try
            {
                DataView view = new DataView(dt);
                view.Sort = sortExpression;
                return view.ToTable();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("sort Expression should be " + "'Make ASC, Year DESC'");
                throw ex;
            }
        }

        /// <summary>
        /// Copy DataTable 
        /// </summary>
        /// <param name="dt">Data Table</param>
        /// <returns></returns>
        public DataTable CopyDataTable(DataTable dt)
        {
            return dt.Copy();
        }

        /// <summary>
        /// IList to DataTable
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="data">list of Object</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        #endregion
    }
}
