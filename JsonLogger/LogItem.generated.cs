using System;
using Newtonsoft.Json;

namespace JsonLogger
{
    public class LogItem
    {
        [JsonProperty("processSessionId")]
        public Guid ProcessSessionId { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("messageObject")]
        public string MessageObject { get; set; }

        [JsonProperty("renderedMessage")]
        public string RenderedMessage { get; set; }

        [JsonProperty("timestampUtc")]
        public DateTimeOffset TimestampUtc { get; set; }

        [JsonProperty("logger")]
        public string Logger { get; set; }

        [JsonProperty("thread")]
        public string Thread { get; set; }

        [JsonProperty("exceptionObject")]
        public object ExceptionObject { get; set; }

        [JsonProperty("exceptionObjectString")]
        public object ExceptionObjectString { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("identity")]
        public string Identity { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("pid")]
        public long Pid { get; set; }

        [JsonProperty("machineName")]
        public string MachineName { get; set; }

        [JsonProperty("workingSet")]
        public long WorkingSet { get; set; }

        [JsonProperty("osVersion")]
        public string OsVersion { get; set; }

        [JsonProperty("is64bitOS")]
        public bool Is64BitOs { get; set; }

        [JsonProperty("is64bitProcess")]
        public bool Is64BitProcess { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }

    public partial class Properties
    {
        [JsonProperty("log4net:Identity")]
        public string Log4NetIdentity { get; set; }

        [JsonProperty("log4net:UserName")]
        public string Log4NetUserName { get; set; }

        [JsonProperty("log4net:HostName")]
        public string Log4NetHostName { get; set; }
    }
}