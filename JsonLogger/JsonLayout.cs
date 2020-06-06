﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using log4net.Core;
using log4net.Layout;
using log4net.Util;
using Newtonsoft.Json;

namespace JsonLogger
{
    public class JsonLayout : LayoutSkeleton
    {
        private static readonly string ProcessSessionId = Guid.NewGuid().ToString();
        private static readonly int ProcessId = Process.GetCurrentProcess().Id;

        public override void ActivateOptions()
        {
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            loggingEvent.Fix = FixFlags.All;
            var json = FormatJson(loggingEvent);
            writer.Write(json + Environment.NewLine);
        }

        protected string FormatJson(LoggingEvent e)
        {
            var dic = new Dictionary<string, object>
            {
                ["processSessionId"] = ProcessSessionId,
                ["level"] = e.Level.DisplayName,
                ["messageObject"] = e.MessageObject,
                ["renderedMessage"] = e.RenderedMessage,
                ["timestampUtc"] = e.TimeStamp.ToUniversalTime().ToString("O"),
                ["logger"] = e.LoggerName,
                ["thread"] = e.ThreadName,
                ["exceptionObject"] = e.ExceptionObject,
                ["exceptionObjectString"] = e.ExceptionObject == null ? null : e.GetExceptionString(),
                ["userName"] = e.UserName,
                ["domain"] = e.Domain,
                ["identity"] = e.Identity,
                ["location"] = e.LocationInformation.FullInfo,
                ["pid"] = ProcessId,
                ["machineName"] = Environment.MachineName,
                ["workingSet"] = Environment.WorkingSet,
                ["osVersion"] = Environment.OSVersion.ToString(),
                ["is64bitOS"] = Environment.Is64BitOperatingSystem,
                ["is64bitProcess"] = Environment.Is64BitProcess,
                ["properties"] = e.GetProperties()
            };
            return JsonConvert.SerializeObject(dic);
        }
    }
}