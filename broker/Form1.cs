using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Session;
using uPLibrary.Networking.M2Mqtt.Internal;
namespace broker
{
    public partial class Form1 : Form
    {
        string _recievedData = "";
        string _logging = "";

        //on hover vars
        ToolTip tooltip = new ToolTip();
        Point? prevPosition = null;

        //form vars
        int fromEdgeToTopicsGB;
        int fromTopicsGBtoLogsGB;
        int fromLogsGBtoChart;
        int fromChartToEdge;

        MqttClient client;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_rec_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            try
            {

                if (e.Topic.ToString().Contains("temperature"))
                {
                    _logging = "[" + DateTime.Now + "] A temperature response just arrived.\r\n";
                    _recievedData = "Received = " + Encoding.UTF8.GetString(e.Message) + "°C on topic " + e.Topic + "\r\n";
                }
                else
                {
                    _logging = "[" + DateTime.Now + "] A humidity response just arrived.\r\n";
                    _recievedData = "Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic + "\r\n";
                }
                _ThreadSaver(e);
            }
            catch { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null && client.IsConnected)
                client.Disconnect();
            else
                MessageBox.Show("Client was not initialized...Skipping killing it.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void _ThreadSaver(MqttMsgPublishEventArgs _args)
        {
            tb_response.Text += _recievedData;
            tb_logs.Text += _logging;
            double recievedValue = Convert.ToDouble(Encoding.UTF8.GetString(_args.Message));
            if (_args.Topic.ToString().Contains("temperature"))
                chart.Series["Temperature"].Points.AddXY("", recievedValue);
            else
                chart.Series["Humidity"].Points.AddXY("", recievedValue);


            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint p in chart.Series["Temperature"].Points)
            {
                p.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                p.MarkerSize = 10;
            }

            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint p in chart.Series["Humidity"].Points)
            {
                p.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                p.MarkerSize = 10;
            }

            foreach (System.Windows.Forms.DataVisualization.Charting.Series s in chart.Series)
            {
                s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Use predefined topics?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                tb_topic1.Text = "humidityPublisher";
                tb_topic2.Text = "temperaturePublisher";
                gb_reciever.Visible = true;
                lb_please.Visible = false;
            }
            else
                gb_reciever.Visible = false;

            ConfigUI();
        }

        private void ConfigUI()
        {
            tb_logs.ScrollBars = ScrollBars.Both;
            tb_response.Enabled = false;
            tb_response.ScrollBars = ScrollBars.Both;
            tb_logs.ReadOnly = true;
            tb_topic1.TabIndex = 1;
            tb_topic2.TabIndex = 2;
            Text = "MQTT Client";
            lb_please.Text = "Please fill all the fields.";

            lb_isConnected.Text = "Not connected...";
            chart.Series.RemoveAt(0); // clean out the grid
            chart.Series.Add("Temperature"); //add a new series
            chart.Series.Add("Humidity"); // add a new series
            chart.Series["Temperature"].Color = Color.LightGreen;
            chart.Series["Humidity"].Color = Color.Pink;
            chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;

            foreach (System.Windows.Forms.DataVisualization.Charting.ChartArea area in chart.ChartAreas)
            {
                area.AxisX.Interval = 1;
                area.AxisY.Interval = 5;
                area.AxisY.Maximum = 50;
            }

            fromEdgeToTopicsGB = gb_topics.Location.X;
            fromTopicsGBtoLogsGB = gb_logs.Location.X - gb_topics.Width - fromEdgeToTopicsGB;
            fromLogsGBtoChart = chart.Location.X - gb_logs.Width - gb_topics.Width - fromEdgeToTopicsGB - fromTopicsGBtoLogsGB;
            fromChartToEdge = Width - chart.Width - gb_logs.Width - gb_topics.Width - fromEdgeToTopicsGB - fromTopicsGBtoLogsGB - fromLogsGBtoChart;

            Width = gb_logs.Location.X + gb_logs.Width + fromEdgeToTopicsGB + fromTopicsGBtoLogsGB + fromLogsGBtoChart;
        }

        private void StartRecording()
        {
            lb_isConnected.Text = "Connecting...";
            try
            {
                client = new MqttClient("broker.mqttdashboard.com");
            }
            catch
            {
                tb_logs.Text += DateTime.Now + "Error while trying to connect to MQTT Broker\r\n.Exiting...";
                MessageBox.Show("Error while trying to connect to MQTT Broker\r\nTimeout error - Server down.\r\nExiting...", "Timeout error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            tb_logs.Text += "[" + DateTime.Now + "] Connected to broker.\r\n";
            tb_logs.Text += "[" + DateTime.Now + "] Creating the client and connecting...\r\n";
            byte code; //dummy var
            try
            {
                code = client.Connect("8c2f7a6f.c834e8"); // our ID

            }
            catch (Exception z)
            {
                tb_logs.Text += "[" + DateTime.Now + "] Error while trying to connect as MQTT Client...Exiting.";
                MessageBox.Show(z + "\r\nError while trying to connect as MQTT Client...Exiting.", "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();

            }
            tb_logs.Text += "[" + DateTime.Now + "] Connected as client...\r\n";
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            tb_logs.Text += "[" + DateTime.Now + "] Subscription raise event successfully added\r\n";
            try {
                ushort msgIdHumidity = client.Subscribe(
                    new string[] { tb_topic1.Text, tb_topic1.Text },
                                new byte[] {
                                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                ushort msgIdTemperature = client.Subscribe(
                    new string[] { tb_topic2.Text, tb_topic2.Text },
                                new byte[] {
                                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
            catch (Exception v)
            {
                tb_logs.Text += "[" + DateTime.Now + "] Failed to subscribe to a topic\r\n";
                MessageBox.Show(v + "\r\nFailed to subscribe to topics\r\n", "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            tb_response.Enabled = true;
            tb_logs.Text += "[" + DateTime.Now + "] Successfully subscribed to a topic\r\n";
            lb_isConnected.Text = "Connected...";
            tb_logs.Text += "[" + DateTime.Now + "] Waiting for a publication...\r\n";

        }

        private void tb_topic1_TextChanged(object sender, EventArgs e)
        {
            if (tb_topic1.Text != "" && tb_topic2.Text != "")
                gb_reciever.Visible = true;
            else
            {
                gb_reciever.Visible = false;
                lb_please.Visible = false;
            }
        }

        private void tb_topic2_TextChanged(object sender, EventArgs e)
        {
            tb_topic1_TextChanged(sender, e);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
                client.Disconnect();
            tb_response.Text = tb_logs.Text = tb_topic1.Text = tb_topic2.Text = "";
            gb_reciever.Visible = false;
            lb_isConnected.Text = "";
            tb_logs.Text = "";
            foreach (System.Windows.Forms.DataVisualization.Charting.Series s in chart.Series)
            {
                s.Points.Clear();
            }
            chart.Invalidate();


        }

        private void cb_grid_CheckedChanged(object sender, EventArgs e)
        {
            int margins = fromEdgeToTopicsGB + fromTopicsGBtoLogsGB + fromLogsGBtoChart + fromChartToEdge;
            int resize = (cb_grid.Checked) ?
                gb_topics.Width + gb_logs.Width + chart.Width + margins
                : Width = gb_logs.Location.X + gb_logs.Width + fromEdgeToTopicsGB + fromTopicsGBtoLogsGB + fromLogsGBtoChart;

            Width = resize;
        }
        
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false,
                                            System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.DataPoint)
                {
                    if (result.Object is System.Windows.Forms.DataVisualization.Charting.DataPoint prop)
                    {
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);
                        tooltip.Show("Value =" + prop.YValues[0], chart,
                                           pos.X, pos.Y - 15);
                    }
                }
            }
        }
    }
}
