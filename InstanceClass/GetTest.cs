using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class GetTest : TestBase
    {
        private static GetTest _Instance;
        public static GetTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GetTest();
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
            //Url = "https://localhost:44317/api/Test/AddUser?name=计算机网络";

            #region Get请求
            ////创建请求
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44317/api/Test/AddUser?name=计算机网络");

            ////GET请求
            //request.Method = "GET";
            //request.ReadWriteTimeout = 5000;
            //request.ContentType = "application/json;charset=UTF-8";
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();//执行get请求
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            ////返回内容JSON
            //string retString = myStreamReader.ReadToEnd();
            //Console.WriteLine(retString);
            #endregion

            #region Post请求
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://localhost:44317/api/Test/AddBook?name=计算机网络");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            //int i = 0;
            //foreach (var item in dic)
            //{
            //    if (i > 0)
            //        builder.Append("&");
            //    builder.AppendFormat("{0}={1}", item.Key, item.Value);
            //    i++;
            //}
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            



            #endregion



            Console.WriteLine(result);

        }
        public override void End()
        {
            Console.WriteLine("It'end");
            Console.ReadKey();
        }
    }
}
