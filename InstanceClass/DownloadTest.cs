using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    
    public class DownloadTest : TestBase ,ITestBase
    {
        private static DownloadTest _Instance;
        public static DownloadTest Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DownloadTest();                   
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
            string url = "https://y.yishenguiji.com/jhxx_newprint/uploadFiles/wechat/fa731ba9032f12a64ea72e660c93e903.png?visitType=h5";
            WebClient webClient = new WebClient();
            byte[] bs=  webClient.DownloadData(url);
            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
