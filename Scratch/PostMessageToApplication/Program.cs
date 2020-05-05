using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PostMessageToApplication
{
    //@example: C# - C# call FindWindowsEx and SendMessage native api
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        static void Main(string[] args)
        {
            Process[] p1 = Process.GetProcessesByName("firefox");
            if (p1.Length == 0) return;
            for(int i=0;i<p1.Length;i++)
            if (p1[i] != null)
            {
                PostMessage(p1[i].MainWindowHandle, 0x0012, 0, 0);// 0X12 is WM_QUIT
            }

        }
    }
}
