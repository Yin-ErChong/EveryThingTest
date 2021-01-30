using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class 正则Test : TestBase, ITestBase
    {
        private static 正则Test _Instance;
        public static 正则Test Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new 正则Test();
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
            string str = "{\"totalRow\":1,\"pageNumber\":1,\"data\":\"<tr>\n    <td class=\"overflow_show\">        <!--<input type=\"checkbox\" name=\"auctionId\" id=\"auction_name_549694\" value=\"549694\" class=\"select_item\">-->\n        <a href=\" / bidding / 549694\" target=\"_blank\">vbti.com</a>\n    </td>\n    <td>-</td>\n    <td>ALI_PRE</td>\n    <td>4</td>\n    <td>PR1     </td>\n    <td><span class=\"text_orange\">￥361</span></td>\n    <td><span class=\"\">1时44分</span></td>\n    <td><a href=\" / bidding / 549694\" id=\"bid_549694\" target=\"_blank\" class=\"btn btn_primary\">出价</a></td>\n</tr>\n\",\"totalPage\":1,\"pageSize\":50}";
            string pattern = "value=\"(\\d*)\"";

            foreach (Match match in Regex.Matches(str, pattern))
                Console.WriteLine(match.Groups[1].Value);
            Console.WriteLine("It'Start");
        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
