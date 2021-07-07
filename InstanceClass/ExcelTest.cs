using EveryThingTest.BaseClass;
using EveryThingTest.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.InstanceClass
{
    public class ExcelTest : TestBase,ITestBase
    {
        private static ExcelTest _Instance;
        public static ExcelTest Instance
        {
            get
            {
                if (_Instance==null)
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
            DataTable dataTable = null;
            string filePath = @"C:\Users\Administrator\Desktop\1.xlsx";
            dataTable = ExcelToTable.ExcelToDataTable(filePath, true);

            //DataTable dataTable = new DataTable();
            string s_FileName = "20210703";
            Console.WriteLine(TableToExcel.DataTableToExcel(dataTable, s_FileName));

        }
        public override void End()
        {
            Console.WriteLine("It'end");
            Console.ReadKey();
        }
    }
}
