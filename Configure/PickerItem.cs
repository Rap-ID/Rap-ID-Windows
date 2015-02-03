using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiAuth.Configure
{
    public class PickerItem
    {
        public string name { get; set; }
        public string MACAddress
        {
            get
            {
                //TODO
                return "testMACaddress";
            }
        }
        public System.Net.IPAddress IPAddress { get; set; }
        public PickerItem(string name, System.Net.IPAddress IPAddress)
        {
            this.name = name;
            this.IPAddress = IPAddress;
        }
        public override string ToString()
        {
            return this.name;
        }
        public string Identifier
        {
            get
            {
                return this.IPAddress.ToString();
                //TODO: return this.MACAddress
            }
        }
    }
}
