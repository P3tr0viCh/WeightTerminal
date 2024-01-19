using System;
using System.Windows.Forms;
using WeightTerminal;
using WeightTerminal.Properties;

namespace WA
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
                    AppSettings.Default.Save();

                    if (frm.ShowDialog(owner) == DialogResult.OK)
                    {
                        AppSettings.Default.Save();

                        return true;
                    }
                    else
                    {
                        AppSettings.Default.Load();

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}