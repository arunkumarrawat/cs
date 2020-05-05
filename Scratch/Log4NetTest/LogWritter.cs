using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Log4NetTest
{
    public class LogWritter
    {
        private static ILog logger = null;

        private LogWritter()
        {

        }

        private static void Init()
        {
            string fileName = "app.config";//The path of filename.

            //LogWritter.config文件所在位置
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
            logger = LogManager.GetLogger("LogWritter");
        }

        public static void Debug(string str)
        {
            if (logger == null)
            {
                LogWritter.Init();
            }
            logger.Debug(str);
        }

        public static void Info(string str)
        {
            if (logger == null)
            {
                LogWritter.Init();
            }
            logger.Info(str);
        }



        public static void Error(string str)
        {
            if (logger == null)
            {
                LogWritter.Init();
            }
            logger.Error(str);
        }
    }
}
