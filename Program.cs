﻿using System;
using System.Windows.Forms;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Notify.Forms;
using Notify.Managers;
using Notify.Api;

namespace Notify
{
    internal static class Program
    {
        public static MainForm mainForm = null;

        public static readonly ContactsManager Contacts = new ContactsManager();
        public static readonly MessageManager Messages = new MessageManager(Contacts);

        private static readonly int Port = 3000;

        [STAThread]
        private static void Main(string[] args)
        {
            new Notification();
            //CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            //Application.Run(mainForm);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>().UseUrls(new string[] { "http://0.0.0.0:" + Port, "http://localhost:" + Port });
    }
}