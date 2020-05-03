using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace cpc
{
    static class Code
    {
        public static void OverwriteConsoleMessage(string message)
        {
            Console.CursorLeft = 0;
            int maxCharacterWidth = Console.WindowWidth - 1;
            if (message.Length > maxCharacterWidth)
            {
                message = message.Substring(0, maxCharacterWidth - 3) + "...";
            }
            message = message + new string(' ', maxCharacterWidth - message.Length);
            Console.Write(message);
        }

        public static void RenderConsoleProgress(int percentage)
        {
            RenderConsoleProgress(percentage, '#', ConsoleColor.Green, "");
        }

        public static void RenderConsoleProgress(int percentage, char progressBarCharacter,
                  ConsoleColor color, string message)
        {
            Console.CursorVisible = false;
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.CursorLeft = 0;
            int width = Console.WindowWidth - 1;
            int newWidth = (int)((width * percentage) / 100d);
            string progBar = new string(progressBarCharacter, newWidth) +
                  new string(' ', width - newWidth);
            Console.Write(progBar);
            if (string.IsNullOrEmpty(message)) message = "";
            Console.CursorTop++;
            OverwriteConsoleMessage(message);
            Console.CursorTop--;
            Console.ForegroundColor = originalColor;
            Console.CursorVisible = true;
        }
    }
    /// <summary>
    /// Copy implemented in C#
    /// </summary>
    class Program
    {
        const string replaceString = ")\r\n        {\r\n            System.Diagnostics.Trace.WriteLine(System.Threading.Thread.CurrentThread.Name + \" \" + System.DateTime.Now + \" \" + System.Environment.StackTrace + System.Environment.NewLine);";
        static Regex r = new Regex(@"\)\r\n        {", RegexOptions.Multiline);

        public static void GetAllDirList(string strBaseDir)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(strBaseDir);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] file = di.GetFiles();
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i].FullName.EndsWith(".cs")
                        && !(file[i].FullName.Contains("Test"))
                        )
                        CsharpPrint(file[i].FullName);
                }


                for (int i = 0; i < diA.Length; i++)
                {
                    GetAllDirList(diA[i].FullName);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format("Path {0} is too long", strBaseDir));
                return;
            }
        }

        public static void CsharpPrint(string filePath)
        {
            System.Diagnostics.Trace.WriteLine(filePath);

            string wholeTextFile = File.ReadAllText(filePath);

            if (r.IsMatch(wholeTextFile))
            {
                wholeTextFile = r.Replace(wholeTextFile, replaceString);
            }

            File.WriteAllText(filePath, wholeTextFile);
        }

        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                System.Diagnostics.TextWriterTraceListener s = new TextWriterTraceListener(args[1]);
                System.Diagnostics.Trace.Listeners.Add(s);
                System.Diagnostics.Trace.AutoFlush = true;
                GetAllDirList(args[0]);
            }
            else
            {
                Console.WriteLine("Help: dir output_file. Example: cpc.exe . output.txt");
                Console.WriteLine("cpc.exe C:\\path\\ C:\\path\\output.txt");
            }
        }
    }
}

