using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;

namespace MainLibUnitTest
{
    /// <summary>
    /// Summary description for ReflectionUtilTest
    /// </summary>
    [TestClass]
    public class ReflectionUtilTest
    {
        [AttributeUsage(AttributeTargets.All)]
        public class HelpAttribute : System.Attribute
        {
            public string Topic   // Topic is a named parameter 
            {
                get
                {
                    return topic;
                }
                set
                {
                    topic = value;
                }
            }
            public HelpAttribute(string topic)   // url is a positional parameter 
            {
                this.topic = topic;
            }
            private string topic;

            public override string ToString()
            {
                return this.topic;
            }
        }

        [Help("Information on the class MyClass")]
        class MyClass
        {
            private int outputTest(int num)
            {
                return num * 2;
            }
        }
        public ReflectionUtilTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetCustomerAttributeTest()
        {
            //
            // TODO: Add test logic here
            //

            ReflectionUtil reflectionUtil = new ReflectionUtil();

            List<object> customerAttribute = reflectionUtil.GetCustomerAttribute(typeof(MyClass));
            foreach (object o in customerAttribute)
            {
                if (o is HelpAttribute)
                {
                    Console.WriteLine((o as HelpAttribute).Topic);
                }
            }
        }

        [TestMethod]
        public void InvokePrivateMethod()
        {
            MyClass myClass = new MyClass();

            ReflectionUtil reflectionUtil = new ReflectionUtil();
            int num = 567;
            object output = reflectionUtil.invokePrivateMethod(myClass, "outputTest", new object[] { num });
            Assert.AreEqual((int)output, 2 * num);
        }
    }
}
