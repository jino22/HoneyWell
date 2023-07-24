using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class DataConfiguration
    {/// <summary>
     /// 
     /// </summary>
        [JsonProperty("Column_Name")]
        public string ColumnName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Data_Type")]
        public string DataType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Min_Length")]
        public string MinLength { get; set; }
        [JsonProperty("Max_Length")]
        public string MaxLength { get; set; }
    }
}
