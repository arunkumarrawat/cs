using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// 
    /// </summary>
    public class CTypeCast
    {
        /// <summary>
        /// Case Collection To List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <returns></returns>
        public List<T> CollectionToList<T>(ICollection c)
        {
            if (c == null) return null;
            List<T> list = c.Cast<T>().ToList();
            return list;
        }

        /// <summary>
        /// Cast list to Collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public ICollection ListToCollection<T>(List<T> list)
        {
            if (list == null) return null;
            ICollection c = new Collection<T>(list);
            return c;
        }
    }
}
