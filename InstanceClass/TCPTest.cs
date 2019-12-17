using EveryThingTest.BaseClass;
using EveryThingTest.ExtensionFun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestUtil.Helper;

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
            Console.WriteLine("我是服务端");
            TcpSocketService2.SocketServie();
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
}
