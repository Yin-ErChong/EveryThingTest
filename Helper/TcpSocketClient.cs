using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.Helper
{
   
    class TcpSocketClient
    {
        Socket socketClient = null;
        public bool OpenClient()
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 创建包含ip和端口号的网络节点对象；
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9361);
            try
            {
                socketClient.Bind(endPoint);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool StartConnect(IPEndPoint endPoint)
        {
             socketClient.Connect(endPoint);//https://www.cnblogs.com/longdb/articles/7015827.html
            return true;
        }
    }
}
