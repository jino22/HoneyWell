using IOTSimulator.Helpers;
using IOTSimulator.Models;
using IOTSimulator.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Data;
using System.Text;
using DataTable = System.Data.DataTable;
using File = System.IO.File;

namespace IOTSimulator
{
    public partial class frmBGJobsStatus : System.Windows.Forms.Form
    {

        List<Simulator_Config> Simulator_Configs = new List<Simulator_Config>();
        bool _flage = true;
        float _humidity = 52.17f;
        float _temperature = 20.64f;
        float _iaq = 1.829f;
        List<Object> list = new List<Object>();
        Service service = new Service();

        List<Simulator_Config> congurationJsonData = new List<Simulator_Config>();
        private static System.Timers.Timer _timer;


        BlobStorage blobStorage = new BlobStorage();


       // public string fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\Sensor Data\simulator data.json"); // + fileNamePath; //read the file dynamic

        public string CSVFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\BgFile.csv");

        private async void frmBGJobsStatus_Load_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            List<Simulator_Config> excelData = await GetNewJsonValue();
            dataGridView1.DataSource = excelData;
            //timer
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; // Currently set to 1 minutes
            timer.Elapsed += (sender, e) => timer_Elapsed(sender, e);
            timer.Start();
            getBackgroundStatus();

        }
        //public DataTable readCSV(string filePath)
        //{
        //    String fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\Simulator_Config.json");// + fileNamePath; //read the file dynamic
        //    String _CongurationJson = string.Empty;
        //    using (StreamReader r = new StreamReader(fileName))
        //    {
        //        var json = r.ReadToEnd();
        //        _CongurationJson = json.ToString();
        //    }
        //    var congurationJsonData = JsonConvert.DeserializeObject<List<Simulator_Config>>(_CongurationJson.ToString());

        //    // string _SimulatorName =  congurationJsonData.SimulatorName;
        //    // long _TimerIntervalSecond = congurationJsonData.TimerIntervalSecond;

        //    return dt;
        //}
        private async Task<List<Simulator_Config>> GetNewJsonValue()
        {
            //String fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\Simulator_Config.json");// + fileNamePath; //read the file dynamic
            //String appSettings = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\appsettings.json");
            //var config = service.ReadJson<BlobConfig>(appSettings);
            var config = new BlobConfig();
            BlobStorage blobStorage = new BlobStorage();
            //var blobStream= blobStorage.GetDocument<List<Simulator_Config>>(config.StorageConnection,config.ContainerName,"Simulator_Config.json");

            var congurationJsonData = await blobStorage.GetDocument<List<Simulator_Config>>(config.StorageConnection, config.ContainerName, "Simulator_Config.json");

            // string _SimulatorName =  congurationJsonData.SimulatorName;
            // long _TimerIntervalSecond = congurationJsonData.TimerIntervalSecond;

            List<Simulator_Config> Simulator_Configs = new List<Simulator_Config>();
            Simulator_Config Simulator_Config;
            for (int i = 0; i < congurationJsonData.Count; i++)
            {
                Simulator_Config = new Simulator_Config();
                Simulator_Config.id = congurationJsonData[i].id;
                Simulator_Config.timestamp = congurationJsonData[i].timestamp;
                Simulator_Config.currentjobstatus = congurationJsonData[i].currentjobstatus;
                Simulator_Config.timertype = congurationJsonData[i].timertype;
                Simulator_Config.simulatorname = congurationJsonData[i].simulatorname;
                Simulator_Config.timer = congurationJsonData[i].timer;
                Simulator_Config.sensor = congurationJsonData[i].sensor;
                Simulator_Configs.Add(Simulator_Config);
            }


            StreamReader streamReader;


            ////var mydataFile = "../../../configure/BgFile.csv";
            //var mydataFile = @"D:\IOT\Final\IotSimulator\ConfigurationFiles\BgFile.csv";

           

            return Simulator_Configs;
        }

        //private List<Simulator_Config> GetNewCSVValue()
        //{
        //    StreamReader streamReader;


        //    ////var mydataFile = "../../../configure/BgFile.csv";
        //    //var mydataFile = @"D:\IOT\Final\IotSimulator\ConfigurationFiles\BgFile.csv";

        //    if (File.Exists(fileName))
        //    {
        //        try
        //        {
        //            streamReader = File.OpenText(fileName);

        //            //while (!streamReader.EndOfStream)
        //            //{
        //            var valueLine = streamReader.ReadLine();

        //            Simulator_Config = new Simulator_Config();

        //                var csvValues = valueLine.Split(',');
        //                if (csvValues != null)
        //                {
        //                    //Simulator_Config.JobName = csvValues[0];
        //                    //Simulator_Config.TimeInterval = csvValues[1];
        //                    //Simulator_Config.Status = csvValues[2];
        //                    //Simulator_Configs.Add(Simulator_Config);
        //                }



        //            streamReader.Close();
        //            streamReader = null;


        //        }
        //        catch (Exception ex)
        //        {
        //            streamReader = null;
        //        }
        //    }

        //    return Simulator_Configs;
        //}


        public DataTable readCSV(string filePath)
        {
            var dt = new DataTable();
            // Creating the columns
            File.ReadLines(filePath).Take(1)
                .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Replace("\"", "").Trim()));

            // Adding the rows
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(','))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));

            return dt;
        }



        public frmBGJobsStatus()
        {

            InitializeComponent();

            StartAutoRefresh();

            //BackGroundJobs();
           
        }

        
        public async Task RunBackgroundJob(Simulator_Config job)
        {
            while (job.currentjobstatus == "Started")
            {
                await Task.Delay(job.timer);

                //string appsettings = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\", "appsettings.json"); // + fileNamePath; //read the file dynamic
                //var config = service.ReadJson<BlobConfig>(appsettings);
                var config = new BlobConfig();
                var doc =await blobStorage.GetDocument<CongurationJSON>(config.StorageConnection, config.ContainerName, job.simulatorname + ".json");
                RunBackGroundJob(job.sensor, job.simulatorname, doc.DataConfiguration);
            }
        }



        public async void BackGroundJobs()
        {
            while (_flage && service.IsConnectedToInternet())
            {
                //1st get.
                var config = new BlobConfig();
                //var congurationJsonData = await blobStorage.GetDocument<List<Simulator_Config>>(config.StorageConnection, config.ContainerName, "Simulator_Config.json");
                RunBackgroundJobs(congurationJsonData);
                await Task.Run(() =>
                {
                    //string appsettings = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\", "appsettings.json"); // + fileNamePath; //read the file dynamic
                    //var config = service.ReadJson<BlobConfig>(appsettings);
                    
                   
                    //string fileName = @"..\..\..\..\ConfigurationFiles\Simulator_Config.json";// + fileNamePath; //read the file dynamic
                    //jobList = service.ReadJson<List<Simulator_Config>>(fileName);
                    //to run background job after fix interval of time 

                    Thread.Sleep(Convert.ToInt32(10000));
                });
                
            }
        }
        public async Task RunBackgroundJobs(List<Simulator_Config> jobList)
        {
            var tasks = new List<Task>();

            foreach(var jobs in jobList)
            {
                if (jobs.currentjobstatus == "Started")
                {
                    RunBackgroundJob(jobs);
                }
            }

            //Task.WhenAll(tasks);
        }

        private void StartAutoRefresh()
        {
            Console.WriteLine("Start the Datafetch " + DateTime.Now);


            if (_timer == null)
            {
                int dataFetchInterval = 1;

                dataFetchInterval = dataFetchInterval * 1000;

                _timer = new System.Timers.Timer(dataFetchInterval);
                //    _timer.Elapsed += new ElapsedEventHandler(FetchTripsOfTheWeek);

                _timer.Interval = dataFetchInterval;
                _timer.Enabled = true;
            }
            else
            {
                _timer.Enabled = true;
            }

        }
        private async void StartJob(string simulatorName, string sencerNmae)
        {

            _flage = true;

            //write update simulatordetails file Honi code add here 
            // string fileNamePath = "";
            //String appSettings = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\appsettings.json");
            //var config = service.ReadJson<BlobConfig>(appSettings);
            var config = new BlobConfig();
            var congurationJsonData = await blobStorage.GetDocument<CongurationJSON>(config.StorageConnection, config.ContainerName, simulatorName);

            string _FileDataFormat = congurationJsonData.DataFormat;
            long _TimerIntervalSecond = congurationJsonData.TimerIntervalSecond;
            bool _IsBackgroundJob = congurationJsonData.IsBackgroundJob;
            string _Timestamp = congurationJsonData.Timestamp;
            string _SimulatorName = congurationJsonData.SimulatorName;
            string _SensorName = congurationJsonData.SensorName;
            List<DataConfiguration> _DataConfiguration = congurationJsonData.DataConfiguration;
            //Random rnd = new Random();
            while (_flage)
            {
                await Task.Run(() =>
                {
                    //label1.BeginInvoke(delegate { label1.Text = rnd.Next().ToString(); });
                    //Thread.Sleep(1000);

                    RunBackGroundJob(_SensorName, _SimulatorName, _DataConfiguration);
                    Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000);
                    string _timerType = "";
                    if (_timerType.ToLower() == "default")
                    {
                        // Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000);
                    }
                    else if (_timerType.ToLower() == "milliseconds")
                    {
                        Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond));
                    }
                    else if (_timerType.ToLower() == "seconds")
                    {
                        Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000);
                    }
                    else if (_timerType.ToLower() == "minutes")
                    {
                        Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000 * 60);
                    }
                    else if (_timerType.ToLower() == "hours")
                    {
                        Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000 * 60 * 60);
                    }

                });

            }
        }

        public void StopAutoRefresh()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Dispose();
                _timer = null;
            }
        }

        string appLocation = System.IO.Directory.GetCurrentDirectory();

        private void ReadCSVData()
        {
            //var newCSVDataRows = GetNewCSVValue();
            //if (newCSVDataRows != null)
            //{
            //    Simulator_Configs.AddRange(newCSVDataRows);
            //}
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_humidity == 52.17f) { _humidity = 51.17f; }
            else
            { _humidity = 52.17f; }

            if (_temperature == 20.64f) { _temperature = 21.64f; }
            else
            { _temperature = 20.64f; }
            if (_iaq == 1.829f) { _iaq = 1.929f; }
            else
            { _iaq = 1.829f; }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {

            _flage = true;
            String fileName = @"..\..\..\..\ConfigurationFiles\Printer-HRHWTG2023.json";// + fileNamePath; //read the file dynamic
            String _CongurationJson = string.Empty;
            using (StreamReader r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                _CongurationJson = json.ToString();
            }
            var congurationJsonData = JsonConvert.DeserializeObject<CongurationJSON>(_CongurationJson.ToString());
            string _FileDataFormat = congurationJsonData.DataFormat;
            long _TimerIntervalSecond = congurationJsonData.TimerIntervalSecond;
            bool _IsBackgroundJob = congurationJsonData.IsBackgroundJob;
            string _Timestamp = congurationJsonData.Timestamp;
            string _SimulatorName = congurationJsonData.SimulatorName;
            string _SensorName = congurationJsonData.SensorName;
            List<DataConfiguration> _DataConfiguration = congurationJsonData.DataConfiguration;
            //Random rnd = new Random();
            while (_flage)
            {
                await Task.Run(() =>
                {

                    //label1.BeginInvoke(delegate { label1.Text = rnd.Next().ToString(); });
                    //Thread.Sleep(1000);
                    //RunBackgroundJob(_SensorName, _SimulatorName, _DataConfiguration);


                    Thread.Sleep(Convert.ToInt32(_TimerIntervalSecond) * 1000);
                });

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _flage = false;
        }

        public void TimerBackGroundJob()
        {

            //Parallel.ForEach()
        }


        private void RunBackGroundJob(string sensorName, string simulatorName, List<DataConfiguration> dataConfiguration)
        {
            ResponseModel _SimulatorJson = new ResponseModel();
            Random rnd = new Random();
            Service service = new Service();
            _SimulatorJson.id = sensorName + rnd.Next(10).ToString();
            _SimulatorJson.floor_ref_id = "1";
            _SimulatorJson.Room_ref_id = "IGK61A03";
            _SimulatorJson.timestamp = DateTime.Now;
            _SimulatorJson.motion_detected = false;
            _SimulatorJson.sensor = sensorName;
            _SimulatorJson.Device_Type = simulatorName;

            foreach (var y in dataConfiguration)
            {
                if (y.DataType.ToLower() == "int" || y.DataType.ToLower() == "long" || y.DataType.ToLower() == "float"||y.DataType.ToLower()=="decimal")
                {
                    if (y.ColumnName.ToLower().Contains("humidity"))
                    {
                        _SimulatorJson.humidity = _humidity + 1;
                    }
                    else if (y.ColumnName.ToLower().Contains("temperature"))
                    {
                        _SimulatorJson.temperature = _temperature + 1;
                    }
                    else if (y.ColumnName.ToLower() == "iaq")
                    {
                        _SimulatorJson.iaq = _iaq;
                    }
                }
                else if (y.DataType.ToLower() == "datetime" || y.DataType.ToLower() == "date")
                {
                    _SimulatorJson.timestamp = DateTime.Now;
                }

            }
            service.PostCall(_SimulatorJson);
        }

        private async void StopJob(string simulatorName, string sencerNmae)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<DataConfiguration> _DataConfiguration = new List<DataConfiguration>();

            DataGridViewButtonColumn sitemapButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Status",
                Text = "Start",
                UseColumnTextForButtonValue = true,
                DataPropertyName = "Status",
                FillWeight = 7,
                Width = 75
            };
            //    if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //  e.RowIndex >= 0 &&
            //  e.ColumnIndex == dataGridView1.Columns["Status"].Index)
            //    {
            //        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Start")
            //        {
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Running";
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.OrangeRed;
            //            var simulatorName = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            //            var sencerNmae = dataGridView1.Rows[e.RowIndex].Cells[6].Value;

            //            if (simulatorName != null && !simulatorName.ToString().ToLower().Contains(".json"))
            //            {
            //                simulatorName = simulatorName + ".json";
            //            }

            //            //write update simulatordetails file Hani code add here 

            //            StartJob(simulatorName.ToString(), sencerNmae.ToString());
            //        }
            //        else
            //        {
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Stop";
            //            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            //            var simulatorName = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            //            var sencerNmae = dataGridView1.Rows[e.RowIndex].Cells[6].Value;

            //            //write update simulatordetails file Hani code add here 

            //            StopJob(simulatorName.ToString(), sencerNmae.ToString());
            //        }

            //        if (dataGridView1.Rows.Count > 0)
            //        {
            //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //            {
            //                if (dataGridView1.Rows[i].Cells.Count > 0)
            //                {
            //                    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
            //                    {
            //                        switch (j)
            //                        {
            //                            case 1:

            //                                Console.WriteLine("dataGridView1");
            //                                break;
            //                            case 2: break;
            //                            case 3: break;
            //                            case 4: break;
            //                            case 5: break;
            //                        }

            //                    }
            //                }
            //            }
            //        }
            //    }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                UpdateFile();
            }
        }

        private void updateBlobDetails(Simulator_Config simulator_Config)
        {
            var client1 = new RestClient("https://datafactory001.azurewebsites.net/api/json");
            var OfflineData = new RestRequest();
            OfflineData.AddBody(simulator_Config);
            client1.Put(OfflineData);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
           e.RowIndex >= 0 &&
           e.ColumnIndex == dataGridView1.Columns["Action"].Index)
            {
                var simulatorName = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                var timerType = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                var sensorName = dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                var currentjobstatus = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                var timeraInterval = dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var timeStamp = DateTime.Now;
                Simulator_Config simulator_Config = new Simulator_Config();
                simulator_Config.sensor = sensorName.ToString();
                simulator_Config.id = Convert.ToInt64(id);
                simulator_Config.timer = Convert.ToInt32(timeraInterval);
                simulator_Config.currentjobstatus = currentjobstatus.ToString();
                simulator_Config.timestamp = Convert.ToString(timeStamp);
                simulator_Config.timertype = timerType.ToString();
                simulator_Config.simulatorname = simulatorName.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Start")
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Stop";
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.OrangeRed;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == "Started")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Stoped";

                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Started";
                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Green;
                    }
                    if (simulatorName != null && !simulatorName.ToString().ToLower().Contains(".json"))
                    {
                        simulatorName = simulatorName + ".json";
                    }
                    updateBlobDetails(simulator_Config);
                    StartJob(simulatorName.ToString(), sensorName.ToString());
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Start";
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                    if (dataGridView1.Rows[e.RowIndex].Cells[2].Value == "Stoped")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Started";
                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "Stoped";

                        dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Red;
                    }
                    updateBlobDetails(simulator_Config);
                    StopJob(simulatorName.ToString(), sensorName.ToString());
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells.Count > 0)
                        {
                            for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                            {
                                switch (j)
                                {
                                    case 1:

                                        Console.WriteLine("dataGridView1");
                                        break;
                                    case 2: break;
                                    case 3: break;
                                    case 4: break;
                                    case 5: break;
                                }

                            }
                        }
                    }
                }
            }

            // if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //e.RowIndex >= 0 &&
            //e.ColumnIndex == dataGridView1.Columns["Status"].Index)
            // {
            //     if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Start")
            //     {
            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Running";


            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.OrangeRed;
            //     }
            //     else
            //     {
            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Stop";
            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            //     }

            // }
        }
        private void UpdateFile()
        {
            var sb = new StringBuilder();

            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => column.HeaderText).ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();

                if (string.Join(",", cells.Select(cell => cell.Value).ToArray()) != ",,")
                    sb.AppendLine(string.Join(",", cells.Select(cell => cell.Value).ToArray()));
            }

            System.IO.File.WriteAllText(CSVFilePath, sb.ToString());

        }

        public static async void getBackgroundStatus()
        {
            while (true)
            {
                await Task.Run(() =>
                {
                    var client = new RestClient("https://datafactory001.azurewebsites.net/Ui");
                    var OfflineData = new RestRequest();
                    List<Simulator_Config> response = new List<Simulator_Config>();
                    try
                    {

                        response = client.Get<List<Simulator_Config>>(OfflineData);
                    }
                    catch (Exception)
                    {

                        response = new List<Simulator_Config>();
                    }

                    if (response != null && response.Count > 0 && (response[1].currentjobstatus.ToLower() == "running" || response[1].currentjobstatus.ToLower() == "started"))
                    {
                        //jayanas code
                    }
                    else
                    {
                        //jayanas code
                    }
                });
            }
        }

    }
}
