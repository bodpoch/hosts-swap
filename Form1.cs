using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SWAP
{
    public partial class Form1 : Form
    {
        string path = @"C:\Windows\System32\drivers\etc\hosts";
        string createText = "# Copyright (c) Microsoft Corp. This is a sample HOSTS file used by Microsoft TCP/IP for Windows" + Environment.NewLine + "#" + Environment.NewLine + "# This is a sample HOSTS file used by Microsoft TCP/IP for Windows" + Environment.NewLine + "#" + Environment.NewLine + "# This file contains the mappings of IP addresses to host names. Each" + Environment.NewLine + "# entry should be kept on an individual line. The IP address should" + Environment.NewLine + "# be placed in the first column followed by the corresponding host name." + Environment.NewLine + "# The IP address and the host name should be separated by at least one" + Environment.NewLine + "# space." + Environment.NewLine + "#" + Environment.NewLine + "# Additionally, comments (such as these) may be inserted on individual" + Environment.NewLine + "# lines or following the machine name denoted by a '#' symbol." + Environment.NewLine + "#" + Environment.NewLine + "# For example:" + Environment.NewLine + "#" + Environment.NewLine + "#      102.54.94.97     rhino.acme.com          # source server" + Environment.NewLine + "#       38.25.63.10     x.acme.com              # x client host" + Environment.NewLine + Environment.NewLine + "# localhost name resolution is handled within DNS itself." + Environment.NewLine + "#	127.0.0.1       localhost" + Environment.NewLine + "#	::1             localhost" + Environment.NewLine;
        string[] srvs = new string[]{ "192.168.1.1 domain_name_1", "192.168.1.2 domain_name_2", "192.168.1.3 domain_name_3", "192.168.1.4 domain_name_4", "192.168.1.5 domain_name_5", "192.168.1.6 domain_name_6" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string modText = createText + srvs[listBox1.SelectedIndex] + Environment.NewLine;
            File.WriteAllText(path, modText, Encoding.UTF8);
            button2.BackColor = System.Drawing.Color.Green;
            notifyIcon1.Text = "HOSTS SWAP: " + listBox1.SelectedItem;
            label1.Text = "Active: " + listBox1.SelectedItem;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}