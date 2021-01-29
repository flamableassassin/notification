using System;
using System.Drawing;
using System.Windows.Forms;
using Notify.Icons;

namespace Notify
{
    internal class Notification
    {
        public Notification()
        {
            NotifyIcon notifyIcon1 = new NotifyIcon();

            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(10000);
        }

        private static void example()
        {
            NotifyIcon notifyIcon1 = new NotifyIcon();

            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(10000);
        }

        public static void authenticate(int ip, EventHandler handler)
        {
            NotifyIcon notifyIcon1 = new NotifyIcon();
        }
    }
}