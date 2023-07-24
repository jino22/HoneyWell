using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class BackgroundJobConfiguration
    {
        public string timerIntervalSecond { get; set; }
        public string dataFormat        { get; set; }
        public string timestamp { get; set; }
        public string sensor { get; set; }
        public string simulatorName { get; set; }
        public List<DataConfiguration> DataConfigurationlst { get; set; }
    }
}
