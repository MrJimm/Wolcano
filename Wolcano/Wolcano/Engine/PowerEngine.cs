using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Xml;

namespace Wolcano.Engine
{
    public class PowerEngine
    {
        public PowerEngineSettings Settings { get; private set; }

        public PowerEngine()
        {
            this.Settings = new PowerEngineSettings();
            this.LoadDefaultSettings();
        }

        public bool LoadSettings(String fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return false;
            }

            var tmpSettings = (PowerEngineSettings)this.Settings.Clone();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);

                var powerSettingsRoot = xmlDoc.GetElementsByTagName("PowerEngineSettings").Cast<XmlNode>().FirstOrDefault();

                if (powerSettingsRoot != null)
                {
                    var powerChilds = powerSettingsRoot.ChildNodes.Cast<XmlNode>();
                    if (powerChilds != null)
                    {
                        var defIp = powerChilds.FirstOrDefault(x => x.Name == "DefaultIp");
                        if (defIp != null)
                        {
                            this.Settings.DefaultIp = defIp.InnerText;
                        }
                        else
                        {
                            return false;
                        }

                        var defMac = powerChilds.FirstOrDefault(x => x.Name == "DefaultMac");
                        if (defMac != null)
                        {
                            this.Settings.DefaultMac = defMac.InnerText;
                        }
                        else
                        {
                            return false;
                        }

                        var defPort = powerChilds.FirstOrDefault(x => x.Name == "DefaultPort");
                        if (defPort != null)
                        {
                            this.Settings.DefaultPort = Int32.Parse(defPort.InnerText);
                        }
                        else
                        {
                            return false;
                        }

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                
            }
            catch
            {
                this.Settings = tmpSettings;
                return false;
            }
        }

        public void LoadDefaultSettings()
        {
            var defSettings = this.GetDefaultSettings();

            this.Settings.DefaultIp = defSettings.DefaultIp;
            this.Settings.DefaultMac = defSettings.DefaultMac;
            this.Settings.DefaultPort = defSettings.DefaultPort;
        }

        public PowerEngineSettings GetDefaultSettings()
        {
            return new PowerEngineSettings()
            {
                DefaultIp = "127.0.0.1",
                DefaultMac = "00-00-00-00-00-00",
                DefaultPort = 7
            };
        }

        public bool WakeOnLan(String macAddress, String ipAddress, int port)
        {
            var ip = IPAddress.Parse(ipAddress);
            var mac = PhysicalAddress.Parse(macAddress);

            return this.WakeOnLan(mac, ip, port);
        }

        public bool WakeOnLan(PhysicalAddress macAddress, IPAddress ipAddress, int port)
        {
            WOLSender sender = new WOLSender();
            sender.Connect(ipAddress, port);

            var sendBytes = new List<byte>();
            for (int i = 0; i < 6; ++i)
            {
                sendBytes.Add(0xFF);
            }

            PhysicalAddress mac = macAddress;
            var macBytes = mac.GetAddressBytes();

            for (int i = 0; i < 16; ++i)
            {
                sendBytes.AddRange(macBytes);
            }

            var sendArray = sendBytes.ToArray();

            var res = sender.Send(sendArray, sendArray.Count());
            return true;
        }
    }
}
