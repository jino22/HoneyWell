using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class Simulator_Config
    {

        [JsonProperty("id")] 
        public long id { get; set; }

        [JsonProperty("timestamp")]
        public string timestamp { get; set; }


        [JsonProperty("currentjobstatus")]
        public string currentjobstatus { get; set; }


        [JsonProperty("timer")]
        public int timer { get; set; }


        [JsonProperty("timertype")]
        public string timertype { get; set; }


        [JsonProperty("sensor")]
        public string sensor { get; set; }


        [JsonProperty("simulatorname")]
        public string simulatorname { get; set; }

        public string Action { get; set; } = "Start";
    }
}
