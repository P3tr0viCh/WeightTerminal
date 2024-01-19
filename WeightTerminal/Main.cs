using P3tr0viCh.Utils;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using WA;
using WeightTerminal.Properties;
using static P3tr0viCh.Utils.ScaleTerminal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeightTerminal
{
    public partial class Main : Form
    {
        private enum BtnImage
        {
            SettingsNormal = 0,
            SettingsHover = 1,
        }

        private readonly ScaleTerminal ScaleTerminal = new ScaleTerminal();

        public Main()
        {
            InitializeComponent();

            Utils.Log.WriteProgramStart();

            AppSettings.Directory = Files.ExecutableDirectory();

            Debug.WriteLine("Settings: " + AppSettings.FilePath);
        }

        protected override void WndProc(ref Message m)
        {
            AppOneInstance.CheckAndShowApplication(m, this);

            base.WndProc(ref m);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Weight = 0;

            SetBtnImage(btnSettings, BtnImage.SettingsNormal);

            ScaleTerminal.WeightReceived += ScaleTerminal_WeightReceived;

            AppSettingsLoad();

            SettingsChanged();
        }

        private int weight = 0;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;

                lblWeight.Text = weight.ToString();
            }
        }

        private void ScaleTerminal_WeightReceived(object sender, WeightEventArgs e)
        {
            this.InvokeIfNeeded(() => Weight = e.Weight);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetComPortState(false);

            AppSettingsSave();

            Utils.Log.WriteProgramStop();
        }

        public void AppSettingsLoad()
        {
            if (AppSettings.Default.Load()) return;

            Utils.WriteLogError(AppSettings.LastError);
        }

        public void AppSettingsSave()
        {
            if (AppSettings.Default.Save()) return;

            Utils.WriteLogError(AppSettings.LastError);
        }

        private void ListBoxAdd(string s)
        {
            listBox.SelectedIndex = listBox.Items.Add(string.Format("{0}: {1}", listBox.Items.Count, s));
        }

        private bool CheckComPortsExists()
        {
            var ports = SerialPort.GetPortNames();

            if (ports.Length != 0)
            {
                ListBoxAdd("COM ports count: " + ports.Length);

                return true;
            }
            else
            {
                ListBoxAdd("COM PORT not found");

                return false;
            }
        }

        private void SetBtnImage(PictureBox button, BtnImage image)
        {
            button.Image = imageList.Images[(int)image];
        }

        private void SetComPortState(bool open)
        {
            try
            {
                if (open)
                {
                    ScaleTerminal.Open();

                    ListBoxAdd(ScaleTerminal.PortName + " opened");

                    btnConnect.Text = "Close";
                }
                else
                {
                    ScaleTerminal.Close();

                    ListBoxAdd(ScaleTerminal.PortName + " closed");

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
            SetComPortState(!ScaleTerminal.IsOpen);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSettings_MouseEnter(object sender, EventArgs e)
        {
            SetBtnImage(btnSettings, BtnImage.SettingsHover);
        }

        private void BtnSettings_MouseLeave(object sender, EventArgs e)
        {
            SetBtnImage(btnSettings, BtnImage.SettingsNormal);
        }

        private void SettingsChanged()
        {
            var prevStateOpen = ScaleTerminal.IsOpen;

            SetComPortState(false);

            if (CheckComPortsExists())
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;

                return;
            }

            if (string.IsNullOrEmpty(AppSettings.Default.ComPortName))
            {
                ListBoxAdd("error: comportname empty. check settings");

                return;
            }

            if (AppSettings.Default.TerminalType == Enums.TerminalType.None)
            {
                ListBoxAdd("error: terminaltype=none. check settings");

                return;
            }

            ScaleTerminal.SerialPort.PortName = AppSettings.Default.ComPortName;

            ScaleTerminal.Type = (TerminalType)AppSettings.Default.TerminalType;

            if (prevStateOpen)
            {
                SetComPortState(true);
            }
        }

        private void ShowSettings()
        {
            if (FrmSettings.ShowDlg(this))
            {
                SettingsChanged();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }
    }
}