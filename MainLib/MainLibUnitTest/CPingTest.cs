using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib.NMSocket;

namespace MainLibUnitTest
{
    /// <summary>
    /// Summary description for CPingTest
    /// </summary>
    [TestClass]
    public class CPingTest
    {
        public CPingTest()
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
        public void CPingMainTest()
        {
            //
            // TODO: Add test logic here
            //


        }

        [TestMethod]
        [Ignore]
        public void TestFtpServer()
        {
            NMSocketServer server = new NMSocketServer(21);
            int i = 1;
            while (i <= 6)
            {
                string receive = server.receive();



                if (string.IsNullOrEmpty(receive)) continue;

                Console.WriteLine(receive);

                if (receive.StartsWith("QUIT"))
                    server.closeHandler();

                if (receive.StartsWith("USER"))
                    server.send("331 need password\r\n");
                else
                    server.send("220 successfully\r\n");
            }

            server.close();
        }
    }
}
