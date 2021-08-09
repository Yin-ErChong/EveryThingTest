using EpsonNetSDK;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveryThingTest.Helper.PrintHelper
{
    public class EsponPrinter
    {
        public enum PrinterStatus
        {
            准备就绪=0,
            缺纸=1,
            打印中=2,
            其他错误=3,
            油墨干燥=4
        }
        static IntPtr g_hPrinter = IntPtr.Zero;
        public PrinterStatus GetEsponPrinterStatus()
        {
           
            int iRet = 0;               //Return code
            int iPathType = 0;              //Path type of PrnPath
            string pPrnPath = null;				//Pointer to Printer path name
            iRet = API.ENSInitialize();
            int iBuffLen = Marshal.SizeOf(typeof(DEVICEID01));
            IntPtr IDBuff = Marshal.AllocHGlobal(iBuffLen);
            iPathType = PATHTYPE.PRINTER;
            PrintDocument print = new PrintDocument();
            string sDefault = print.PrinterSettings.PrinterName;//默认打印机名
            pPrnPath = sDefault; //args[1]; 						//Setting PrnPath

            try
            {
                if (iRet == 0)                          //Pre-processing success
                {
                    iRet = API.ENSGetDeviceID(iPathType,
                                              pPrnPath,
                                              IDBuff,
                                              ref iBuffLen,
                                              1);
                }

                //=========================================================================
                // (3)Open printer handle.
                //=========================================================================
                if (iRet == 0)                          //Pre-processing success
                {
                    iRet = API.ENSOpenCommunication(iPathType,
                                                    pPrnPath,
                                                    IDBuff,
                                                    out g_hPrinter);
                }
                if (iRet == 0)                          //Pre-processing success.
                {
                    return GetStatus();
                }
                return PrinterStatus.其他错误;
            }
            finally
            {
                Marshal.FreeHGlobal(IDBuff);
            }           
        }
        private static PrinterStatus GetStatus()
        {
            int iRet = 0;                       //Return code

            int iBuffLen = 0;					//Clear the buffer length to 0

            IntPtr pStatusBuffer = IntPtr.Zero;

            STATUSHEADER pStatusHeader;         //Pointer to STATUSHEADER
            STATUS_IJP pCustomIJStatus;		//Pointer to STATUS_IJP

            iBuffLen = 0;						//Clear the buffer length to 0
            iRet = API.ENSGetInformation(g_hPrinter,
                                         "STATUS_IJP",
                                         IntPtr.Zero,
                                         IntPtr.Zero,
                                         ref iBuffLen);
            //Acquire buffer size necessary for 
            //acquisition.
            //If NULL is designated as buffer size,
            //returns the buffer size necessary for
            //acquisition.

            Console.Write("ENSGetInformation [{0:D}]\n", iRet);

            if (iRet == ERR.BUFFERSIZE) 		//Buffer size error.
            {
                pStatusBuffer = Marshal.AllocHGlobal(iBuffLen);
                //Reserve area for status information.
                iRet = API.ENSGetInformation(g_hPrinter,
                                             "STATUS_IJP",
                                             IntPtr.Zero,
                                             pStatusBuffer,
                                             ref iBuffLen);

                if (iRet != 0)
                {
                    //If error occured from EpsonNet SDK, Terminate thread.
                    Console.Write("Error ENSGetInformation [{0:D}]\n", iRet);
                    Marshal.FreeHGlobal(pStatusBuffer);
                    return PrinterStatus.其他错误;
                }
                else
                {
                    //=========================================================================
                    // (4)Check status code and indicate printable or not.
                    //=========================================================================
                    pStatusHeader = (STATUSHEADER)Marshal.PtrToStructure(pStatusBuffer, typeof(STATUSHEADER));
                    if (0x300 == pStatusHeader.Version.MajorVersion)
                    {
                        pCustomIJStatus = (STATUS_IJP)Marshal.PtrToStructure(pStatusBuffer, typeof(STATUS_IJP));
                        return EsponStatusTranser(pCustomIJStatus);


                    }
                    else
                    {
                        Marshal.FreeHGlobal(pStatusBuffer);
                        pStatusBuffer = IntPtr.Zero;
                    }
                }
                Marshal.FreeHGlobal(pStatusBuffer);
            }
            return PrinterStatus.其他错误;
        }
        public static PrinterStatus EsponStatusTranser(STATUS_IJP sTATUS_IJP)
        {

            switch (sTATUS_IJP.StatusCode)
            {
                case 4:return PrinterStatus.准备就绪;
                case 6: return PrinterStatus.油墨干燥;
                default:
                    break;
            }
            if (sTATUS_IJP.StatusCode==0)
            {
                switch (sTATUS_IJP.ErrorCode)
                {
                    case 6:return PrinterStatus.缺纸;

                    default:
                        break;
                }
            }
            return PrinterStatus.准备就绪;
        }
    }
}
