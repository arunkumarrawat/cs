using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// My DataTable
    /// </summary>
    public class MyDataTable : DataTable
    {
        /// <summary>
        /// My DataTable 
        /// </summary>
        public MyDataTable()
        {

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="t"></param>
        public void AddColumn(string name,Type t)
        {
            Columns.Add(name, t);
        }

        /// <summary>
        /// Add Rows
        /// </summary>
        /// <param name="values"></param>
        public void AddRows(params object[] values)
        {
            Rows.Add(values);
        }

        /// <summary>
        /// Get Changes
        /// </summary>
        /// <returns></returns>
        public DataTable GetChanges()
        {
            return GetChanges();
        }

        /// <summary>
        /// Sort By Column
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="isIncrease"></param>
        public DataTable SortByColumn(string columnName,bool isIncrease)
        {
            string increase = "DESC";
            if (isIncrease) increase = "ASC";

            //DataView view = new DataView(this);
            //view.Sort= string.Format("{0} {1}", columnName, increase);

            this.DefaultView.Sort = string.Format("{0} {1}", columnName, increase);
            return this.DefaultView.ToTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="isIncrease"></param>
        /// <param name="columnNameTwo"></param>
        /// <param name="isIncreaseTwo"></param>
        /// <returns></returns>
        public DataTable SortByTwoColumn(string columnName, bool isIncrease, string columnNameTwo, bool isIncreaseTwo)
        {
            string increase = "DESC";
            if (isIncrease) increase = "ASC";

            string increaseTwo = "DESC";
            if (isIncreaseTwo) increase = "ASC";

            //DataView view = new DataView(this);
            //view.Sort= string.Format("{0} {1}", columnName, increase);

            this.DefaultView.Sort = string.Format("{0} {1}, {2} {3}", columnName, increase, columnNameTwo, increaseTwo);
            return this.DefaultView.ToTable();
        }

        /// <summary>
        /// Dump To Output
        /// </summary>
        public void DumpToOutput()
        {
            foreach (DataRow dr in this.Rows)
            {
                foreach (DataColumn dc in this.Columns)
                {
                    System.Diagnostics.Trace.Write(dr[dc.ColumnName] + " ");
                }
                System.Diagnostics.Trace.WriteLine("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void DumpToOutput(DataTable input)
        {
            foreach (DataRow dr in input.Rows)
            {
                foreach (DataColumn dc in input.Columns)
                {
                    System.Diagnostics.Trace.Write(dr[dc.ColumnName] + " ");
                }
                System.Diagnostics.Trace.WriteLine("");
            }
        }
    }
}
