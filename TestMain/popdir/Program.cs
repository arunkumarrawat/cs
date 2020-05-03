using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace popdir
{
    class Program
    {

        // Get a handle to an application window.
        [DllImport("Kernel32.DLL", CharSet = CharSet.Unicode)]
        public static extern bool SetCurrentDirectory(string lpPathName);

        static void Main(string[] args)
		{

            string line;
            string output;
            int counter = 0;
            string temp = Path.GetTempPath();
            List<string> path = new List<string>();

            string txtFilePath = string.Format("{0}{1}.txt", temp, "00-11-22");

            if (File.Exists(txtFilePath))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(txtFilePath);
                while ((line = file.ReadLine()) != null)
                {
                    path.Add(line);
                    counter++;
                }

                file.Close();
            }
            else
            {
                var myFile = File.Create(txtFilePath);
                myFile.Close();
            }

            if (path.Count > 0)
            {
                //Directory.SetCurrentDirectory(path[path.Count - 1]);
                Environment.CurrentDirectory = path[path.Count - 1];
                SetCurrentDirectory(path[path.Count - 1]);
                FileSystem.ChDir(path[path.Count - 1]);

                Console.WriteLine(string.Format("{0} is poped", path[path.Count - 1]));

                path.RemoveAt(path.Count - 1);

                string outputString = string.Empty;

                foreach (string s in path)
                {
                    outputString += s + Environment.NewLine;
                }

                using (StreamWriter sw = new StreamWriter(txtFilePath))
                {
                    sw.Write(outputString);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                Console.WriteLine("Cache is empty");
            }
        }
    }
}
