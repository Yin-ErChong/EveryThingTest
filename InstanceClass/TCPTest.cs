using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{

    public class TCPTest : TestBase, ITestBase
    {
        private static TCPTest _Instance;
        public static TCPTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TCPTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        public override void Start()
        {
            Task.Run(() =>
            {
                //连接多个客户端  https://www.cnblogs.com/longdb/articles/7015827.html
                listen();
            });
            Thread.Sleep(20000);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
        public void listen()
        {
            string ip = "127.0.0.1";
            int port = 9365;
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
            TcpClient tcpClient = listener.AcceptTcpClient();

            NetworkStream streamToClient = tcpClient.GetStream();
            int BufferSize = int.MaxValue;
            byte[] buffer = new byte[BufferSize];  // BufferSize为缓存的大小
            int bytesRead;
            try
            {
                lock (streamToClient)//为了保证数据的完整性以及安全性  锁定数据流
                {
                    bytesRead = streamToClient.Read(buffer, 0, BufferSize);
                }
                //string reciveMsg = Encoding.Unicode.GetString(bytesRead);
                string str;
                using (streamToClient)
                {
                    byte[] data = new byte[1024];
                    using (MemoryStream ms = new MemoryStream())
                    {

                        int numBytesRead;
                        while ((numBytesRead = streamToClient.Read(data, 0, data.Length)) > 0)
                        {
                            ms.Write(data, 0, numBytesRead);
                        }
                        str = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
                    }
                }
                string msg = "俏丽吗";
                byte[] buffer2 = Encoding.Unicode.GetBytes(msg);
                lock (streamToClient)
                {
                    streamToClient.Write(buffer2, 0, buffer.Length);//buffer为发送的字符数组                   
                }
            }
            catch (Exception ee)
            {

            }
        }
        public void Send()
        {


        }
        //    event EventHandler<TcpClientConnectedEventArgs> ClientConnected;
        //    event EventHandler<TcpClientDisconnectedEventArgs> ClientDisconnected;
        //    event EventHandler<TcpClientDataReceivedEventArgs> ClientDataReceived;
        //    private static void StartServer()
        //    {
        //        _server = new TcpSocketServer(22222);
        //        _server.ClientConnected += server_ClientConnected;
        //        _server.ClientDisconnected += server_ClientDisconnected;
        //        _server.ClientDataReceived += server_ClientDataReceived;
        //        _server.Listen();
        //    }

        //    static void server_ClientConnected(object sender, TcpClientConnectedEventArgs e)
        //    {
        //        Console.WriteLine(string.Format("TCP client {0} has connected {1}.", e.Session.RemoteEndPoint, e.Session));
        //    }

        //    static void server_ClientDisconnected(object sender, TcpClientDisconnectedEventArgs e)
        //    {
        //        Console.WriteLine(string.Format("TCP client {0} has disconnected.", e.Session));
        //    }

        //    static void server_ClientDataReceived(object sender, TcpClientDataReceivedEventArgs e)
        //    {
        //        var text = Encoding.UTF8.GetString(e.Data, e.DataOffset, e.DataLength);
        //        Console.Write(string.Format("Client : {0} {1} --> ", e.Session.RemoteEndPoint, e.Session));
        //        Console.WriteLine(string.Format("{0}", text));
        //        _server.Broadcast(Encoding.UTF8.GetBytes(text));
        //    }
        //}
    }
}
