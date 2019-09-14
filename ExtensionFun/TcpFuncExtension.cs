using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.ExtensionFun
{
    public static class TcpFuncExtension
    {
        public static string ReadStringFromStream(this NetworkStream streamToClient)
        {
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
            return str;
        }
        public static void WriteStringToStream(this NetworkStream streamToClient, string msg)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(msg);
            lock (streamToClient)
            {
                streamToClient.Write(buffer, 0, buffer.Length);//buffer为发送的字符数组                   
            }
        }
    }
}
