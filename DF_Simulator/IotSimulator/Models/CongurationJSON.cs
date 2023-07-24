using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class CongurationJSON
    {
        [JsonProperty("timerIntervalSecond")]
        public long TimerIntervalSecond { get; set; }

        [JsonProperty("dataFormat")]
        public string DataFormat { get; set; }

        [JsonProperty("Is_Background_Job")]
        public bool IsBackgroundJob { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("simulatorName")]
        public string SimulatorName { get; set; }
        [JsonProperty("sensor")]
        public string SensorName { get; set; }

        [JsonProperty("DataConfigurationlst")]
        public List<DataConfiguration> DataConfiguration { get; set; }
    }
}
