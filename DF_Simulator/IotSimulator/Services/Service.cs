using IOTSimulator.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace IOTSimulator.Services
{
    public class Service
    {

        public T ReadJson<T>(string fileName)
        {
            String _CongurationJson = string.Empty;
            using (StreamReader r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                _CongurationJson = json.ToString();
            }
            var congurationJsonData = JsonConvert.DeserializeObject<T>(_CongurationJson.ToString());
            return congurationJsonData;
        }

        public bool IsConnectedToInternet()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public void PrettyWrite(Object obj, string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                List<Object> items = JsonConvert.DeserializeObject<List<Object>>(json);
                r.Close();
                items.Add(obj);
                var jsonString = JsonConvert.SerializeObject(items, Formatting.Indented).ToString();
                File.WriteAllText(fileName, jsonString);

            }
        }
        public async void PostCall(ResponseModel _SimulatorJson)
        {
            var _SimulatorJsonData = JsonConvert.SerializeObject(_SimulatorJson);
            // Call API here modify you code 
            var client = new RestClient("https://datafactory001.azurewebsites.net/api/data");
            // client.Authenticator = necw HttpBasicAuthenticator(username, password);
           
            var request = new RestRequest(); //need to add end point method get
            var fileName = $"..\\..\\..\\..\\ConfigurationFiles\\Sensor Data\\simulator data.json";
            Service service = new Service();
            if (service.IsConnectedToInternet())
            {
                var OfflineFile = service.ReadJson<List<ResponseModel>>(fileName);
                if (OfflineFile.Count > 0)
                {
                    var client1 = new RestClient("https://datafactory001.azurewebsites.net/api/listOfCommands");
                    var OfflineData = new RestRequest();
                    OfflineData.AddBody(OfflineFile);
                    client1.Post(OfflineData);

                    File.WriteAllText(fileName, "[]");

                }
                request.AddBody(_SimulatorJsonData);
                
                if(_SimulatorJsonData!=null)
                {
                    try
                    {
                        var response = client.Post(request);
                        var content = response.Content;
                    }
                    catch (Exception)
                    {

                        
                    }
                }
            }
            else
            {
                //service.PrettyWrite(_SimulatorJson, fileName);
            }
        }






        // Create the main method that runs the background jobs:




        //In your application's entry point (e.g.,  Main  method or an API endpoint), call the  RunBackgroundJobs  method:


        public string GetDataDir()
        {
            var d = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var segments = d.Split(new char[] { Path.DirectorySeparatorChar });

            // data dir is up 4 levels
            // <solution/testing/TestData
            // remove the four last segments and add test data
            var segmentCount = segments.Length;
            var endSegment = segmentCount-4;
            var path = segments[0];
            for (int i = 1; i < endSegment; i++)
            {
                path = path + Path.DirectorySeparatorChar + segments[i];
            }

            path = path + Path.DirectorySeparatorChar;
            return path;
        }


        public async Task< Stream> ConvertListToStream(List<Simulator_Config> list)
        {
            // Create a memory stream to hold the serialized data
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                // Create a binary formatter
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                // Serialize the list into the memory stream
                binaryFormatter.Serialize(memoryStream, list);

                // Reset the memory stream position to the beginning
                memoryStream.Position = 0;

                // Return the memory stream as a stream
                return memoryStream;
            }
        }




    }
}
