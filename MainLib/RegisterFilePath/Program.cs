using MainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            NMRegister nmRegister = new NMRegister();
            nmRegister.ContextMenu("Open with cmd", "cmd.exe /k cd %1");
        }
    }
}
