using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MainLib
{
    /// <summary>
    /// This Class Contains All operation for Files
    /// </summary>
    public class NMFile
    {
        /// <summary>
        /// go though whole folder
        /// </summary>
        /// <param name="sDir"></param>
        void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        System.Diagnostics.Trace.WriteLine(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        /// <summary>
        /// This is very important, set file attributes to be normal
        /// if attribute is not normal, dir will be not able to deleted.
        /// </summary>
        /// <param name="dir">dir information</param>
        public static void setAttributesNormal(DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                setAttributesNormal(subDir);
                subDir.Attributes = FileAttributes.Normal;
            }
            foreach (var file in dir.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
            }
        }

        /// <summary>
        /// recursively delete all folder under folder
        /// </summary>
        /// <param name="startPath">start path</param>
        /// <param name="target">all files under start path</param>
        public static void DeleteAllFolder(string startPath, string target)
        {

            DirectoryInfo di = new DirectoryInfo(startPath);

            foreach (DirectoryInfo subfolder in di.GetDirectories())
            {
                if (subfolder.Name == target)
                {
                    setAttributesNormal(subfolder);
                    subfolder.Delete(true);
                }
                else
                {
                    DeleteAllFolder(subfolder.FullName, target);
                }
            }

        }

        /// <summary>
        /// Read Text File into string
        /// </summary>
        /// <param name="filePath">File Path</param>
        /// <returns>File content</returns>
        public string ReadAllTextFile(string filePath)
        {
            string content = string.Empty;
            try
            {
                content = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
            return content;
        }

        /// <summary>
        /// Write All Text File
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="context"></param>
        public void WriteAllTextFile(string filePath,string context)
        {
            try
            {
                File.WriteAllText(filePath, context);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        }

        /// <summary>
        /// File to List of string
        /// </summary>
        /// <param name="filePath">Path to File</param>
        /// <returns></returns>
        public List<string> FileToList(string filePath)
        {
            List<string> result = new List<string>();

            if((new FileInfo(filePath)).Exists == false)
            {
                return result;
            }

            string line= string.Empty;
            string output = string.Empty;
            int counter = 0;

            System.IO.StreamReader file =
               new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line);
                counter++;
            }

            return result;
        }

        /// <summary>
        /// Remove ReadOnly Attribute of One File
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteReadOnlyAttribute(string filePath)
        {
            try
            {
                FileAttributes attributes = File.GetAttributes(filePath);
                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                File.SetAttributes(filePath, attributes);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        }

        /// <summary>
        /// set ReadOnly Attribute of One File
        /// </summary>
        /// <param name="filePath"></param>
        public void SetReadOnlyAttribute(string filePath)
        {
            try
            {
                File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.ReadOnly);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        /// <summary>
        /// Copy from sourcePath to destinationPath, copy sourcePath destinationPath
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        public void Copy(string sourcePath, string destinationPath)
        {
            try
            {
                File.Copy(sourcePath, destinationPath);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        }

        /// <summary>
        /// Replace Title in the html file
        /// </summary>
        public void replaceTitle()
        {
            string path = @".";

            string[] files = Directory.GetFiles(path, "*.aspx", SearchOption.AllDirectories);
            int count = 0;
            foreach (string f in files)
            {
                //System.Diagnostics.Trace.WriteLine(f);
                string text = File.ReadAllText(f);

                Regex r = new Regex("<title>(.*)</title>");

                Match m = r.Match(text);

                if (m.Success)
                {
                    if (!string.IsNullOrEmpty(m.Groups[1].Value) && !m.Groups[1].Value.Contains("Title"))
                    {
                        //if (m.Groups[1].Value.Contains("AME Group")) System.Diagnostics.Trace.WriteLine(m.Groups[1].Value);
                        //System.Diagnostics.Trace.WriteLine(f + "##" + m.Groups[1].Value);
                        count++;
                        string title = string.Format("<title>Title - {0}</title>", m.Groups[1].Value);
                        File.WriteAllText(f, r.Replace(text, title));
                    }
                }

            }
        }


        #region Assembly File

        /// <summary>
        /// Get Executing Assembly Path
        /// </summary>
        /// <returns></returns>
        public string GetApplicationPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void ReadTextFileLineByLine(string path)
        {
            int counter = 0;
            string line;
            System.IO.StreamReader file =   new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void PrintModifiedDate(string path)
        {
            FileInfo f = new FileInfo(path);
            System.Diagnostics.Trace.WriteLine("Create Time: " + f.CreationTime);
            System.Diagnostics.Trace.WriteLine("Last Write time: " + f.LastWriteTime);
        }
        #endregion

        // for WriteCacheToFile
        static object fileLocker = new object();
        long StartPoint = 0;
        string DownloadPath = "test";
        long DownloadedSize = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="downloadCache"></param>
        /// <param name="cachedSize"></param>
        public void WriteCacheToFile(MemoryStream downloadCache, int cachedSize)
        {
            // Lock other threads or processes to prevent from writing data to the file.
            lock (fileLocker)
            {
                using (FileStream fileStream = new FileStream(DownloadPath, FileMode.Open))
                {
                    byte[] cacheContent = new byte[cachedSize];
                    downloadCache.Seek(0, SeekOrigin.Begin);
                    downloadCache.Read(cacheContent, 0, cachedSize);
                    fileStream.Seek(DownloadedSize + StartPoint, SeekOrigin.Begin);
                    fileStream.Write(cacheContent, 0, cachedSize);
                }
            }
        }
    }
}
