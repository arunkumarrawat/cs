using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
using MainLib;

namespace MainLibUnitTest
{
    [DataContract]
    class Person
    {
        [DataMember]
        internal string name;

        [DataMember]
        internal int age;
    }

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class JsonHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void PersonToJson()
        {
            Person p = new Person();
            p.name = "John";
            p.age = 42;

            JsonHelper jsonHelper = new JsonHelper();
            string result = jsonHelper.ObjectToJson<Person>(p);
            Console.WriteLine(result);
        }
    }
}
