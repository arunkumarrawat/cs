using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace pushdir
{
    class Program
    {
        /*
         * pushd .

(setq xmlfilePath (concat temppath "000-111.txt"))
(setq listOfFile "")
(if (file-exists xmlfilePath)
    (setq listOfFile (load-path-from-xml xmlfilePath))
)

(setq newPath args[0])
(concat listOfFile newPath)
(save-list-to-xml listOfFile xmlfilePath)

popd

         * */
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

            string directoryPath = Directory.GetCurrentDirectory();

            path.Add(directoryPath);
            Console.WriteLine(string.Format("{0} is pushed into cache", directoryPath));

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
    }
}
