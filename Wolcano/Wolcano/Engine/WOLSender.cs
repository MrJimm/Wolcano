using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Wolcano.Engine
{
    public class WOLSender : UdpClient
    {
        public WOLSender()
            : base()
        {
        }

        public void SetClientToBrodcastMode()
        {
            if (this.Active)
            {
                this.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 0);
            }
        }
    }
}
