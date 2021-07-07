using BiddingAssistant.HttpHelper;
using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class VMLoginTest : TestBase, ITestBase
    {
        private static VMLoginTest _Instance;
        public static VMLoginTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new VMLoginTest();
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
            Console.WriteLine("It'Start");
            Task.Run(()=> {
                var pa= 打开浏览器("F4CC75C8-19B9-4D24-83F4-36344C0795E0",true);
                Console.WriteLine(pa.Result);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(2000);
                    var pa2 = 跳转到("F4CC75C8-19B9-4D24-83F4-36344C0795E0", "www.baidu.com");
                    Thread.Sleep(2000);
                    var pa3 = 跳转到("F4CC75C8-19B9-4D24-83F4-36344C0795E0", "www.jd.com");
                    Console.WriteLine(pa2.Result);
                    Console.WriteLine(pa3.Result);
                }


            });
            Task.Run(() => {
                var pa = 打开浏览器("000FAFCF-AD4E-4B04-8C58-E245023D9E71", true);
                Console.WriteLine(pa.Result);
                for (int i = 0; i < 20; i++)
                {
                    Thread.Sleep(2000);
                    var pa2 = 跳转到("000FAFCF-AD4E-4B04-8C58-E245023D9E71", "www.baidu.com");
                    Thread.Sleep(2000);
                    var pa3 = 跳转到("000FAFCF-AD4E-4B04-8C58-E245023D9E71", "www.jd.com");

                    Console.WriteLine(pa2.Result);

                    Console.WriteLine(pa3.Result);
                }

            });

        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
        public PaResponse 打开浏览器(string fileId,bool skiplock)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsGet = true;
            httpRequestModel.Url = $"http://127.0.0.1:35000/api/v1/profile/start?profileId={fileId}&skiplock={skiplock}";
            return  HttpRequestService.AskData(httpRequestModel);
        }
        public PaResponse 跳转到(string fileId, string url)
        {
            HttpRequestModel httpRequestModel = new HttpRequestModel();
            httpRequestModel.IsGet = true;
            httpRequestModel.Url = $"http://127.0.0.1:35000/api/v1/profile/openurl?profileId={fileId}&url={url}";
            return  HttpRequestService.AskData(httpRequestModel);
        }
    }
}
