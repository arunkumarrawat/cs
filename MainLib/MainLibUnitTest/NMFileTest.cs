using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;
using System.IO;

namespace MainLibUnitTest
{
    [TestClass]
    public class NMFileTest
    {
        [TestMethod]
        public void NMFile_PrintModifiedDate()
        {
            NMFile f = new NMFile();
            f.PrintModifiedDate(Path.Combine(NMEnvironment.GetDownloadFolder(), "EpicInstaller-7.2.1.msi"));
        }
    }
}
