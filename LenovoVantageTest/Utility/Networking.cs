using LenovoVantageTest.LogHelper;
using NETCONLib;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace LenovoVantageTest.Utility
{
    public class Networking
    {
        public static bool DisconnectNetwork(NetworkType network)
        {
            bool ret = false;
            NetSharingManagerClass netSharingMgr = new NetSharingManagerClass();
            INetSharingEveryConnectionCollection connections = netSharingMgr.EnumEveryConnection;
            foreach (INetConnection con in connections)
            {
                INetConnectionProps connProps = netSharingMgr.get_NetConnectionProps(con);
                //string type = network.Equals(NetworkType.Wireless) ? "Wi-Fi" : network.ToString();
                string type1 = "";
                string type2 = "";
                if (network.Equals(NetworkType.Wireless))
                {
                    type1 = "Wi-Fi";
                    type2 = "WLAN";
                }
                else
                {
                    type1 = network.ToString();
                }
                if ((connProps.Name == type1 || connProps.Name == type2) && connProps.Status == tagNETCON_STATUS.NCS_CONNECTED)
                {
                    try
                    {
                        con.Disconnect();
                        ret = true;
                        Logger.Instance.WriteLog("Disconnect network successfully:" + connProps.DeviceName, LogType.Information);
                    }
                    catch
                    {
                        Logger.Instance.WriteLog("An exception when disconnect network :" + connProps.DeviceName, LogType.Error);
                        throw;
                    }
                }
            }
            return ret;
        }

        public static bool ConnectNetwork(NetworkType network)
        {
            bool ret = false;
            NetSharingManagerClass netSharingMgr = new NetSharingManagerClass();
            INetSharingEveryConnectionCollection connections = netSharingMgr.EnumEveryConnection;
            foreach (INetConnection con in connections)
            {
                INetConnectionProps connProps = netSharingMgr.get_NetConnectionProps(con);
                //string type = network.Equals(NetworkType.Wireless) ? "Wi-Fi" : network.ToString();
                string type1 = "";
                string type2 = "";
                if (network.Equals(NetworkType.Wireless))
                {
                    type1 = "Wi-Fi";
                    type2 = "WLAN";
                }
                else
                {
                    type1 = network.ToString();
                }
                if ((connProps.Name == type1 || connProps.Name == type2) && connProps.Status == tagNETCON_STATUS.NCS_DISCONNECTED)
                {
                    try
                    {
                        con.Connect();
                        System.Threading.Thread.Sleep(10 * 1000);
                        if (IsNetworkExist(network))
                        {
                            ret = true;
                            Logger.Instance.WriteLog("Connect network successfully:" + connProps.DeviceName, LogType.Information);
                        }
                    }
                    catch
                    {
                        Logger.Instance.WriteLog("An exception when connect network :" + connProps.DeviceName, LogType.Error);
                        throw;
                    }
                }
            }
            return ret;
        }

        public static bool IsNetworkExist(NetworkType network)
        {
            bool ret = false;
            NetSharingManagerClass netSharingMgr = new NetSharingManagerClass();
            INetSharingEveryConnectionCollection connections = netSharingMgr.EnumEveryConnection;
            foreach (INetConnection con in connections)
            {
                INetConnectionProps connProps = netSharingMgr.get_NetConnectionProps(con);
                //string type = network.Equals(NetworkType.Wireless) ? "Wi-Fi" : network.ToString();
                string type1 = "";
                string type2 = "";
                if (network.Equals(NetworkType.Wireless))
                {
                    type1 = "Wi-Fi";
                    type2 = "WLAN";
                }
                else
                {
                    type1 = network.ToString();
                }
                if ((connProps.Name == type1 || connProps.Name == type2) && connProps.Status == tagNETCON_STATUS.NCS_CONNECTED)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public enum NetworkType
        {
            Wireless, Ethernet
        }
    }

    public class WlanNet
    {
        public static void DisconnectNetwork()
        {
            ProcessStartInfo psi =
                  new ProcessStartInfo("netsh", "wlan disconnect");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        public static void ConnectNetwork(string wifiProfileName)
        {
            ProcessStartInfo psi =
                 new ProcessStartInfo("netsh", " wlan connect name=" + wifiProfileName);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
    }

    public class NetWork
    {
        public static bool checkNetWorkConnected(string hostName)
        {
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                string data = "test data";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                PingReply reply = pingSender.Send(hostName, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Warning);
                return false;
            }
            return false;
        }

        /// <summary>
        /// For offline case, use to check current network status
        /// </summary>
        /// <returns></returns>
        public static bool CheckCurrentNetWorkStatus()
        {
            bool currentNetWorkStatus = NetworkInterface.GetIsNetworkAvailable();
            return currentNetWorkStatus;
        }
    }
}
