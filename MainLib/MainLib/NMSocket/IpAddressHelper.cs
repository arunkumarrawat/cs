using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MainLib.NMSocket
{
    /// <summary>
    /// All Ip Address helper
    /// </summary>
    public class IpAddressHelper
    {
        /// <summary>
        /// Is Private ipv4 address
        /// </summary>
        /// <param name="ipv4Address"></param>
        /// <returns></returns>
        public bool IsPrivateIpv4Address(string ipv4Address)
        {
            long intAddress = IPv4StringToInt64(ipv4Address);

            long AddressStart = IPv4StringToInt64("192.168.0.0");
            long AddressEnd = IPv4StringToInt64("192.168.255.255");

            if (intAddress >= AddressStart && intAddress <= AddressEnd)
                return true;

            AddressStart = IPv4StringToInt64("10.0.0.0");
            AddressEnd = IPv4StringToInt64("10.255.255.255");

            if (intAddress >= AddressStart && intAddress <= AddressEnd)
                return true;

            AddressStart = IPv4StringToInt64("172.16.0.0");
            AddressEnd = IPv4StringToInt64("172.31.255.255");
            if (intAddress >= AddressStart && intAddress <= AddressEnd)
                return true;


            return false;
        }

        /// <summary>
        /// Ipv4 to long
        /// </summary>
        /// <param name="ipv4String"></param>
        /// <returns></returns>
        public Int64 IPv4StringToInt64(string ipv4String)
        {
            Int64 ipInteger = 0;
            ipInteger = (long)(uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse(ipv4String).GetAddressBytes(), 0));
            return ipInteger;
        }

        /// <summary>
        /// check address string is ipv4 address
        /// </summary>
        /// <param name="strIpAddress"></param>
        /// <returns></returns>
        public bool IsIPv4Address(string strIpAddress)
        {
            var address = System.Net.IPAddress.Parse(strIpAddress);

            if (address == null) return false;

            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return true;
            }
            return false;
        }
    }
}
