using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    internal class MyDataModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("simulatorname")]
        public string SimulatorName { get; set; }
        [JsonProperty("timer")]
        public long TimerIntervalSecond { get; set; }




        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }

        [JsonProperty("currentjobstatus")]
        public string currentjobstatus { get; set; }

        [JsonProperty("Sensor")]
        public string Sensor { get; set; }
        [JsonProperty("timertype")]
        public string timertype { get; set; }

        public string Status { get; set; } = "Start";
        // public string Status { get; set; }
    }
}
