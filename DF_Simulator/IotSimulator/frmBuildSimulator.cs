using Aspose.Pdf;
using IOTSimulator.Helpers;
using IOTSimulator.Models;
using IOTSimulator.Services;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using Tulpep.NotificationWindow;

namespace IOTSimulator
{
    public partial class frmBuildSimulator : Form
    {
        #region Properties, Variables
        Dictionary<object, object> keyValuePairs = new Dictionary<object, object>();
        Random randomGenerator = new Random();
        List<BaseParameter> parameters = new List<BaseParameter>();
        System.Data.DataTable dt = new System.Data.DataTable();
        List<DataConfiguration> dataConfig = new List<DataConfiguration>();
        Random random = new Random();

        Service services = new Service();
        int recordsToGenerate = 10000;
        //List<BaseParameter> parameters = new List<BaseParameter>();
        #endregion
        public frmBuildSimulator()
        {
            InitializeComponent();
            if (!services.IsConnectedToInternet())
            {
                lblErrorMsg.Text = "Internet Disconnected";
                lblErrorMsg.BackColor = System.Drawing.Color.Red;
                lblErrorMsg.ForeColor = System.Drawing.Color.White;
                btnSimulatorConfiguation.Enabled = false;

            }
            else
            {
                lblErrorMsg.Text = "Internet Connected";
                lblErrorMsg.BackColor = System.Drawing.Color.Green;
                lblErrorMsg.ForeColor = System.Drawing.Color.White;
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataTypeDropdown.Items.AddRange(new string[] { "int", "decimal", "string", "datetime", "custom" });

            dataTypeDropdown.SelectedIndex = 0;
        }


        private List<Simulator_Config> GetNewJsonValue()
        {
            String fileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\SimulatorDetails.json");// + fileNamePath; //read the file dynamic
            String _CongurationJson = string.Empty;
            using (StreamReader r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                _CongurationJson = json.ToString();
            }
            var congurationJsonData = JsonConvert.DeserializeObject<List<Simulator_Config>>(_CongurationJson.ToString());

            // string _SimulatorName =  congurationJsonData.SimulatorName;
            // long _TimerIntervalSecond = congurationJsonData.TimerIntervalSecond;

            List<Simulator_Config> myDataModels = new List<Simulator_Config>();
            Simulator_Config myDataModel;
            for (int i = 0; i < congurationJsonData.Count; i++)
            {
                myDataModel = new Simulator_Config();
                myDataModel.id = congurationJsonData[i].id;
                myDataModel.timestamp = congurationJsonData[i].timestamp;
                myDataModel.currentjobstatus = congurationJsonData[i].currentjobstatus;
                myDataModel.timertype = congurationJsonData[i].timertype;
                myDataModel.simulatorname = congurationJsonData[i].simulatorname;
                myDataModel.timer = congurationJsonData[i].timer;
                myDataModel.sensor = congurationJsonData[i].sensor;
                myDataModels.Add(myDataModel);
            }


            StreamReader streamReader;


            ////var mydataFile = "../../../configure/BgFile.csv";
            //var mydataFile = @"D:\IOT\Final\IotSimulator\ConfigurationFiles\BgFile.csv";

            if (File.Exists(fileName))
            {
                try
                {
                    streamReader = File.OpenText(fileName);

                    //while (!streamReader.EndOfStream)
                    //{
                    var valueLine = streamReader.ReadLine();

                    myDataModel = new Simulator_Config();

                    var csvValues = valueLine.Split(',');
                    if (csvValues != null)
                    {

                    }



                    streamReader.Close();
                    streamReader = null;


                }
                catch (Exception ex)
                {
                    streamReader = null;
                }
            }

            return myDataModels;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDatatype = dataTypeDropdown.SelectedItem.ToString();
            txtMin.Visible = true;
            txtMax.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            if (selectedDatatype == "datetime")
            {
                txtMin.Visible = false;
                txtMax.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                minLengthLabel.Text = "From Date";
                maxLengthLabel.Text = "To Date";
            }
            if (selectedDatatype != "datetime")
            {
                minLengthLabel.Text = "Min Length";
                maxLengthLabel.Text = "Max Length";
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string selectedDatatype = dataTypeDropdown.SelectedItem.ToString();
            string fieldName = textField.Text;
            string minValue = txtMin.Text;
            string maxValue = txtMax.Text;
            if (keyValuePairs.ContainsKey(fieldName))
            {
                MessageBox.Show("Field name exists");
                return;
            }
            BaseParameter baseParameter = null;
            Row r = new Row();
            ExtendedDataColumn dc = new ExtendedDataColumn();
            ExtendedDataColumn dcDatatype = new ExtendedDataColumn();
            ExtendedDataColumn dcMinValue = new ExtendedDataColumn();
            ExtendedDataColumn dcMaxValue = new ExtendedDataColumn();
            DataRow row = dt.NewRow();

            try
            {
                switch (selectedDatatype)
                {
                    case "string":
                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(string) };
                        break;
                    case "int":
                        dc = new ExtendedDataColumn()
                        {
                            ColumnName = fieldName,
                            DataType = typeof(int),
                            MockMinValue = int.MinValue,
                            MockMaxValue = int.MaxValue
                        };
                        dc.ColumnName = fieldName;

                        dc.MockMinValue = txtMin.Text;
                        dc.MockMaxValue = txtMax.Text;
                        if (int.TryParse(txtMin.Text, out int minInt)) { dc.MockMinValue = minInt; }
                        if (int.TryParse(txtMax.Text, out int maxInt)) { dc.MockMaxValue = maxInt; }
                        break;
                    case "decimal":

                        dc = new ExtendedDataColumn()
                        {
                            ColumnName = fieldName,
                            DataType = typeof(decimal),
                            MockMinValue = decimal.MinValue,
                            MockMaxValue = decimal.MaxValue,
                            MockPrecision = 2
                        };
                        if (decimal.TryParse(txtMin.Text, out decimal minDecimal)) { dc.MockMinValue = minDecimal; }
                        if (decimal.TryParse(txtMax.Text, out decimal maxDecimal)) { dc.MockMaxValue = maxDecimal; }
                        if (int.TryParse(txtMax.Text, out int precision)) { dc.MockPrecision = precision; }
                        break;
                    case "datetime":
                        dc = new ExtendedDataColumn()
                        {
                            ColumnName = fieldName,
                            DataType = typeof(DateTime),
                            MockMinValue = new DateTime(1900, 1, 1, 0, 0, 0),
                            MockMaxValue = new DateTime(2100, 12, 31, 11, 59, 59)
                        };
                        dc.MockMinValue = dateTimePicker1.Value;
                        dc.MockMaxValue = dateTimePicker2.Value;
                        break;

                    case "custom":
                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(int), MockMinValue = 10, MockMaxValue = 100 };
                        break;
                    default:
                        dc = new ExtendedDataColumn() { ColumnName = fieldName, DataType = typeof(object) };
                        break;
                }
                dcDatatype = new ExtendedDataColumn()
                {
                    ColumnName = "Data Type",
                };
                dc = new ExtendedDataColumn()
                {
                    ColumnName = "Field Name",
                };
                if (selectedDatatype == "datetime")
                {
                    dcMinValue = new ExtendedDataColumn()
                    {
                        ColumnName = "From Date",
                    };
                    dcMaxValue = new ExtendedDataColumn()
                    {
                        ColumnName = "To Date",
                    };
                }
                dcMinValue = new ExtendedDataColumn()
                {
                    ColumnName = "Min Value",
                };
                dcMaxValue = new ExtendedDataColumn()
                {
                    ColumnName = "Max Value",
                };
                if (!dt.Columns.Contains(dcDatatype.ToString()))
                {
                    dt.Columns.Add(dcDatatype);
                    dt.Columns.Add(dc);
                    dt.Columns.Add(dcMinValue);
                    dt.Columns.Add(dcMaxValue);
                }
                row[dcDatatype.ColumnName] = selectedDatatype;
                row[dc.ColumnName] = fieldName;
                row[dcMinValue.ColumnName] = minValue;
                row[dcMaxValue.ColumnName] = maxValue;
                if (selectedDatatype == "datetime")
                {
                    row[dcMinValue.ColumnName] = dateTimePicker1.Value.Date;
                    row[dcMaxValue.ColumnName] = dateTimePicker2.Value.Date;
                }
                dt.Rows.Add(row);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                parameters.Add(baseParameter);
            }
            catch (Exception ex)
            {
                // return ex.ToString();
                errorMessageBox.Text += $"{Environment.NewLine}{ex.Message}";
            }

            finally
            {
                dataConfig.Add(new DataConfiguration
                {
                    ColumnName = fieldName,
                    DataType = selectedDatatype,
                    MinLength = minValue,
                    MaxLength = maxValue
                });
                // bGConfiguration.DataConfigurationlst = new List<DataConfiguration>();
            }
            textField.Text = "";
            dataTypeDropdown.Text = "";
            txtMin.Text = "";
            txtMax.Text = "";
            rowsValue.Text = Convert.ToString(dt.Rows.Count);

            // new EmployeeDataModel() { Age = 10 };
        }

        private async void btnSimulatorConfiguation_Click_1(object sender, EventArgs e)
        {

            //string SensorfileNames = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\", "appsettings.json"); // + fileNamePath; //read the file dynamic
            //using StreamReader readers = new(SensorfileNames);
            //String _CongurationJson = string.Empty;
            //using (StreamReader r = new StreamReader(SensorfileNames))
            //{
            //    var jsons = r.ReadToEnd();
            //    _CongurationJson = jsons.ToString();
            //}
            //var config = JsonConvert.DeserializeObject<BlobConfig>(_CongurationJson.ToString());
            if (dataGridView1.Rows.Count > 0 && txtSimulatorName.Text != "")
            {
                var config = new BlobConfig();
                string connectionString = config.StorageConnection;
                string container = config.ContainerName;
                BlobStorage blobStorage = new BlobStorage();
                //string SensorfileName = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\ConfigurationFiles\", dataGridView1[0, e.RowIndex].Value.ToString()+".json"); // + fileNamePath; //read the file dynamic
                BackgroundJobConfiguration bGConfiguration = new BackgroundJobConfiguration();
                if (timeIntervalValue.Text == "")
                {
                    string timerInterval = "5";
                }
                else
                {
                    string timerInterval = timeIntervalValue.Text;
                }
                // string timerIntervals = timer
                string dataFormat = fileFormatDatatype.SelectedItem.ToString();
                string timeStamp = DateTime.Now.ToString();
                string sensor = Guid.NewGuid().ToString();
                string simulatorName = txtSimulatorName.Text.Trim() + Guid.NewGuid();
                string dataType = dataTypeDropdown.SelectedItem.ToString();
                bGConfiguration.dataFormat = dataFormat;
                bGConfiguration.timerIntervalSecond = timeIntervalValue.Text;
                bGConfiguration.timestamp = timeStamp;
                bGConfiguration.sensor = sensor;
                bGConfiguration.simulatorName = simulatorName;
                bGConfiguration.DataConfigurationlst = dataConfig;
                var jsonString = JsonConvert.SerializeObject(bGConfiguration);
                byte[] byteArray = Encoding.ASCII.GetBytes(jsonString);
                MemoryStream stream = new MemoryStream(byteArray);
                string fileName = simulatorName + "." + "json";
                var b = blobStorage.UploadDocument(connectionString, container, fileName, stream);
                string path = @"..\..\..\..\ConfigurationFiles\";
                Simulator_Config simulator_Config = new Simulator_Config();
                simulator_Config.sensor = sensor;
                simulator_Config.id = random.NextInt64(10000, 99999);
                simulator_Config.timer = Convert.ToInt32(timeIntervalValue.Text);
                simulator_Config.currentjobstatus = "Stoped";
                simulator_Config.timestamp = Convert.ToString(DateTime.Now);
                simulator_Config.timertype = ddlTimerType.SelectedItem.ToString();
                simulator_Config.simulatorname = simulatorName;

                //services.PrettyWrite(simulator_Config,  path+"Simulator_Config.json");

                //string path1= services.GetDataDir();
                //string simulator_config_json = Path.Combine(Environment.CurrentDirectory, path1, "Simulator_Config.json"); // + fileNamePath; //read the file dynamic
                //using StreamReader simulator_config_reader = new(simulator_config_json);
                //string _config_reader = string.Empty;
                //using (StreamReader r = new StreamReader(simulator_config_json))
                //{
                //    var json_read = r.ReadToEnd();
                //    _config_reader = json_read.ToString();
                //}
                List<Simulator_Config> congurationJsonData = new List<Simulator_Config>();
                congurationJsonData = await blobStorage.GetDocument<List<Simulator_Config>>(config.StorageConnection, config.ContainerName, "Simulator_Config.json");
                congurationJsonData.Add(simulator_Config);
                var json=JsonConvert.SerializeObject(congurationJsonData);

                // this is an array of datatype byte
                var bytes = System.Text.Encoding.UTF8.GetBytes(json);

                // your stream
                var memStream = new MemoryStream(bytes);

                string s=JsonConvert.SerializeObject(congurationJsonData);
          
                string simulator_config_file = "Simulator_Config.json";


                blobStorage.UploadDocument(connectionString, container, simulator_config_file, memStream);
                PopupNotifier popup = new PopupNotifier();
                popup.BodyColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\IOTSimulator\\Helpers\\popuptick.png");
                //var size1 = 20;
                popup.ImageSize = new Size(60, 60);
                popup.ImagePadding = new Padding(170, 3, 0, 0);
                popup.ContentText = "Simulator Configuration Saved Successfully !";
                popup.ContentPadding = new Padding(-210, 50, 0, 0);
                popup.ContentFont = new Font("Tahoma", 11, FontStyle.Bold);
                popup.Popup();
                blobStorage.UploadDocument(connectionString, container, simulator_config_file, memStream); dt.Rows.Clear();
                dataConfig.Clear();
                txtSimulatorName.Clear();
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.BodyColor = System.Drawing.Color.FromArgb(255, 255, 255);
                popup.Image = System.Drawing.Image.FromFile("..\\..\\..\\..\\IOTSimulator\\Helpers\\warning.png");
                //var size1 = 20;
                popup.ImageSize = new Size(60, 60);
                popup.ImagePadding = new Padding(170, 3, 0, 0);
                popup.ContentText = "Please fill all the fields !";
                popup.ContentPadding = new Padding(-123, 50, 0, 0);
                popup.ContentFont = new Font("Tahoma", 11, FontStyle.Bold);
                popup.Popup();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            dataConfig.Clear();
            txtSimulatorName.Clear();
        }
        public class ExtendedDataColumn : DataColumn
        {
            public object MockMinValue { get; set; }
            public object MockMaxValue { get; set; }
            public int MockPrecision { get; set; }
            public string MockDataFormat { get; set; }
        }

        public class BaseParameter
        {
            public Type DefinedDatatype { get; set; }
            public object DefinedValue { get; set; }
            public string FieldName { get; set; }
            public object MinValue { get; set; }
            public object MaxValue { get; set; }


            public BaseParameter(string fieldName, Type definedDatatype, object definedValue, object minValue = null, object maxValue = null)
            {
                FieldName = fieldName;
                DefinedDatatype = definedDatatype;
                DefinedValue = Convert.ChangeType(definedValue, definedDatatype);
                MinValue = minValue;
                MaxValue = maxValue;
            }
        }
    }
}