using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonLogger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));
            XmlConfigurator.ConfigureAndWatch(logRepository, new FileInfo("Log4NetConfig.xml"));
            var log = LogManager.GetLogger(Assembly.GetEntryAssembly()?.EntryPoint.DeclaringType ?? typeof(Program));

            log.Info($"Logging started at {DateTime.Now}");
            log.Warn($"Eine Warnung {DateTime.Now}");
            log.Error($"Fehler  {DateTime.Now}");
            log.Fatal($"Game Over {DateTime.Now}");

            var lines = File.ReadAllLines("JsonFormatLogFile.log");
            var logList = lines.ToList().Select(x => JsonConvert.DeserializeObject<LogItem>(x)).ToList();
            Debugger.Break();
        }
    }
}