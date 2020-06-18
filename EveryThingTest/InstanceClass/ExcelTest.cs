using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtil.Helper;

namespace EveryThingTest.InstanceClass
{
    public class ExcelTest : TestBase, ITestBase
    {
        private static ExcelTest _Instance;
        public static ExcelTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ExcelTest();
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
            ExcelHelper excel = new ExcelHelper();
            int table=excel.DataTableToExcel(new DataTable(),"深演薪资包(ipinyou)",true);
            if (table==null)
            {

            }
           // int 姓名 = table.Columns.IndexOf(table.Columns["邮箱a*"]);
        }
        public override void End()
        {
            Console.WriteLine("It'End");
        }
    }
}
