using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notify.Notify.Forms
{
    public partial class NewConnectionForm : Form
    {
        private static EventHandler accept_handler = null;
        private static EventHandler deny_handler = null;

        public NewConnectionForm(EventHandler acceptHandler, EventHandler denyHandler, string ip)
        {
            accept_handler = acceptHandler;
            deny_handler = denyHandler;
            InitializeComponent(ip);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            accept_handler(sender, e);
        }

        private void DenyButton_Click(object sender, EventArgs e)
        {
            deny_handler(sender, e);
        }
    }
}