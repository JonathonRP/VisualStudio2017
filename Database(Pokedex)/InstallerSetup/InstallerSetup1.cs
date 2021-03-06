﻿using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Reflection;

namespace InstallerSetup
{
    [RunInstaller(true)]
    public partial class InstallerSetup1 : Installer
    {
        public InstallerSetup1()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary savedState)
        {
            try
            {
                if (Context.Parameters["DATABASECONNECTIONPROVIDER"] == "1")
                {
                    Process.Start($".\\AccessDatabaseEngine.exe");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                base.Rollback(savedState);
            }

            base.Install(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Uninstall(IDictionary savedState)
        {
            Process application = null;
            foreach (var process in Process.GetProcesses())
            {
                if (!process.ProcessName.ToLower().Contains("Database(Pokedex)")) continue;
                application = process;
                break;
            }
            if (application != null && application.Responding)
            {
                application.Kill();
                base.Uninstall(savedState);
            }
        }

        private void showParameters()
        {
            StringBuilder sb = new StringBuilder();
            StringDictionary myStringDictionary = this.Context.Parameters;
            if (this.Context.Parameters.Count > 0)
            {
                foreach (string myString in this.Context.Parameters.Keys)
                {
                    sb.AppendFormat("String={0} Value= {1}\n", myString,
                    this.Context.Parameters[myString]);
                }
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
