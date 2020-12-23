using Communication;
using EveryThingTest.BaseClass;
using EveryThingTest.ExtensionFun;
using EveryThingTest.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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
            TcpClientClient.longlink();
            //MyTcpServer server = new MyTcpServer();
            //server.OpenServer(9361);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
        public void listen()
        {
            string ip = "127.0.0.1";
            int port = 2624;
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
            listener.Start();
            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                NetworkStream streamToClient = tcpClient.GetStream();
                var recieveMsg = streamToClient.ReadStringFromStream();
                Console.WriteLine(recieveMsg);
            }
        }

        public void Send(string msg)
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
