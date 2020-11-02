using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Notify
{
    internal static class Program
    {
        private static MainForm mainForm = null;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}