using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wolcano.Engine;
using System.IO;
using System.Xml;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace Wolcano
{
    public partial class MainForm : Form
    {
        private PowerEngine powerEngine;

        private String SettingsFileName = "settings.xml";

        private void Init()
        {
            powerEngine = new PowerEngine();
            if (File.Exists(SettingsFileName))
            {
                if (!powerEngine.LoadSettings(SettingsFileName))
                {
                    powerEngine.LoadDefaultSettings();
                    this.CreateNewSettings();
                    MessageBox.Show("Error in loading settings!1 Using standard ones.");
                }
            }
            else
            {
                powerEngine.LoadDefaultSettings();
                this.CreateNewSettings();
            }
        }

        private void CreateNewSettings()
        {
            var powerSettings = powerEngine.Settings;

            XmlDocument xmlDoc = new XmlDocument();
            var root = xmlDoc.CreateElement("Settings");
            xmlDoc.AppendChild(root);

            var powerSettingsRoot = xmlDoc.CreateElement("PowerEngineSettings");
            root.AppendChild(powerSettingsRoot);

            var powerDefIp = xmlDoc.CreateElement("DefaultIp");
            powerDefIp.InnerText = powerSettings.DefaultIp;
            powerSettingsRoot.AppendChild(powerDefIp);

            var powerDefMac = xmlDoc.CreateElement("DefaultMac");
            powerDefMac.InnerText = powerSettings.DefaultMac;
            powerSettingsRoot.AppendChild(powerDefMac);

            var powerDefPort = xmlDoc.CreateElement("DefaultPort");
            powerDefPort.InnerText = powerSettings.DefaultPort.ToString();
            powerSettingsRoot.AppendChild(powerDefPort);

            xmlDoc.Save("settings.xml");
        }

        public MainForm()
        {
            InitializeComponent();
            this.Init();
        }

        private void wolButton_Click(object sender, EventArgs e)
        {
            //Application.SetSuspendState(PowerState.Suspend, true, false);

            PhysicalAddress mac = null;
            IPAddress ip = null;
            int? port = null;

            try
            {
                mac = PhysicalAddress.Parse(this.wolMacTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Error in mac format");
                return;
            }

            try
            {
                ip = IPAddress.Parse(this.wolIpTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Error in ip format");
                return;
            }

            try
            {
                port = Int32.Parse(this.wolPortTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Error in port format");
                return;
            }

            this.powerEngine.WakeOnLan(mac, ip, port.Value);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.wolIpTextBox.Text = this.powerEngine.Settings.DefaultIp;
            this.wolMacTextBox.Text = this.powerEngine.Settings.DefaultMac;
            this.wolPortTextBox.Text = this.powerEngine.Settings.DefaultPort.ToString();
        }
    }
}
