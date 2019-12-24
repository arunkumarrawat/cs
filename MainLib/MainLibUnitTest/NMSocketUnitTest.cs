using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MainLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib.NMSocket;
using System.IO;

namespace MainLibUnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class NMSocketUnitTest
    {
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
        public void DownloadHtmlTest()
        {
            HtmlHelper h = new HtmlHelper();
            string fileName = "googletest.html";
            h.GetHtml(new Uri("http://www.google.com.au"), fileName);
            Assert.IsTrue(File.Exists(Path.Combine(Path.GetTempPath(), fileName)));
        }
    }
}
