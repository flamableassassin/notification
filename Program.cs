using System;
using System.Windows.Forms;
using Notify.Forms;
using Notify.Managers;

namespace Notify
{
    internal static class Program
    {
        private static MainForm mainForm = null;

        private static readonly ContactsManager Contacts = new ContactsManager();
        private static readonly MessageManager Messages = new MessageManager(Contacts);

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