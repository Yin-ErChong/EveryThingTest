using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAuto.Models
{
    public class 云码ResponseModel
    {
        public string msg { get; set; }
        public int code { get; set; }
        public YunMaData data { get; set; }
    }

    public class YunMaData
    {
        public int code { get; set; }
        public string data { get; set; }
        public float time { get; set; }
        public string unique_code { get; set; }
    }
}
