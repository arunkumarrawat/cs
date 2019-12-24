using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;

namespace MainLibUnitTest
{
    [TestClass]
    public class NMRegisterTest
    {
        [TestMethod]
        public void RegisterTest()
        {
            NMRegister register = new NMRegister();
            register.ContextMenuTest();
        }

        [TestMethod]
        public void RegisterWindows7CapToCtrl()
        {
            NMRegister register = new NMRegister();
            register.MapCapsLockToControlWindows7();
        }
    }
}
