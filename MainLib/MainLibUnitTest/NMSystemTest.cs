using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;

namespace MainLibUnitTest
{
    [TestClass]
    public class NMSystemTest
    {
        [TestMethod]
        public void ClipBoardSetTextTest()
        {
            //
            // TODO: Add test logic here
            //
            NMSystem system = new NMSystem();
            system.clipBoardSetText("add logic here");

        }
    }
}
