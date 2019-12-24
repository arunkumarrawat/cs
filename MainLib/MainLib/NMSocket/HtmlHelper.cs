using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MainLib.NMSocket
{
    /// <summary>
    /// All html operation will be add here
    /// </summary>
    public class HtmlHelper
    {
        /// <summary>
        /// Download html from url
        /// </summary>
        /// <param name="url"></param>
        public void GetHtml(Uri url,string fileName)
        {
            string path = Path.GetTempPath();

            WebClient w = new WebClient();
            w.DownloadFile(url, Path.Combine(path, fileName));

        }

        /// <summary>
        /// Get Json from url
        /// </summary>
        /// <param name="url"></param>
        public void GetJson(Uri url)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId=PLrOp5jXaLI2L9hUTYB34tgUPlu17BtXmz&key=AIzaSyD03u-ME70x2z-AyE_lgU7tfyzF0QgbYE4&maxResults=50");
            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                var resp = request.GetResponse() as HttpWebResponse;
                if (resp != null)
                {
                    var resStream = resp.GetResponseStream();
                    if (resStream != null)
                    {
                        var reader = new StreamReader(resStream);
                        Console.Write(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.Write(string.Empty);
        }

        /// <summary>
        /// Get All Image Url from html
        /// </summary>
        /// <param name="strHtml"></param>
        public void ParseHtmlGetImage(string strHtml)
        {

        }
    }
}
