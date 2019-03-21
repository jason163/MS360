using Castle.Core.Logging;
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace MS.Castle.Logging.Log4Net
{
    public class Log4NetLoggerFactory : AbstractLoggerFactory
    {
        internal const string DefaultConfigFileName = "log4net.config";
        private readonly ILoggerRepository _loggerRepository;

        public Log4NetLoggerFactory() : this(DefaultConfigFileName)
        {

        }

        public Log4NetLoggerFactory(string configFileName)
        {
            _loggerRepository = LogManager.CreateRepository(
                typeof(Log4NetLoggerFactory).GetTypeInfo().Assembly,
                typeof(log4net.Repository.Hierarchy.Hierarchy)
            );

            var log4NetConfig = new XmlDocument();
            log4NetConfig.Load(File.OpenRead(configFileName));
            XmlConfigurator.Configure(_loggerRepository, log4NetConfig["log4net"]);
        }

        public Log4NetLoggerFactory(string configFileName, bool reloadOnChange)
        {
            _loggerRepository = LogManager.CreateRepository(typeof(Log4NetLoggerFactory).GetTypeInfo().Assembly,
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            if (reloadOnChange)
            {
                XmlConfigurator.ConfigureAndWatch(_loggerRepository, new FileInfo(configFileName));
            }
            else
            {
                var log4netConfig = new XmlDocument();
                log4netConfig.Load(File.OpenRead(configFileName));
                XmlConfigurator.Configure(_loggerRepository, log4netConfig["log4net"]);
            }
        }

        public override ILogger Create(string name)
        {
            if(null == name)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return new Log4NetLogger(LogManager.GetLogger(_loggerRepository.Name, name), this);
        }

        public override ILogger Create(string name, LoggerLevel level)
        {
            throw new NotSupportedException("Logger levels cannot be set at runtime. Please review your configuration file.");
        }
    }
}
