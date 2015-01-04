using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wolcano.Engine
{
    public class PowerEngineSettings : ICloneable
    {
        public String DefaultMac { get; set; }
        public String DefaultIp { get; set; }
        public int DefaultPort { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
