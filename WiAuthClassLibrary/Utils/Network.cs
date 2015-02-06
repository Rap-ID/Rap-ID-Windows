using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace WiAuth.ClassLibrary
{
    public static class NetworkPorts
    {
        public const int Boradcast = 49160;
        public const int Pair = 49161;
        public const int Auth = 49161;
    }

    public static class NetworkUtils
    {
        [System.Runtime.InteropServices.DllImport("iphlpapi.dll", ExactSpelling = true)]
        static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref int PhyAddrLen);

        /// <summary>
        /// Gets the MAC address (<see cref="PhysicalAddress"/>) associated with the specified IP.
        /// http://www.codeproject.com/KB/IP/host_info_within_network.aspx
        /// </summary>
        /// <param name="ipAddress">The remote IP address.</param>
        /// <returns>The remote machine's MAC address.</returns>
        public static PhysicalAddress GetMacAddress(IPAddress ipAddress)
        {
            const int MacAddressLength = 6;
            int length = MacAddressLength;
            var macBytes = new byte[MacAddressLength];
            SendARP(BitConverter.ToInt32(ipAddress.GetAddressBytes(), 0), 0, macBytes, ref length);
            return new PhysicalAddress(macBytes);
        }
        /// <summary>
        /// http://pietschsoft.com/post/2009/11/08/Resolve_IP_Address_And_Host_Name_From_MAC_Address_using_CSharp_and_Windows_ARP_Utility
        /// </summary>
        /// <param name="macAddress"></param>
        /// <returns></returns>
        public static IPAddress GetIPAddress(PhysicalAddress macAddress)
        {
            return IPAddress.Parse(IPInfo.GetIPInfo(macAddress.ToString()).IPAddress);
        }
    }

    /// <summary>
    /// This class allows you to retrieve the IP Address and Host Name for a specific machine on the local network when you only know it's MAC Address.
    /// http://pietschsoft.com/post/2009/11/08/Resolve_IP_Address_And_Host_Name_From_MAC_Address_using_CSharp_and_Windows_ARP_Utility
    /// </summary>
    class IPInfo
    {
        public IPInfo(string macAddress, string ipAddress)
        {
            this.MacAddress = macAddress;
            this.IPAddress = ipAddress;
        }

        public string MacAddress { get; private set; }
        public string IPAddress { get; private set; }

        private string _HostName = string.Empty;
        public string HostName
        {
            get
            {
                if (string.IsNullOrEmpty(this._HostName))
                {
                    try
                    {
                        // Retrieve the "Host Name" for this IP Address. This is the "Name" of the machine.
                        this._HostName = Dns.GetHostEntry(this.IPAddress).HostName;
                    }
                    catch
                    {
                        this._HostName = string.Empty;
                    }
                }
                return this._HostName;
            }
        }


        #region "Static Methods"

        /// <summary>
        /// Retrieves the IPInfo for the machine on the local network with the specified MAC Address.
        /// </summary>
        /// <param name="macAddress">The MAC Address of the IPInfo to retrieve.</param>
        /// <returns></returns>
        public static IPInfo GetIPInfo(string macAddress)
        {
            var ipinfo = (from ip in IPInfo.GetIPInfo()
                          where ip.MacAddress.ToLowerInvariant() == macAddress.ToLowerInvariant()
                          select ip).FirstOrDefault();

            return ipinfo;
        }

        /// <summary>
        /// Retrieves the IPInfo for All machines on the local network.
        /// </summary>
        /// <returns></returns>
        public static List<IPInfo> GetIPInfo()
        {
            try
            {
                var list = new List<IPInfo>();

                foreach (var arp in GetARPResult().Split(new char[] { '\n', '\r' }))
                {
                    // Parse out all the MAC / IP Address combinations
                    if (!string.IsNullOrEmpty(arp))
                    {
                        var pieces = (from piece in arp.Split(new char[] { ' ', '\t' })
                                      where !string.IsNullOrEmpty(piece)
                                      select piece).ToArray();
                        if (pieces.Length == 3)
                        {
                            list.Add(new IPInfo(pieces[1], pieces[0]));
                        }
                    }
                }

                // Return list of IPInfo objects containing MAC / IP Address combinations
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Parsing 'arp -a' results", ex);
            }
        }

        /// <summary>
        /// This runs the "arp" utility in Windows to retrieve all the MAC / IP Address entries.
        /// </summary>
        /// <returns></returns>
        private static string GetARPResult()
        {
            Process p = null;
            string output = string.Empty;

            try
            {
                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                });

                output = p.StandardOutput.ReadToEnd();

                p.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("IPInfo: Error Retrieving 'arp -a' Results", ex);
            }
            finally
            {
                if (p != null)
                {
                    p.Close();
                }
            }

            return output;
        }

        #endregion
    }
}
