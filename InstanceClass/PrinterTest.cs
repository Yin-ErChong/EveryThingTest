using EveryThingTest.BaseClass;
using EveryThingTest.Helper;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading;

namespace EveryThingTest.InstanceClass
{
    
    public class PrinterTest : TestBase ,ITestBase
    {
        private static PrinterTest _Instance;
        public static PrinterTest Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new PrinterTest();                   
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
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名

            foreach (string sPrint in PrinterSettings.InstalledPrinters)//获取所有打印机名称
            {
                Console.WriteLine(sPrint);
            }

            
            //printer2.get
            while (true)
            {
                //Printer2.GetPrintStatus();
                bool resulk= System.Printing.LocalPrintServer.GetDefaultPrintQueue().IsOutOfPaper;
                 Console.WriteLine(resulk);
                Thread.Sleep(500);
            }

        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.Read();
        }
    }
}
