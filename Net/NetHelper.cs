using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


public static class NetHelper
{
    public static IPAddress LocalIp()
    {
        string hostName = Dns.GetHostName();
        IPHostEntry iPHostEntry = Dns.GetHostEntry(hostName);
        IPAddress ipv4 = null;
        for (int i = 0; i < iPHostEntry.AddressList.Length; i++)
        {
            if (iPHostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
            {
                ipv4 = iPHostEntry.AddressList[i];
                break;
            }
        }
        return ipv4;
    }
}
