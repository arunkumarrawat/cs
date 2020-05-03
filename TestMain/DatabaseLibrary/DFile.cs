using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DatabaseLibrary
{
    public class DFile : IDisposable
    {
        /// <summary>
        /// show the percent of copying process.
        /// </summary>
        private long percent = 0;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public DFile()
        {

        }
        #endregion

        /// <summary>
        /// this property may need to read in multithread environment.
        /// </summary>
        public long Percent
        {
            get { return percent; }
        }
        /// <summary>
        /// (Copy-File Src Des)
        /// </summary>
        /// <param name="pathFrom"></param>
        /// <param name="pathTo"></param>
        /// <returns></returns>
        public int CopyFile(string pathSource, string pathNew)
        {
            if (File.Exists(pathSource) == false)
            {
                return 1;
            }

            //Regex r = new Regex("^([a-zA-Z]:)?(\\[^<>:\"/\\|?*]+)+\\?$");
            //Match m = r.Match(pathNew);

            const int BufferLength = 1000;
            try
            {

                using (FileStream fsSource = new FileStream(pathSource,
                    FileMode.Open, FileAccess.Read))
                {
                    // Read the source file into a byte array.
                    byte[] bytes = new byte[BufferLength];
                    long numBytesToRead = fsSource.Length;

                    long offset = 0;

                    FileStream fsNew = new FileStream(pathNew,
                        FileMode.Create, FileAccess.Write);

                    while (offset < fsSource.Length)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, 0, BufferLength);
                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;
                        fsNew.Write(bytes, 0, n);
                        fsSource.Seek(n, SeekOrigin.Current);
                        fsNew.Seek(n, SeekOrigin.Current);
                        offset += n;
                        percent = offset * 100 / fsSource.Length;
                    }

                    fsSource.Close();
                    fsNew.Close();
                    fsSource.Dispose();
                    fsNew.Dispose();
                    bytes = null;
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
                throw ioEx;
            }
            return 0;
        }
        /*
         * 1. get name list of folder
         *    x = getListOfFolder()
         *    
         *    foreach i in x
         *      if i is dir
         *         if i.name = ".svn" then
         *            delete i
         *         else
         *            recursion(i)
         *         end if
         *      end if
         *    endforeach
         * 
         * */
        /// <summary>
        /// path is the parent folder which contains folername in the subdir.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public int RecursionDelete(string path,string folderName)
        {
            
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int RecursionDir(string path)
        {
            string[] directories = Directory.GetDirectories(path);

            return 0;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose Member and Field
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
    }
}
