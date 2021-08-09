using BiddingAssistant.HttpHelper;
using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryThingTest.InstanceClass
{
    public class HttpRequestTest : TestBase, ITestBase
    {
        private static HttpRequestTest _Instance;
        public static HttpRequestTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HttpRequestTest();
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
            HttpRequestModel requestModel = new HttpRequestModel();
            //requestModel.Url = "https://localhost:44317/api/Test/AddUser2";
            //requestModel.IsPost = true;
            //requestModel.Data = "{\"name\":\"string\",\"passWord\":\"string\",\"gender\":\"string\",\"email\":\"string\",\"province\":\"string\",\"city\":\"string\",\"birthday\":\"2021-07-20T12:47:38.610Z\",\"type\":0,\"classId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"createTime\":\"2021-07-20T12:47:38.610Z\",\"modifiedTime\":\"2021-07-20T12:47:38.610Z\"}";

            //requestModel.Url = "https://localhost:44317/api/Test/AddBook";
            //requestModel.IsPost = true;
            //requestModel.Data = "{\"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"name\": \"string\",\"card\": \"string\",\"autho\": \"string\",\"num\": 0,\"press\": \"string\",\"type\": \"string\"}";


            //requestModel.Url = "https://www.baidu.com/home/xman/data/tipspluslist?indextype=manht&_req_seqid=0x87f2ede5000d0002&asyn=1&t=1626786369614&sid=31254_26350";
            //requestModel.IsGet = true;

            requestModel.Url = "https://bizapi.csdn.net/im-manage/v1.0/dispatch/do";
            requestModel.IsPost = true;
            requestModel.Data = "{\"appId\": \"CSDN - PC\",\"channelType\": \"privateMsg\",\"deviceId\": \"10_16980723810 -1544861542295-167084\",\"groupId\": \"CSDN -private-MSG\",\"linkType\": \"1\",\"token\": \"\",\"userId\": \"yinerchong\"}";


            var result=  HttpRequestService.AskData(requestModel);

            Console.WriteLine(result.Result);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
