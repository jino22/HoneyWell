using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class ResponseModel
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("floor_ref_id")]
        public string floor_ref_id { get; set; }

        [JsonProperty("room_ref_id")]
        public string Room_ref_id { get; set; }

        [JsonProperty("timestamp")]
        public DateTime timestamp { get; set; }
        [JsonProperty("motion_detected")]
        public bool motion_detected { get; set; }
        [JsonProperty("humidity")]
        public float humidity { get; set; }
        [JsonProperty("temperature")]
        public float temperature { get; set; }
        [JsonProperty("iaq")]
        public float iaq { get; set; }
        [JsonProperty("sensor")]
        public string sensor { get; set; }

        [JsonProperty("device_type")]
        public string Device_Type { get; set; }
    }

}

