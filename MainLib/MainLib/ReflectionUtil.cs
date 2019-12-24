using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace MainLib
{
    public class ReflectionUtil
    {
        public Assembly LoadAssembly(string assemblyName)
        {
            try
            {
                return Assembly.Load(assemblyName);
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                return null;
            }
        }

        public object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters);
        }

        /// <summary>
        /// GetNamespace
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string GetNamespace<T>()
        {
            return typeof(T).Namespace;
        }

        /// <summary>
        /// Get NameSpace
        /// </summary>
        public void GetNamespaceTest()
        {
            System.Diagnostics.Trace.WriteLine(GetNamespace<DataTable>());
        }

        public List<object> GetCustomerAttribute(Type type)
        {
            System.Reflection.MemberInfo info = type;

            List<object> customerAttribute = new List<object>();
            object[] attributes = info.GetCustomAttributes(true);

            for (int i = 0; i < attributes.Length; i++)
            {
                customerAttribute.Add(attributes[i]);
            }

            return customerAttribute;
        }

        /// <summary>
        /// invoke private method of a class method
        /// </summary>
        /// <param name="o">new object(); as a new instance</param>
        /// <param name="methodName">method name</param>
        /// <param name="methodParams">method params</param>
        public object invokePrivateMethod(object o, string methodName, object[] methodParams)
        {
            MethodInfo dynMethod = o.GetType().GetMethod(methodName,
    BindingFlags.NonPublic | BindingFlags.Instance);
            return dynMethod.Invoke(o, methodParams);
        }

        /// <summary>
        /// Generic Set Property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public T SetPropertyValue<T>(string propertyName, object value)
        {
            PropertyInfo property = null;

            T genericType = Activator.CreateInstance<T>();

            property = genericType.GetType().GetProperty(propertyName);

            property.SetValue(genericType, value, null);

            return genericType;
        }


        /// <summary>
        /// Set Property Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="genericTypeObject"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetPropertyValue<T>(T genericTypeObject, string propertyName, object value)
        {
            PropertyInfo property = null;

            property = genericTypeObject.GetType().GetProperty(propertyName);

            property.SetValue(genericTypeObject, value, null);
        }

        /// <summary>
        /// List All Class , According to string
        /// </summary>
        /// <param name="assemblyName">Assembly Name</param>
        public List<string> ListAllClass(string assemblyName)
        {
            List<string> dllList = new List<string>();
            Assembly mscorlib = LoadAssembly(assemblyName);
            foreach (Type type in mscorlib.GetTypes())
            {
                dllList.Add(type.FullName);
            }

            return dllList;
        }

        /// <summary>
        /// Clone a Object completely
        /// </summary>
        /// <typeparam name="T">Clone Object</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("message");//, "paramName"));
            }

            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

    }
}
