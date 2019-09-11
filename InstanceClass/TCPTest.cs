using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    
    public class TCPTest : TestBase ,ITestBase
    {
        private static TCPTest _Instance;
        public static TCPTest Instance {
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


        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
        public void listen()
        {
            string ip = "127.0.0.1";
            int port = 9361;
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
            }
            catch (Exception ee)
            {

            }
        }
    }
}
