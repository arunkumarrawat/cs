using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Ftp Operation
    /// </summary>
    public class CFtp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="fileName"></param>
        public void GetFtpFile(string URL,string fileName)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create(URL);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

                FtpWebResponse response = (FtpWebResponse) request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                var fileStream = File.Create(fileName);
                responseStream.Seek(0, SeekOrigin.Begin);
                responseStream.CopyTo(fileStream);
                fileStream.Close();
                //StreamReader reader = new StreamReader(responseStream);
                //Console.WriteLine(reader.ReadToEnd());
                //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
                //reader.Close();

                response.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL">URL</param>
        /// <param name="fileName">Target file path</param>
        /// <param name="username">User Name</param>
        /// <param name="password">Password</param>
        public void GetFtpFile(string URL, string fileName,string username, string password)
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // This example assumes the FTP site uses anonymous logon.
                request.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                var fileStream = File.Create(fileName);
                responseStream.Seek(0, SeekOrigin.Begin);
                responseStream.CopyTo(fileStream);
                fileStream.Close();
                //StreamReader reader = new StreamReader(responseStream);
                //Console.WriteLine(reader.ReadToEnd());
                //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
                //reader.Close();

                response.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public string GetFtpFileList(string URL)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string fileList = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return fileList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetFtpFileList(string URL,string userName,string password)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(userName, password);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string fileList = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return fileList;
        }
    }
}
