using EveryThingTest.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderUtil.ComputerInfoHelper;
using Lemony.SystemInfo;
using System.Threading;
using System.Diagnostics;
using TestUtil.ComputerInfoHelper;

namespace EveryThingTest.InstanceClass
{
    class ComputerInfoTest : TestBase, ITestBase
    {
        private static ComputerInfoTest _Instance;
        public static ComputerInfoTest Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ComputerInfoTest();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        private void GetInfo_Click()
        {  
            //调用GetWindowsDirectory和GetSystemDirectory函数分别取得Windows路径和系统路径  
            const int nChars = 128;  
            StringBuilder Buff = new StringBuilder(nChars);
            ComputerInfo.GetWindowsDirectory(Buff, nChars);  
            string Windows路径 =  "Windows路径："+Buff.ToString();
            ComputerInfo.GetSystemDirectory(Buff, nChars);  
            string 系统路径 =  "系统路径："+Buff.ToString();  
            //调用GetSystemInfo函数获取CPU的相关信息  
            CPU_INFO CpuInfo;  
            CpuInfo  =  new CPU_INFO();
            ComputerInfo.GetSystemInfo(ref CpuInfo);  
            string CPU数量  =  
                "本计算机中有"+CpuInfo.dwNumberOfProcessors.ToString()+"个CPU";
            string CPU的类型 =  "CPU的类型为"+CpuInfo.dwProcessorType.ToString();

            string CPU等级 =  
                "CPU等级为"+CpuInfo.dwProcessorLevel.ToString();
            string CPU的OEM =  "CPU的OEM  ID为"+CpuInfo.dwOemId.ToString();
            string CPU中的页面 =  "CPU中的页面大小为"+CpuInfo.dwPageSize.ToString();  
            //调用GlobalMemoryStatus函数获取内存的相关信息  
            MEMORY_INFO MemInfo;  
            MemInfo  =  new MEMORY_INFO();
            ComputerInfo.GlobalMemoryStatus(ref MemInfo);  
            string 内存正在使用 =  MemInfo.dwMemoryLoad.ToString()+ "%的内存正在使用";
            string 物理内存 =  "物理内存共有"+MemInfo.ullTotalPhys.ToString()+"字节";
            string 可使用的物理内存 =  "可使用的物理内存有"+MemInfo.ullAvailPhys.ToString()+"字节";

            string 交换文件总大小 =  
                "交换文件总大小为"+MemInfo.ullTotalPageFile.ToString()+"字节";
            string 尚可交换文件大小 =  
                "尚可交换文件大小为"+MemInfo.ullAvailPageFile.ToString()+"字节";
            string 总虚拟内存 =  
                "总虚拟内存有"+MemInfo.ullTotalVirtual.ToString()+"字节";
            string 未用虚拟内存 =  
                "未用虚拟内存有"+MemInfo.ullAvailVirtual.ToString()+"字节";  
            //调用GetSystemTime函数获取系统时间信息  
            SYSTEMTIME_INFO StInfo;  
            StInfo  =  new SYSTEMTIME_INFO();
            ComputerInfo.GetSystemTime(ref StInfo);
            string  时间=  
                StInfo.wYear.ToString()+"年"+StInfo.wMonth.ToString()+"月"+StInfo.wDay.ToString()+"日"; 
             
            string  时间2=  
                (StInfo.wHour+8).ToString()+"点"+StInfo.wMinute.ToString()+"分"+StInfo.wSecond.ToString()+"秒"; 
             
        }
         public override void Start()
        {
            //PerformanceCounter[] counters = new PerformanceCounter[System.Environment.ProcessorCount];
            //for (int i = 0; i < counters.Length; i++)
            //{
            //    counters[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
            //}

            //while (true)
            //{
            //    float sum = 0;
            //    for (int i = 0; i < counters.Length; i++)
            //    {
            //        float f = counters[i].NextValue();
            //        sum += f;
            //        Console.WriteLine("CPU-{0}: {1:f}%", i, f);
            //    }
            //    Console.WriteLine($"总数：{sum/6}");
            //    System.Threading.Thread.Sleep(1000);
            //}
            var pc = new PerformanceCounter();
            pc.CategoryName = ".NET CLR Exceptions";

            // 获取或设置与此 PerformanceCounter 实例关联的性能计数器的名称。

            pc.CounterName = "# of Exceps Thrown/sec";

            // 获取或设置此性能计数器的实例名称。

            pc.InstanceName =

             System.IO.Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.SetupInformation.ApplicationName);

            pc.ReadOnly = true;
            while (true)
            {
                SystemInfo systemInfo = new SystemInfo();
                DateTime time = DateTime.Now;
                Console.WriteLine($"{time.ToString("yyyy/MM/d")},核心数:{systemInfo.ProcessorCount}");
                Console.WriteLine($"{time.ToString("yyyy/MM/d")},CPU占用率:{systemInfo.CpuLoad}");
                Console.WriteLine($"{time.ToString("yyyy/MM/d")},可用内存:{systemInfo.MemoryAvailable / 1024 / 1024}MB");
                Console.WriteLine($"{time.ToString("yyyy/MM/d")},网络耗时:{NetAssess.Instance.GetWorkTime()}");
                Thread.Sleep(1500);
            }
            //GetInfo_Click();

        }
        public override void End()
        {
            Console.WriteLine("It'End");
            Console.ReadLine();
        }
    }
}
