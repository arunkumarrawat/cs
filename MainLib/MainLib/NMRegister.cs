using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace MainLib
{
    public class NMRegister
    {
        // TODO: add new key 
        // todo: delete key
        // create a new value with some type
        // delete a new vlaue with some type

        /// <summary>
        /// map CapsLock to Control
        /// restart may be required
        /// </summary>
        public void MapCapsLockToControlWindows7()
        {
            string Extension = "SYSTEM\\CurrentControlSet\\Control\\Keyboard Layout";
            RegistryKey rkey = Registry.LocalMachine.OpenSubKey(Extension,true);
            if (rkey != null)
            {
                rkey.SetValue("Scancode Map", new byte[] { 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 29, 00, 58, 00, 00, 00, 00, 00 });
            }
        }

        /// <summary>
        /// map CapsLock to Control
        /// restart may be required
        /// </summary>
        public void MapCapsLockToControlWindows8()
        {
            string Extension = "SYSTEM\\CurrentControlSet\\Control\\Keyboard Layout";
            RegistryKey rkey = Registry.LocalMachine.OpenSubKey(Extension,true);
            if (rkey != null)
            {
                rkey.SetValue("Scancode Map", new byte[] { 00, 00, 00, 00, 00, 00, 00, 00, 02, 00, 00, 00, 29, 00, 58, 00, 00, 00, 00, 00, 00, 00, 00, 00 });
            }
        }

        /// <summary>
        /// Add context menu for windows
        /// </summary>
        /// <param name="contextMenuTitle"> for example, "open with notepad"</param>
        /// <param name="executeCommand">notepad.exe %1</param>
        public void ContextMenu(string contextMenuTitle, string executeCommand)
        {
            string Extension = "*\\shell";
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(Extension, true);

            if(rkey!=null)
            {
                if (rkey.OpenSubKey(contextMenuTitle) == null)
                {
                    RegistryKey rContextMenu = rkey.CreateSubKey(contextMenuTitle).CreateSubKey("command");

                    rContextMenu.SetValue("", executeCommand);
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine(contextMenuTitle + " is existed");
                }
            }
        }

        public void ContextMenuTest()
        {
            ContextMenu("Open with notepad", "notepad.exe %1");
        }

        /// <summary>
        /// to list auto run 
        /// </summary>
        public Dictionary<string,string> ListAutorun()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            /*
             * HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run
             * HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
             * HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce
             * HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce
             */



            return result;
        }

        /// <summary>
        /// List regedit path
        /// </summary>
        /// <param name="regeditPath">HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run</param>
        /// <returns></returns>
        public Dictionary<string, string> ListKey(string regeditPath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            /*
             * HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run
             * HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run
             * HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\RunOnce
             * HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce
             */



            return result;
        }
    }
}
