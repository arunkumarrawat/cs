using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace SendMessageToNotepad
{
    class Program
    {

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);


        static void GetProcess(ref List<Process[]> handles)
        {
            handles.Clear();
            Process[] p1 = Process.GetProcessesByName("Pacom.Emcs.ProtocolService.ProtocolWindowsService");
            Process[] p2 = Process.GetProcessesByName("Pacom.ApplicationServer.WindowsService");
            Process[] p3 = Process.GetProcessesByName("Pacom.Emcs.MessageBus.Host");
            if (p1.Length == 1)
                handles.Add(p1);
            if (p2.Length == 1)
                handles.Add(p2);
            if (p3.Length == 1)
                handles.Add(p3);
        }
        static void Main(string[] args)
        {
            List<Process[]> handles = new List<Process[]>();

            //Pacom.Emcs.ProtocolService.ProtocolWindowsService
            //Pacom.Emcs.MessageBus.Host

            GetProcess(ref handles);
            while (handles.Count != 0)
            {
                foreach (Process[] p in handles)
                {
                    if (p.Length == 0) continue;
                    if (p[0] != null)
                    {
                        //IntPtr child = FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);
                        //SendMessage(child, 0x000C, 0, "Hello Notepad\r\nnext");// 0XC is WM_SETTEXT
                        //PostMessage(p[0].MainWindowHandle, 0x0100, 0x0D, 0);// 0XC is WM_SETTEXT
                        PostMessage(p[0].MainWindowHandle, 0x0012, 0, 0);
                    }
                }
                GetProcess(ref handles);
                Thread.Sleep(500);
            }
        }
    }
}
