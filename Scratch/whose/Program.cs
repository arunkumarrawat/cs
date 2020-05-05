using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;

namespace whose
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test Args
            if (args.Length == 0)
            {
                Helper.PrintHelp();
                return;
            }
            if (args[0] == "/?")
            {
                Helper.PrintHelp();
                return;
            }
            if (args[0] == "--help")
            {
                Helper.PrintHelp();
                return;
            }
            #endregion

            #region Test PATH Environment
            string paths = Environment.GetEnvironmentVariable("PATH");
            if (paths == null)
            {
                Console.WriteLine("PATH Environment did not existed");
                return;
            }
            #endregion

            #region Test PATHEXT

            string pathext = Environment.GetEnvironmentVariable("PATHEXT");
            if (pathext == null)
            {
                Console.WriteLine("PATHEXT Environment did not existed");
                return;
            }
            pathext = pathext.ToLower(CultureInfo.InvariantCulture);

            #endregion


            #region Deal With Path
            string[] path = paths.Split(';');
            List<string> pathList = new List<string>(path.Length);
            pathList.AddRange(path);
            pathList.Add(".");
            #endregion

            string[] execute = pathext.Split(';');

            DirectoryInfo info = new DirectoryInfo(".");

            #region Main Loop
            lock (info)
            {
                foreach (string pathItem in pathList)
                    foreach (string argsItem in args)
                    {
                        string filePath = string.Empty;

                        if (argsItem.Contains("."))
                        {
                            filePath = pathItem + "\\" + argsItem;
                            Helper.TestCurrentPath(filePath);
                        }
                        else
                        {
                            foreach (string executeItem in execute)
                            {
                                filePath = pathItem + "\\" + argsItem + executeItem;
                                Helper.TestCurrentPath(filePath);
                            }
                        }
                    }
            }
            #endregion

        }
    }
}
