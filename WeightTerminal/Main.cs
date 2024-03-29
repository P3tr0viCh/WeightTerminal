﻿using P3tr0viCh.ScaleTerminal;
using P3tr0viCh.Utils;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using WA;
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
        }

        private readonly ScaleTerminal ScaleTerminal = new ScaleTerminal();

        private BtnImage StateNormal = BtnImage.StateOffNormal;
        private BtnImage StateHover = BtnImage.StateOffHover;

        public Main()
        {
            InitializeComponent();

            Utils.Log.Default.WriteProgramStart();

            AppSettings.Directory = Files.ExecutableDirectory();

            Utils.Log.Debug($"Settings: {AppSettings.FilePath}");
        }

        protected override void WndProc(ref Message m)
        {
            AppOneInstance.CheckAndShowApplication(m, this);

            base.WndProc(ref m);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetBtnImage(btnAbout, BtnImage.AboutNormal);
            SetBtnImage(btnState, StateNormal);
            SetBtnImage(btnSettings, BtnImage.SettingsNormal);

            SetToolTip(btnAbout, KeyAbout);
            SetToolTip(btnState, Resources.ToolTipStateOpening, KeyState);
            SetToolTip(btnSettings, KeySettings1);

            ScaleTerminal.LineReceived += ScaleTerminal_LineReceived;
            ScaleTerminal.WeightReceived += ScaleTerminal_WeightReceived;

            AppSettingsLoad();

            SettingsChanged();

            Weight = 0;
        }

        private void ScaleTerminal_LineReceived(object sender, LineEventArgs e)
        {
            Utils.Log.Debug($">{e.Line}<");
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

                switch (AppSettings.Default.OutputMassUnit)
                {
                    case Enums.MassUnit.tn:
                        lblWeight.Text = (weight / 1000.0).ToString("0.000");

                        break;
                    default:
                        lblWeight.Text = weight.ToString();

                        break;
                }
            }
        }

        private void ScaleTerminal_WeightReceived(object sender, WeightEventArgs e)
        {
            this.InvokeIfNeeded(() => Weight = e.Weight);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            TerminalState = false;

            AppSettingsSave();

            Utils.Log.Default.WriteProgramStop();
        }

        public void AppSettingsLoad()
        {
            if (AppSettings.Default.Load()) return;

            Utils.Log.Error(AppSettings.LastError);
        }

        public void AppSettingsSave()
        {
            if (AppSettings.Default.Save()) return;

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

        private void SetBtnImage(PictureBox button, BtnImage image)
        {
            button.Image = imageList.Images[(int)image];
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

                            if (string.IsNullOrEmpty(ScaleTerminal.PortName))
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

                            Weight = 0;

                            StateNormal = BtnImage.StateOffNormal;
                            StateHover = BtnImage.StateOffHover;

                            SetToolTip(btnState, Resources.ToolTipStateOpening, KeyState);

                            Utils.Log.Info($"{ScaleTerminal.PortName} closed");
                        }
                    }

                    SetBtnImage(btnState,
                        MouseIsOverControl(btnState) ?
                            StateHover :
                            StateNormal);
                }
                catch (Exception e)
                {
                    Utils.Log.Error(e);

                    Utils.Msg.Error(Resources.ErrorError, e.Message);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnState_MouseEnter(object sender, EventArgs e)
        {
            SetBtnImage(btnState, StateHover);
        }

        private void BtnState_MouseLeave(object sender, EventArgs e)
        {
            SetBtnImage(btnState, StateNormal);
        }

        private void BtnAbout_MouseEnter(object sender, EventArgs e)
        {
            SetBtnImage(btnAbout, BtnImage.AboutHover);
        }

        private void BtnAbout_MouseLeave(object sender, EventArgs e)
        {
            SetBtnImage(btnAbout, BtnImage.AboutNormal);
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

            TerminalState = false;

            if (CheckComPortsExists())
            {
                btnState.Enabled = true;
            }
            else
            {
                btnState.Enabled = false;

                return;
            }

            if (string.IsNullOrEmpty(AppSettings.Default.ComPortName))
            {
                Utils.Log.Error("check settings: comportname empty");

                return;
            }

            if (AppSettings.Default.TerminalType == Enums.TerminalType.None)
            {
                Utils.Log.Error("check settings: terminaltype=none");

                return;
            }

            ScaleTerminal.SerialPort.PortName = AppSettings.Default.ComPortName;

            ScaleTerminal.Type = (TerminalType)AppSettings.Default.TerminalType;

            ScaleTerminal.TerminalMassUnit = (MassUnit)AppSettings.Default.TerminalMassUnit;

            if (prevStateOpen)
            {
                TerminalState = true;
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
    }
}