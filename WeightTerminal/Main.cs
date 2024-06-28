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
using static WeightTerminal.Enums;

namespace WeightTerminal
{
    public partial class Main : Form
    {
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

#if DEBUG
            lblChannelLeftFar.Click += LblChannelLeftFar_Click;
            lblChannelRightFar.Click += LblChannelRightFar_Click;
            lblChannelLeftNear.Click += LblChannelLeftNear_Click;
            lblChannelRightNear.Click += LblChannelRightNear_Click;
#endif
            lblDiffFar.ForeColor = ControlPaint.Light(lblDiffFar.ForeColor);
            lblDiffNear.ForeColor = ControlPaint.Light(lblDiffNear.ForeColor);
            lblDiffLeft.ForeColor = ControlPaint.Light(lblDiffLeft.ForeColor);
            lblDiffRight.ForeColor = ControlPaint.Light(lblDiffRight.ForeColor);

            ScaleTerminal.HeadReceived += ScaleTerminal_HeadReceived;
            ScaleTerminal.WeightReceived += ScaleTerminal_WeightReceived;

            ScaleTerminal.Opened += ScaleTerminal_Opened;
            ScaleTerminal.Closed += ScaleTerminal_Closed;

            UpdateApp.Default.StatusChanged += UpdateApp_StatusChanged;

            new ImageBtn(btnAbout, imageList, BtnImage.AboutNormal.ToInt(), BtnImage.AboutHover.ToInt());
            new ImageBtn(btnSettings, imageList, BtnImage.SettingsNormal.ToInt(), BtnImage.SettingsHover.ToInt());
            new ImageBtn(btnUpdateApp, imageList, BtnImage.UpdateAppNormal.ToInt(), BtnImage.UpdateAppHover.ToInt());
            new ImageBtn(btnChannels, imageList, BtnImage.ChannelsNormal.ToInt(), BtnImage.ChannelsHover.ToInt());

            ibtnState = new ImageBtn(btnState, imageList, BtnImage.StateOffNormal.ToInt(), BtnImage.StateOffHover.ToInt());

            SetToolTip(btnAbout, Key.About);
            SetToolTip(btnState, Resources.ToolTipStateOpening, Key.State);
            SetToolTip(btnChannels, Key.Channels);
            SetToolTip(btnSettings, Key.Settings1);

            Status = string.Empty;

            AppSettingsLoad();

            SettingsChanged();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
#if SHOW_RAWDATA
            ScaleTerminal.LineReceived -= ScaleTerminal_LineReceived;
            ScaleTerminal.ByteReceived -= ScaleTerminal_ByteReceived;
#endif

            ScaleTerminal.HeadReceived -= ScaleTerminal_HeadReceived;
            ScaleTerminal.WeightReceived -= ScaleTerminal_WeightReceived;

            ScaleTerminal.Opened -= ScaleTerminal_Opened;
            ScaleTerminal.Closed -= ScaleTerminal_Closed;

            TerminalState = false;

            AppSettingsSave();

            Utils.Log.Default.WriteProgramStop();

            DebugWrite.Line("Closed", "Main");
        }

        private void ScaleTerminalOpened()
        {
            ibtnState.SetImages(BtnImage.StateOnNormal.ToInt(), BtnImage.StateOnHover.ToInt());

            SetToolTip(btnState, Resources.ToolTipStateClosing, Key.State);

            Utils.Log.Info($"{ScaleTerminal.PortName} opened. Type = {ScaleTerminal.Type}");
        }

        private void ScaleTerminal_Opened(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                ScaleTerminalOpened();
            });
        }

        private void ScaleTerminalClosed()
        {
            WeightClear();

            ibtnState.SetImages(BtnImage.StateOffNormal.ToInt(), BtnImage.StateOffHover.ToInt());

            SetToolTip(btnState, Resources.ToolTipStateOpening, Key.State);

            Utils.Log.Info($"{ScaleTerminal.PortName} closed");
        }

        private void ScaleTerminal_Closed(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                ScaleTerminalClosed();
            });
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

        private void WeightClear()
        {
            weight = int.MaxValue;

            channelWeight[0] = int.MaxValue;
            channelWeight[1] = int.MaxValue;
            channelWeight[2] = int.MaxValue;
            channelWeight[3] = int.MaxValue;

            Weight = 0;

            SetChannel(Channel.LeftFar, 0);
            SetChannel(Channel.RightFar, 0);
            SetChannel(Channel.LeftNear, 0);
            SetChannel(Channel.RightNear, 0);
        }

        private string WeightToStr(int value)
        {
            return Utils.WeightToStr(value, AppSettings.Default.OutputMassUnit);
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
                if (weight == value) return;

                weight = value;

                lblWeight.Text = WeightToStr(value);
            }
        }

        public string Status
        {
            set
            {
                lblStatus.Text = value;
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

        private Channel ChannelFromTerminal(int channel)
        {
            switch (channel)
            {
                default:
                    return AppSettings.Default.Channel1;
                case 1:
                    return AppSettings.Default.Channel2;
                case 2:
                    return AppSettings.Default.Channel3;
                case 3:
                    return AppSettings.Default.Channel4;
            }
        }

        private void DoWeightReceived(WeightEventArgs weightEvent)
        {
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    Weight = weightEvent.Weight;

                    if (ChannelsVisible)
                    {
                        for (var channel = 0; channel < ScaleTerminal.ChannelCount; channel++)
                        {
                            SetChannel(ChannelFromTerminal(channel), weightEvent.Channels[channel]);
                        }
                    }
                });
            }
            catch (Exception e)
            {
                DebugWrite.Error(e);
            }
        }

        private void ScaleTerminal_WeightReceived(object sender, WeightEventArgs e)
        {
            if (ScaleTerminal.IsMultiChannel)
            {
                DebugWrite.Line($"Weight = {e.Weight}, Channels = {string.Join(", ", e.Channels)}");
            }
            else
            {
                DebugWrite.Line($"Weight = {e.Weight}");
            }

            DoWeightReceived(e);
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

        private void SetToolTip(Control control, string text, Key key)
        {
            if (key != Key.None)
            {
                text = string.Format(Resources.ToolTipKey, text, (Keys)key);
            }

            toolTip.SetToolTip(control, text);
        }

        private void SetToolTip(Control control, Key key)
        {
            SetToolTip(control, toolTip.GetToolTip(control), key);
        }

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
                        }
                    }
                    else
                    {
                        if (ScaleTerminal.IsOpen)
                        {
                            ScaleTerminal.Close();
                        }
                    }
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

            btnChannels.Visible = ScaleTerminal.IsMultiChannel && AppSettings.Default.ChannelCount != ChannelCount.One;

            ChannelsVisible = btnChannels.Visible;

            WeightClear();
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

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((Key)e.KeyData)
            {
                case Key.About:
                    ShowAbout();
                    break;
                case Key.State:
                    TerminalState = !TerminalState;
                    break;
                case Key.Channels:
                    ChannelsVisible = !ChannelsVisible;
                    break;
                case Key.Settings1:
                case Key.Settings2:
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
                    Status = Resources.AppUpdateInfoStatusCheckLatest;
                    break;
                case UpdateStatus.Download:
                    Status = Resources.AppUpdateInfoStatusDownload;
                    break;
                case UpdateStatus.ArchiveExtract:
                    Status = Resources.AppUpdateInfoStatusExtract;
                    break;
                case UpdateStatus.Check:
                case UpdateStatus.CheckLocal:
                case UpdateStatus.Update:
                case UpdateStatus.Idle:
                default:
                    Status = string.Empty;
                    break;
            }
        }

        private bool channels = false;
        public bool ChannelsVisible
        {
            get { return channels; }
            set
            {
                channels = value;

                ShowChannels(channels);
            }
        }

        private void ShowChannels(bool visible)
        {
            SuspendLayout();

            if (AppSettings.Default.ChannelCount == ChannelCount.One)
            {
                visible = false;
            }

            lblChannelLeftFar.Visible = visible;
            lblChannelRightFar.Visible = visible && AppSettings.Default.ChannelCount != ChannelCount.TwoVertical;
            lblChannelLeftNear.Visible = visible && AppSettings.Default.ChannelCount != ChannelCount.TwoHorizontal;
            lblChannelRightNear.Visible = visible && AppSettings.Default.ChannelCount == ChannelCount.Four;

            lblDiffFar.Visible = lblChannelRightFar.Visible;
            lblDiffNear.Visible = lblChannelLeftNear.Visible && lblChannelRightNear.Visible;
            lblDiffLeft.Visible = lblChannelLeftNear.Visible;
            lblDiffRight.Visible = lblChannelRightNear.Visible;

            if (visible)
            {
                SetBounds(Left, Top, 544, 271);
            }
            else
            {
                SetBounds(Left, Top, 304, 175);
            }

            btnChannels.Left = (ClientSize.Width - btnChannels.Width) / 2;

            lblWeight.SetBounds((ClientSize.Width - lblWeight.Width) / 2,
                                (ClientSize.Height - lblWeight.Height) / 2,
                                lblWeight.Width, lblWeight.Height);

            ResumeLayout();
        }

        private void BtnChannels_Click(object sender, EventArgs e)
        {
            ChannelsVisible = !ChannelsVisible;
        }

        private readonly int[] channelWeight = new int[4] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };

        private Label GetChannelLabel(Channel channel)
        {
            switch (channel)
            {
                case Channel.RightFar:
                    return lblChannelRightFar;
                case Channel.LeftNear:
                    return lblChannelLeftNear;
                case Channel.RightNear:
                    return lblChannelRightNear;
                default:
                    return lblChannelLeftFar;
            }
        }

        private void UpdateDiffs(Channel channel)
        {
            int diffLR;
            int diffFN;

            switch (channel)
            {
                case Channel.LeftFar:
                    diffLR = GetChannel(channel) - GetChannel(Channel.RightFar);
                    diffFN = GetChannel(channel) - GetChannel(Channel.LeftNear);

                    lblDiffFar.Text = WeightToStr(Math.Abs(diffLR));
                    lblDiffLeft.Text = WeightToStr(Math.Abs(diffFN));

                    break;
                case Channel.RightFar:
                    diffLR = GetChannel(Channel.LeftFar) - GetChannel(channel);
                    diffFN = GetChannel(channel) - GetChannel(Channel.RightNear);

                    lblDiffFar.Text = WeightToStr(Math.Abs(diffLR));
                    lblDiffRight.Text = WeightToStr(Math.Abs(diffFN));

                    break;
                case Channel.LeftNear:
                    diffLR = GetChannel(channel) - GetChannel(Channel.RightNear);
                    diffFN = GetChannel(Channel.LeftFar) - GetChannel(channel);

                    lblDiffNear.Text = WeightToStr(Math.Abs(diffLR));
                    lblDiffLeft.Text = WeightToStr(Math.Abs(diffFN));

                    break;
                case Channel.RightNear:
                    diffLR = GetChannel(Channel.LeftNear) - GetChannel(channel);
                    diffFN = GetChannel(Channel.RightFar) - GetChannel(channel);

                    lblDiffNear.Text = WeightToStr(Math.Abs(diffLR));
                    lblDiffRight.Text = WeightToStr(Math.Abs(diffFN));

                    break;
            }
        }

        private void SetChannel(Channel channel, int value)
        {
            if (channelWeight[(int)channel] == value) return;

            channelWeight[(int)channel] = value;

            GetChannelLabel(channel).Text = WeightToStr(value);

            UpdateDiffs(channel);
        }

        private int GetChannel(Channel channel)
        {
            return channelWeight[(int)channel];
        }

#if DEBUG
        readonly Random random = new Random();

        int GetRandomWeight()
        {
            return 1000 - random.Next(2000);
        }

        private void LblChannelLeftFar_Click(object sender, EventArgs e)
        {
            SetChannel(Channel.LeftFar, GetRandomWeight());
        }

        private void LblChannelRightFar_Click(object sender, EventArgs e)
        {
            SetChannel(Channel.RightFar, GetRandomWeight());
        }

        private void LblChannelLeftNear_Click(object sender, EventArgs e)
        {
            SetChannel(Channel.LeftNear, GetRandomWeight());
        }

        private void LblChannelRightNear_Click(object sender, EventArgs e)
        {
            SetChannel(Channel.RightNear, GetRandomWeight());
        }
#endif
    }
}