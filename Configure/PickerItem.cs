using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiAuth.Configure
{
    class PickerItem
    {
        public string name { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public PickerItem(string name, string MACAddress, string IPAddress)
        {
            this.name = name;
            this.MACAddress = MACAddress;
            this.IPAddress = IPAddress;
        }
        public string ToString()
        {
            return this.name;
        }
    }
}
