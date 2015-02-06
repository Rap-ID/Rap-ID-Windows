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
        public PhysicalAddress MAC { get; set; }
        public string Name { get; set; }
        public string DisplayName
        {
            get
            {
                return this.Name;
            }
        }
        public string NetworkIdentifier
        {
            get
            {
                return this.MAC.ToString();
            }
        }
        public string StorgeString
        {
            get
            {
                return this.NetworkIdentifier;
            }
        }
        public new string GetHashCode()
        {
            return this.NetworkIdentifier;
        }
        private Device(string name, IPAddress IP, PhysicalAddress MAC)
        {
            this.Name = name;
            this.IP = IP;
            this.MAC = MAC;
        }
        public Device(string name, IPAddress IP) :
            this(name, IP, NetworkUtils.GetMacAddress(IP))
        {
        }
        public Device(string name, PhysicalAddress MAC) :
            this(name, NetworkUtils.GetIPAddress(MAC), MAC)
        {
        }
        public Device(string name, string NetworkIdentifier) :
            this(name, PhysicalAddress.Parse(NetworkIdentifier))
        {
        }
        public Device(string StorgeString) :
            this(String.Empty, PhysicalAddress.Parse(StorgeString))
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
