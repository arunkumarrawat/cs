using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib;

namespace RegisterNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This program would write contect menu 'Open with notepad' to open file using notepad");
                NMRegister nmRegister = new NMRegister();
                nmRegister.ContextMenuTest();
                Console.WriteLine("Register successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
