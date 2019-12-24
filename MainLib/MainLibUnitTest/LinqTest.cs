using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib.LINQ;

namespace MainLibUnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class LinqTest
    {
        public LinqTest()
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
        public void JoinTest()
        {
            Join join = new Join();
            join.GetCustomerTest();
        }

        [TestMethod]
        public void JoinLinq102()
        {
            Join join = new Join();
            join.Linq102();
        }

        [TestMethod]
        public void JoinLinq103()
        {
            Join join = new Join();
            join.Linq103();
        }


        [TestMethod]
        public void JoinLinq104()
        {
            Join join = new Join();
            join.Linq104();
        }


        [TestMethod]
        public void JoinLinq105()
        {
            Join join = new Join();
            join.Linq105();
        }

        [TestMethod]
        public void JoinLinq106()
        {
            Join join = new Join();
            join.Linq106();
        }

        [TestMethod]
        public void JoinLinq107()
        {
            Join join = new Join();
            join.Linq107();
        }

        [TestMethod]
        public void NumberOperation()
        {
            NumOperation numOperation = new NumOperation();
            int[] result = new int[7] { 1, 2,3 , 4, 5, 6 ,7 };
            IEnumerable<string>  integerArray = numOperation.IntegerLargeThan(ref result);
            foreach(string s in integerArray)
            {
                Console.WriteLine(s);
            }
        }
    }
}
