using P3tr0viCh.Utils;
using System;
using System.Windows.Forms;

namespace WeightTerminal
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AppOneInstance.IsFirstInstance())
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
                finally
                {
                    AppOneInstance.Exit();
                }
            }
            else
            {
                AppOneInstance.ShowExistsInstance();
            }
        }
    }
}