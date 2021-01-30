using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using SharpPcap;
using PacketDotNet;
using SharpPcap.LibPcap;

namespace EveryThingTest.Helper
{
    public class WinCapHelper
    {
        private static object syncObj = new object();
        private static WinCapHelper _capInstance;
        public static WinCapHelper WinCapInstance
        {
            get
            {
                if (null == _capInstance)
                {
                    lock (syncObj)
                    {
                        if (null == _capInstance)
                        {
                            _capInstance = new WinCapHelper();
                        }
                    }
                }
                return _capInstance;
            }
        }


        private Thread _thread;


        /// <summary>
        /// when get pocket,callback
        /// </summary>
        public Action<string> _logAction;


        /// <summary>
        /// 过滤条件关键字
        /// </summary>
        public string filter;


        private WinCapHelper()
        {


        }
        public void Listen()
        {


            if (_thread != null && _thread.IsAlive)
            {
                return;
            }

            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;
            PcapDevice device = devices[2];
            //分别启动监听，指定包的处理函数
            device.OnPacketArrival +=
                    new PacketArrivalEventHandler(device_OnPacketArrival);
            device.Open(DeviceMode.Normal, 1000);
            device.Capture();
            //device.StartCapture();
            //_thread.Start();
        }


        /// <summary>
        /// 打印包信息，组合包太复杂了，所以直接把hex字符串打出来了
        /// </summary>
        /// <param name="str"></param>
        /// <param name="p"></param>
        private void PrintPacket(ref string str, Packet p)
        {
            if (p != null)
            {
                string s = p.ToString();
                if (!string.IsNullOrEmpty(filter) && !s.Contains(filter))
                {
                    return;
                }


                str += "\r\n" + s + "\r\n";


                //尝试创建新的TCP / IP数据包对象，
                //第一个参数为以太头长度，第二个为数据包数据块
                str += p.PrintHex() + "\r\n";
            }


        }


        /// <summary>
        /// 接收到包的处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            //解析出基本包
            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);


            //协议类别
            // var dlPacket = PacketDotNet.DataLinkPacket.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);


            //var ethernetPacket = PacketDotNet.EthernetPacket.GetEncapsulated(packet);


            //var internetLinkPacket = PacketDotNet.InternetLinkLayerPacket.Parse(packet.BytesHighPerformance.Bytes);
            //var internetPacket = PacketDotNet.InternetPacket.Parse(packet.BytesHighPerformance.Bytes);


            //var sessionPacket = PacketDotNet.SessionPacket.Parse(packet.BytesHighPerformance.Bytes);
            //var appPacket = PacketDotNet.ApplicationPacket.Parse(packet.BytesHighPerformance.Bytes);
            //var pppoePacket = PacketDotNet.PPPoEPacket.Parse(packet.BytesHighPerformance.Bytes);


            //var arpPacket = PacketDotNet.ARPPacket.GetEncapsulated(packet);
            var ipPacket = (IpPacket)packet.Extract(typeof(IpPacket));
            // var ipPacket = PacketDotNet.IpPacket.GetEncapsulated(packet); //ip包
            //var udpPacket = PacketDotNet.UdpPacket.GetEncapsulated(packet);
            //var tcpPacket = PacketDotNet.TcpPacket.GetEncapsulated(packet);
            string ret = "";
            System.Net.IPAddress dstIp = ipPacket?.DestinationAddress;
            if (dstIp.ToString()== "47.103.92.119")
            {
                PrintPacket(ref ret, packet);
            }
            
            
            //ParsePacket(ref ret, ethernetPacket);
            //ParsePacket(ref ret, internetLinkPacket);
            //ParsePacket(ref ret, internetPacket);
            //ParsePacket(ref ret, sessionPacket);
            //ParsePacket(ref ret, appPacket);
            //ParsePacket(ref ret, pppoePacket);
            //ParsePacket(ref ret, arpPacket);
            //ParsePacket(ref ret, ipPacket);
            //ParsePacket(ref ret, udpPacket);
            //ParsePacket(ref ret, tcpPacket);




            if (!string.IsNullOrEmpty(ret))
            {
                string rlt = "\r\n时间 : " +
                    DateTime.Now.ToLongTimeString() +
                    "\r\n数据包: \r\n" + ret;
                _logAction(rlt);
            }


        }




        public void StopAll()
        {
            foreach (PcapDevice device in SharpPcap.CaptureDeviceList.Instance)
            {


                if (device.Opened)
                {
                    Thread.Sleep(500);
                    device.StopCapture();
                }


                _logAction("device : " + device.Description + " stoped.\r\n");
            }


            _thread.Abort();
        }


    }
}
