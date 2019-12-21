using System;
using System.IO;
using log4net;
using log4net.Config;
using System.Reflection;

namespace Web.Services
{
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger(typeof(Logger));
        public static void InitLogger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var separateIndex = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
            var logConfigPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, separateIndex) +
                             @"ConfigFiles/log4net.config";
            var logConfigFile = new FileInfo(logConfigPath);
            XmlConfigurator.Configure(logRepository, logConfigFile);
        }

    }
}