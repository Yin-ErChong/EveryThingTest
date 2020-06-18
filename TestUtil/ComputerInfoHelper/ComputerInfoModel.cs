using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SpiderUtil.ComputerInfoHelper
{
    //定义以下各结构  
    //定义CPU的信息结构  
    [StructLayout(LayoutKind.Sequential)]
    public struct CPU_INFO
    {
        public uint dwOemId;
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dwAllocationGranularity;
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }

    //定义内存的信息结构  
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        public uint dwLength; //当前结构体大小
        public uint dwMemoryLoad; //当前内存使用率
        public ulong ullTotalPhys; //总计物理内存大小
        public ulong ullAvailPhys; //可用物理内存大小
        public ulong ullTotalPageFile; //总计交换文件大小
        public ulong ullAvailPageFile; //总计交换文件大小
        public ulong ullTotalVirtual; //总计虚拟内存大小
        public ulong ullAvailVirtual; //可用虚拟内存大小
        public ulong ullAvailExtendedVirtual; //保留 这个值始终为0
    }

    //定义系统时间的信息结构  
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME_INFO
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }
    public class DiskInfo
    { 
        public DiskInfo(string diskName, long diskSize, long diskFreeSpace)
        {
            this.diskName = diskName;
            this.diskSize = diskSize;
            this.diskFreeSpace = diskFreeSpace;
        }
        public string diskName { get; set; }
        public long diskSize { get; set; }
        public long diskFreeSpace { get; set; }

    }
    public class ProcessInfo
    {
        public ProcessInfo(int id, string processName, double processWorkTime, long processWorkSize, string processPath)
        {
            this.id = id;
            this.processName = processName;
            this.processName = processName;
            this.processWorkTime = processWorkTime;
            this.processPath = processPath;
        }
        public int id { get; set; }
        public string processName { get; set; }
        public double processWorkTime { get; set; }
        public long processWorkSize { get; set; }
        public string processPath { get; set; }

    }
}
