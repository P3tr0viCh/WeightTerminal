using P3tr0viCh.Utils;
using System;
using System.Windows.Forms;
using WeightTerminal.Properties;

namespace WeightTerminal
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        public static bool ShowDlg(IWin32Window owner)
        {
            using (var frm = new FrmSettings())
            {
                Utils.Log.WriteFormOpen(frm);

                try
                {
                    AppSettings.Save();

                    if (frm.ShowDialog(owner) == DialogResult.OK)
                    {
                        AppSettings.Save();

                        return true;
                    }
                    else
                    {
                        AppSettings.Load();

                        return false;
                    }
                }
                finally
                {
                    Utils.Log.WriteFormClose(frm);
                }
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = AppSettings.Default;
        }

        private bool CheckChannels()
        {
            if (AppSettings.Default.Channel1 == AppSettings.Default.Channel2 ||
                AppSettings.Default.Channel1 == AppSettings.Default.Channel3 ||
                AppSettings.Default.Channel1 == AppSettings.Default.Channel4)
            {
                return false;
            }
            if (AppSettings.Default.Channel2 == AppSettings.Default.Channel3 ||
                AppSettings.Default.Channel2 == AppSettings.Default.Channel4)
            {
                return false;
            }
            if (AppSettings.Default.Channel3 == AppSettings.Default.Channel4)
            {
                return false;
            }

            return true;
        }

        private bool CheckData()
        {
            if (!CheckChannels())
            {
                Msg.Error(Resources.ErrorCheckChannels);

                return false;
            }

            return true;
        }

        private bool ApplyData()
        {
            return CheckData();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (ApplyData())
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}