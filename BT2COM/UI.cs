using Plugin.BLE;
using System.IO.Ports;
using Xamarin.Essentials;

namespace BT2COM
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
            BTDevices.SelectedIndexChanged += BTDevices_SelectedIndexChanged;
            ComPorts.SelectedIndexChanged += ComPorts_SelectedIndexChanged;
            var timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if(!ComPorts.DroppedDown)
                EnumerateComPorts();
        }

        private void ComPorts_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (ComPorts.SelectedIndex > -1)
            {
                Settings.Default.ComPort = ComPorts.Items[ComPorts.SelectedIndex]!.ToString();
                Settings.Default.Save();
            }
        }

        private void BTDevices_SelectedIndexChanged(object? sender, EventArgs e)
        {
            IdleMode();
        }

        private void EnumerateComPorts()
        {
            ComPorts.Items.Clear();
            foreach (var port in SerialPort.GetPortNames())
            {
                if (port != null)
                    ComPorts.Items.Add(port);
            }
            if (ComPorts.Items.Count > 0)
            {
                int i = ComPorts.Items.IndexOf(Settings.Default.ComPort);
                ComPorts.SelectedIndex = i < 0 ? 0 : i;
            }
        }

        private void SetMode(OpMode mode)
        {
            switch (mode)
            {
                case OpMode.NoBtDevice:
                    StartButton.Enabled = false;
                    StopButton.Enabled = false;
                    BTDevices.Enabled = true;
                    ScanButton.Enabled = true;
                    ComPorts.Enabled = true;
                    break;
                case OpMode.NotRunning:
                    StartButton.Enabled = true;
                    StopButton.Enabled = false;
                    BTDevices.Enabled = true;
                    ScanButton.Enabled = true;
                    ComPorts.Enabled = true;
                    break;
                case OpMode.BTBusy:
                    StartButton.Enabled = false;
                    StopButton.Enabled = false;
                    BTDevices.Enabled = false;
                    ScanButton.Enabled = false;
                    ComPorts.Enabled = false;
                    break;
                case OpMode.Running:
                    StartButton.Enabled = false;
                    StopButton.Enabled = true;
                    BTDevices.Enabled = false;
                    ScanButton.Enabled = false;
                    ComPorts.Enabled = false;
                    break;
            }
        }

        private void Log(string message)
        {
            Status.Text = message;
        }

        private void IdleMode()
        {
            SetMode(BTDevices.SelectedIndex > -1 && ComPorts.SelectedIndex > -1 ? OpMode.NotRunning : OpMode.NoBtDevice); ;
        }

        private void UI_Shown(object sender, EventArgs e)
        {
            BT.Init(BTDevices);
            EnumerateComPorts();
            IdleMode();
            Task.Run(Com.ReadLoop);
        }

        private async void ScanButton_Click(object sender, EventArgs e)
        {
            SetMode(OpMode.BTBusy);
            Log("Scanning...");
            await BT.Scan();
            Log($"{BTDevices.Items.Count} device(s) found.");
            IdleMode();
            if (BTDevices.Items.Count > 0)
                BTDevices.SelectedIndex = 0;
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            Status.Text = "Connecting...";
            SetMode(OpMode.Running);
            if (Com.Open(ComPorts.SelectedItem?.ToString() ?? string.Empty))
            {
                await BT.Connect();
                if (BT.ConnectedDevice != null)
                {
                    Status.Text = "Started";
                    return;
                }
                else
                    Status.Text = "Cannot connect to BT Device";
            }
            else
                Status.Text = $"Cannot Open {(ComPorts.SelectedItem?.ToString() ?? "COM?")}";
            IdleMode();
        }

        private async void StopButton_Click(object sender, EventArgs e)
        {
            BT.CancelConnect();
            Com.Close();
            Status.Text = "Disconnecting...";
            await BT.Disconnect();
            Status.Text = "Disconnected.";
            IdleMode();
        }
    }

    public enum OpMode
    {
        NoBtDevice,
        NotRunning,
        BTBusy,
        Running
    }
}
