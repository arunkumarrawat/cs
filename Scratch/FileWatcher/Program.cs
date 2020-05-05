using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileWatcher
{
    //@example: FileWatcher: watch file change in one folder.
    class Program
    {
        static void printHelp()
        {
            Console.WriteLine("File Watcher to certain Directory path");
            Console.WriteLine("fw [path]");
        }
        static void Main(string[] args)
        {
            //if (args.Length > 1 || args.Length == 0)
            //{
            //    printHelp();
            //    return;
            //}
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "C:\\";
            watcher.IncludeSubdirectories = true;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            using (TextWriter tw = new StreamWriter("D:\\workspace\\test\\FileWatcher.txt", true, Encoding.GetEncoding("UTF-8")))
            {
                // Specify what is done when a file is changed, created, or deleted.
                Console.WriteLine(DateTime.Now.ToString() + "File: " + e.FullPath + " " + e.ChangeType);
                tw.WriteLine(DateTime.Now.ToString() + "File: " + e.FullPath + " " + e.ChangeType);
                tw.Flush();
                tw.Close();
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            using (TextWriter tw = new StreamWriter("D:\\workspace\\test\\FileWatcher.txt", true, Encoding.GetEncoding("UTF-8")))
            {
                // Specify what is done when a file is renamed.
                Console.WriteLine(DateTime.Now.ToString() + "File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
                tw.WriteLine(DateTime.Now.ToString() + "File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
                tw.Flush();
                tw.Close();
            }
        }
    }
}
