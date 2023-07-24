using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTSimulator.Models
{
    public class BlobConfig
    {
        public string StorageConnection { get; set; } = "DefaultEndpointsProtocol=https;AccountName=honeywellpocfileupload;AccountKey=D+XFBuC5xyVjvbePyiEWIOmNgVS1gXTbKtgFv7CzkEZwwXn2OlzkIlWWRiGa/gqlOPOxSOsGyTD/+AStYjSyxA==;EndpointSuffix=core.windows.net";
        public string ContainerName { get; set; } = "autouploadpoc";
    }
}
