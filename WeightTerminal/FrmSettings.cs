using System;
using System.Windows.Forms;
using WeightTerminal;

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
                Utils.Log.Default.WriteFormOpen(frm);

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
                    Utils.Log.Default.WriteFormClose(frm);
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