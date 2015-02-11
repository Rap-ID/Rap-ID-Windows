using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace WiAuth.ClassLibrary
{
    public class Device : IEquatable<Device>
    {
        public IPAddress IP { get; set; }
        public string Name { get; set; }
        public string DisplayName
        {
            get
            {
                return this.Name;
            }
        }
        public string StorgeString
        {
            get
            {
                return this.DisplayName;
            }
        }
        public override int GetHashCode()
        {
            return this.DisplayName.GetHashCode();
        }
        public Device(string name, IPAddress IP)
        {
            this.Name = name;
            this.IP = IP;
        }
        public Device(string name, string IP)
            : this(name, IPAddress.Parse(IP))
        {
        }
        public bool Equals(Device d)
        {
            return this.GetHashCode() == d.GetHashCode();
        }
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
