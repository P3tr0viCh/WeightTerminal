#if DEBUG
//#define SHOW_RAWDATA
#endif

using P3tr0viCh.AppUpdate;
using P3tr0viCh.ScaleTerminal;
using P3tr0viCh.Utils;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using WeightTerminal.Properties;
using static P3tr0viCh.ScaleTerminal.ScaleTerminal;

namespace WeightTerminal
{
    public partial class Main : Form
    {
        private enum BtnImage
        {
            SettingsNormal = 0,
            SettingsHover = 1,
            StateOnNormal = 2,
            StateOnHover = 3,
            StateOffNormal = 4,
            StateOffHover = 5,
            AboutNormal = 6,
            AboutHover = 7,
            UpdateAppNormal = 8,
            UpdateAppHover = 9,
        }

        private BtnImage StateNormal = BtnImage.StateOffNormal;
        private BtnImage StateHover = BtnImage.StateOffHover;

        private readonly ScaleTerminal ScaleTerminal = new ScaleTerminal();

        private ImageBtn ibtnState;

        public Main()
        {
            InitializeComponent();

            Utils.Log.Default.WriteProgramStart();

            AppSettings.Directory = Files.ExecutableDirectory();

            DebugWrite.Line($"Settings: {AppSettings.FilePath}", "Main");
        }

        protected override void WndProc(ref Message m)
        {
            AppOneInstance.CheckAndShowApplication(m, this);

            base.WndProc(ref m);
        }

        private void Main_Load(object sender, EventArgs e)
        {
#if SHOW_RAWDATA
            ScaleTerminal.LineReceived += ScaleTerminal_LineReceived;
            ScaleTerminal.ByteReceived += ScaleTerminal_ByteReceived;
#endif

            ScaleTerminal.HeadReceived += ScaleTerminal_HeadReceived;
            ScaleTerminal.WeightReceived += ScaleTerminal_WeightReceived;

            new ImageBtn(btnAbout, imageList, BtnImage.AboutNormal.ToInt(), BtnImage.AboutHover.ToInt());
            new ImageBtn(btnSettings, imageList, BtnImage.SettingsNormal.ToInt(), BtnImage.SettingsHover.ToInt());
            new ImageBtn(btnUpdateApp, imageList, BtnImage.UpdateAppNormal.ToInt(), BtnImage.UpdateAppHover.ToInt());

            ibtnState = new ImageBtn(btnState, imageList, StateNormal.ToInt(), StateHover.ToInt());

            SetToolTip(btnAbout, KeyAbout);
            SetToolTip(btnState, Resources.ToolTipStateOpening, KeyState);
            SetToolTip(btnSettings, KeySettings1);

            AppSettingsLoad();

            SettingsChanged();

            UpdateApp.Default.StatusChanged += UpdateApp_StatusChanged;

            Weight = 0;
        }

#if SHOW_RAWDATA
        private void ScaleTerminal_LineReceived(object sender, LineEventArgs e)
        {
            DebugWrite.Line($">{e.Line}<");
        }

        private void ScaleTerminal_ByteReceived(object sender, ByteEventArgs e)
        {
            var bits = new BitArray(new byte[] { e.B });

            DebugWrite.Line(string.Join("", bits.Cast<bool>().Reverse().Select(bit => bit ? '1' : '0')));
        }
#endif

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

                switch (AppSettings.Default.OutputMassUnit)
                {
                    case MassUnit.tn:
                        lblWeight.Text = (weight / 1000.0).ToString("0.000");

                        break;
                    default:
                        lblWeight.Text = weight.ToString();

                        break;
                }
            }
        }

        private void ScaleTerminal_HeadReceived(object sender, HeadEventArgs e)
        {
            switch (ScaleTerminal.Type)
            {
                case TerminalType.Newton42Byte:
                    var head = (TerminalNewton42Head)e.Head;

                    DebugWrite.Line($"Stable = {head.Stable}, Overload = {head.Overload}, DPoints = {head.DPoints}, Channels = {head.Channels}");

                    break;
            }
        }

        private void WeightReceived(int weight)
        {
            try
            {
                Invoke((Action)(() => Weight = weight));
            }
            catch (Exception e)
            {
                DebugWrite.Error(e);
            }
        }

        private void ScaleTerminal_WeightReceived(object sender, WeightEventArgs e)
        {
            DebugWrite.Line($"{e.Weight}");

            WeightReceived(e.Weight);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminalState = false;

            AppSettingsSave();

            Utils.Log.Default.WriteProgramStop();
        }

        public void AppSettingsLoad()
        {
            if (AppSettings.Load()) return;

            Utils.Log.Error(AppSettings.LastError);
        }

        public void AppSettingsSave()
        {
            if (AppSettings.Save()) return;

            Utils.Log.Error(AppSettings.LastError);
        }

        private bool CheckComPortsExists()
        {
            var ports = SerialPort.GetPortNames();

            if (ports.Length != 0)
            {
                Utils.Log.Info($"COM ports count: {ports.Length}");

                return true;
            }
            else
            {
                Utils.Log.Error("COM PORT not found");

                return false;
            }
        }

        private void SetToolTip(Control control, string text, Keys keys)
        {
            if (keys != Keys.None)
            {
                text = string.Format(Resources.ToolTipKey, text, keys);
            }

            toolTip.SetToolTip(control, text);
        }

        private void SetToolTip(Control control, Keys keys)
        {
            SetToolTip(control, toolTip.GetToolTip(control), keys);
        }

        private void SetToolTip(Control control, string text)
        {
            SetToolTip(control, text, Keys.None);
        }

        private bool MouseIsOverControl(Control control) =>
            control.ClientRectangle.Contains(
                control.PointToClient(Cursor.Position));

        public bool TerminalState
        {
            get
            {
                return ScaleTerminal.IsOpen;
            }
            set
            {
                try
                {
                    if (value)
                    {
                        if (!ScaleTerminal.IsOpen)
                        {
                            if (ScaleTerminal.Type == TerminalType.None)
                            {
                                Utils.Msg.Error(Resources.ErrorTerminalTypeNone);

                                return;
                            }

                            if (ScaleTerminal.PortName.IsEmpty())
                            {
                                Utils.Msg.Error(Resources.ErrorTerminalPortEmpty);

                                return;
                            }

                            ScaleTerminal.Open();

                            StateNormal = BtnImage.StateOnNormal;
                            StateHover = BtnImage.StateOnHover;

                            SetToolTip(btnState, Resources.ToolTipStateClosing, KeyState);

                            Utils.Log.Info($"{ScaleTerminal.PortName} opened. type={ScaleTerminal.Type}");
                        }
                    }
                    else
                    {
                        if (ScaleTerminal.IsOpen)
                        {
                            ScaleTerminal.Close();

                            Invoke((Action)(() => Weight = 0));

                            StateNormal = BtnImage.StateOffNormal;
                            StateHover = BtnImage.StateOffHover;

                            SetToolTip(btnState, Resources.ToolTipStateOpening, KeyState);

                            Utils.Log.Info($"{ScaleTerminal.PortName} closed");
                        }
                    }

                    ibtnState.SetImages(StateNormal.ToInt(), StateHover.ToInt());
                }
                catch (Exception e)
                {
                    Utils.Log.Error(e);

                    Utils.Msg.Error(Resources.ErrorError, e.Message);
                }
            }
        }

        private void SettingsChanged()
        {
            Weight = 0;

            btnState.Enabled = CheckComPortsExists();

            if (AppSettings.Default.ComPortName.IsEmpty())
            {
                AppSettings.Default.ComPortName = "COM1";
            }

            if (AppSettings.Default.TerminalType == TerminalType.None)
            {
                Utils.Log.Error("check settings: terminaltype=none");
            }

            ScaleTerminal.SerialPort.PortName = AppSettings.Default.ComPortName;

            ScaleTerminal.Type = AppSettings.Default.TerminalType;

            ScaleTerminal.TerminalMassUnit = AppSettings.Default.TerminalMassUnit;
        }

        private void ShowSettings()
        {
            var prevStateOpen = ScaleTerminal.IsOpen;

            TerminalState = false;

            if (FrmSettings.ShowDlg(this))
            {
                AppSettings.Load();
                SettingsChanged();
            }

            if (prevStateOpen && ScaleTerminal.Type != TerminalType.None)
            {
                TerminalState = true;
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void BtnState_Click(object sender, EventArgs e)
        {
            TerminalState = !TerminalState;
        }

        private void ShowAbout()
        {
            FrmAbout.Show(new FrmAbout.Options()
            {
                Link = Resources.GitHubLink,
                AppNameFontSize = 24
            });
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private const Keys KeyAbout = Keys.F1;
        private const Keys KeyState = Keys.F4;
        private const Keys KeySettings1 = Keys.F8;
        private const Keys KeySettings2 = Keys.O | Keys.Control;

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case KeyAbout:
                    ShowAbout();
                    break;
                case KeyState:
                    TerminalState = !TerminalState;
                    break;
                case KeySettings1:
                case KeySettings2:
                    ShowSettings();
                    break;
            }
        }

        private void BtnUpdateApp_Click(object sender, EventArgs e)
        {
            UpdateApp.Default.Update();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UpdateApp.Default.CanClose())
            {
                if (!Msg.Question(Resources.AppUpdateQuestionInProgress))
                {
                    e.Cancel = true;

                    return;
                }
            }
        }

        private void UpdateApp_StatusChanged(object sender, UpdateStatus status)
        {
            DebugWrite.Line(status.ToString());

            switch (status)
            {
                case UpdateStatus.CheckLatest:
                    SetToolTip(btnUpdateApp, Resources.AppUpdateInfoStatusCheckLatest);
                    break;
                case UpdateStatus.Download:
                    SetToolTip(btnUpdateApp, Resources.AppUpdateInfoStatusDownload);
                    break;
                case UpdateStatus.ArchiveExtract:
                    SetToolTip(btnUpdateApp, Resources.AppUpdateInfoStatusExtract);
                    break;
                case UpdateStatus.Check:
                case UpdateStatus.CheckLocal:
                case UpdateStatus.Update:
                case UpdateStatus.Idle:
                default:
                    SetToolTip(btnUpdateApp, Resources.AppUpdateInfoStatusIdle);
                    break;
            }
        }
    }
}