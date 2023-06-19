using P3tr0viCh.Utils;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeightTerminal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ListBoxAdd(string s)
        {
            listBox.SelectedIndex = listBox.Items.Add(s);
        }

        private void GetComPorts()
        {
            cboxPorts.Items.Clear();

            btnConnect.Enabled = false;

            var ports = SerialPort.GetPortNames();

            ListBoxAdd("COM ports count: " + ports.Length);

            if (ports.Length != 0)
            {
                cboxPorts.Items.AddRange(ports);

                serialPort.DataReceived += SerialPortDataReceived;

                btnConnect.Enabled = true;
            }
            else
            {
                cboxPorts.Items.Add("COM PORT not found");
            }

            cboxPorts.SelectedIndex = 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GetComPorts();

            receivedEvent = new LineReceivedEvent(LineReceived);
        }

        private void SetComPortState(bool open)
        {
            try
            {
                if (open)
                {
                    serialPort.PortName = cboxPorts.Text;

                    if (rbtnNewton42.Checked)
                    {
                        serialPort.NewLine = "\x0D";
                    }
                    else
                    {
                        if (rbtnMidlVda12.Checked)
                        {
                            serialPort.NewLine = "\x0A";
                        }
                    }

                    serialPort.Open();

                    serialPort.DiscardInBuffer();
                    serialPort.DiscardOutBuffer();

                    ListBoxAdd(serialPort.PortName + " opened");

                    btnConnect.Text = "Close";
                }
                else
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();

                        serialPort.Close();
                    }

                    ListBoxAdd(serialPort.PortName + " closed");

                    btnConnect.Text = "Open";
                }
            }
            catch (Exception e)
            {
                ListBoxAdd("error: " + e.Message);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            SetComPortState(!serialPort.IsOpen);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetComPortState(false);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var line = serialPort.ReadLine();

                BeginInvoke(receivedEvent, line);
            }
            catch (Exception)
            {
            }
        }

        private delegate void LineReceivedEvent(string line);
        private LineReceivedEvent receivedEvent;

        private void LineReceived(string line)
        {
            ListBoxAdd(line);

            SetWeight(line);
        }

        public static double DoubleParse(string str, double def = 0.0)
        {
            return double.TryParse(str, NumberStyles.Float | NumberStyles.AllowThousands,
                CultureInfo.InvariantCulture, out double result) ?
                result : def;
        }

        private void SetWeight(string s)
        {
            var startIndex = 0;
            var length = 0;

            if (rbtnNewton42.Checked)
            {
                // Ньютон-42
                //0    1    2      9    10   11   12
                //0x02 0x20 weight 0x20 0x47 0x20 0x0D

                startIndex = 2;
                length = 7;
            }
            else
            {
                if (rbtnMidlVda12.Checked)
                {
                    // Мидл ВДА/12Я
                    // WW0000.00kg..
                    // 57 57 30 30 30 30 2E 30 30 6B 67 0D 0A

                    startIndex = 2;
                    length = 7;
                }
            }

            var weight = s.Substring(startIndex, length);

            ListBoxAdd(weight);

            try
            {
                var w = DoubleParse(weight);

                lblWeight.Text = w.ToString("0.00");
            }
            catch (Exception e)
            {
                lblWeight.Text = "0.00";

                ListBoxAdd("error: " + e.Message);
            }
        }
    }
}