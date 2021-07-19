using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace XuMvc
{
    public class LogHelper
    {
        private static ILog logger = null;
        public static void LogInfo(string logstr)
        {
            if (InitLog4net())
                logger.Info(logstr);
        }

        public static void LogInfo(string format, params object[] args)
        {
            if (InitLog4net())
                logger.InfoFormat(format, args);
        }

        public static void LogError(string logstr)
        {
            if (InitLog4net())
                logger.Error(logstr);
        }

        public static void LogError(string format, params object[] args)
        {
            if (InitLog4net())
                logger.ErrorFormat(format, args);
        }

        private static object objlock = new object();//初始化log用的锁
        private static bool InitLog4net()
        {
            if (logger != null)
                return true;
            lock (objlock)
            {
                if (logger == null)
                {
                    ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
                    XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
                    logger = LogManager.GetLogger(repository.Name, "NETCorelog4net");
                    return true;
                }
            }
            return false;
        }
    }
}
