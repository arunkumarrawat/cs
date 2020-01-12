using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MainLib
{
    /// <summary>
    /// @todo: add Json Helper with C#
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// Object to Json String
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="t">Object with Type</param>
        /// <returns></returns>
        public string ObjectToJson<T> (T t)
        {
            MemoryStream stream1 = new MemoryStream();

            //Serialize the Person object to a memory stream using DataContractJsonSerializer.
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(stream1, t);

            //Show the JSON output.
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }
    }
}
