//=============================================================================
//	EpsonNetSDK.cs
//=============================================================================

//=============================================================================
//	using
//=============================================================================
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace EpsonNetSDK
{
	//=============================================================================
	//	Constant definitions
	//=============================================================================
	//-------------------------------------
	//	Error code
	//-------------------------------------
	class ERR
	{
		public const int BASE = 0;
		public const int PARAMETER = (BASE - 1);
		//Values of necessary arguments have 
		//not been set.
		public const int INITIALIZE = (BASE - 2);
		//Failure in initialization of 
		//bi-directional communication module. 
		//Or API has not been initialized.
		public const int NOTSUPPORT = (BASE - 3);
		//Error before the start of 
		//communication (i.e. a port 
		//specification error etc.). 
		//Or other error occurred in 
		//bi-directional communication module.
		public const int PRINTER = (BASE - 4);
		//Printer has not been registered
		public const int NOTFOUND = (BASE - 5);
		//Communication cannot be opened. 
		//Communication trouble. Or there is 
		//no device information which can be 
		//acquired.
		public const int BUFFERSIZE = (BASE - 6);
		//Specified buffer size value is too 
		//small.
		public const int TEMPORARY = (BASE - 7);
		//Temporary storage memory used in API 
		//cannot be secured.
		public const int COMMUNICATION = (BASE - 8);
		//Communication error occurred inside 
		//system of bi-directional 
		//communication module.
		public const int INVALIDDATA = (BASE - 9);
		//Data acquired by API contains invalid
		//code, so data is not reliable.
		public const int CHANNEL = (BASE - 10);
		//No usable communication channel for 
		//packet transmission/reception.
		public const int HANDLE = (BASE - 11);
		//Handle of specified bi-directional 
		//communication module is invalid.
		public const int BUSY = (BASE - 12);
		//Port could not be opened while 
		//printer is printing (communicating).
		public const int LOADDLL = (BASE - 13);
		//Failure in loading bi-directional 
		//communication module.
		public const int DEVICEID = (BASE - 14);
		//Specified DeviceID information is 
		//invalid.
		public const int PRNHANDLE = (BASE - 15);
		//Specified printer handle is invalid.
		public const int PORT = (BASE - 16);
		//Unsupported printer path name was 
		//specified.
		public const int TIMEOUT = (BASE - 17);
		//Receive processing stopped due to a 
		//time out.
		public const int JOB1 = (BASE - 18);
		//SNMP OID mismatch.
		public const int JOB2 = (BASE - 19);
		//SNMP Bad value.
		public const int JOB3 = (BASE - 20);
		//SNMP No such name.
		public const int SERVICE = (BASE - 25);
		//Core service error.

		public const int OTHER = -1000; //Other error
	}

	class TYPE
	{
		public const int REMOTE = 1;        //Printer compatible with remote 
											//commands (INK/SIDM printer)
		public const int UNKNOWN = 100;     //Type cannot be determined.
	}

	class PATHTYPE                                  //Printer path type
	{
		public const int PORT = 0;      //Port
		public const int PRINTER = 1;       //Printer registration name
	}


	//-------------------------------------
	// Definitions relating to information 
	// acquire/set APIs using SNMP
	//-------------------------------------
	///////////////////////////////////////
	//	SNMP command
	///////////////////////////////////////
	class SNMP
	{
		public const int GET = 0x01;        //GET
		public const int GETNEXT = 0x02;        //GET_NEXT
		public const int SET = 0x03;        //SET
	}

	///////////////////////////////////////
	//	SNMP data type
	///////////////////////////////////////
	class DATATYPE
	{
		public const int INTEGER = 0x02;        //Integer
		public const int OCTETSTR = 0x04;       //Character string
		public const int UNKNOWN = 0xFE;        //Unknown
		public const int BUFFSIZE = 0xFF;       //Insufficient buffer size
	}

	//=============================================================================
	//	Structure definition
	//=============================================================================
#pragma warning disable 649
	//=====================================
	//	DeviceID information
	//=====================================
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct DEVICEID01
	{
		public int Size;                        //Size
		public int Version;                 //Version
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public char[] MFG;                      //Manufacturer name
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public char[] CMD;                      //Support command type
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public char[] MDL;                      //Product name
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public char[] CLS;                      //Device type
		public int PrnTypes;                    //Printer type
	}

	//=====================================
	//	STATUS information
	//=====================================
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct STATUSVERSION                            //Status information version
	{
		public ushort MajorVersion;             //Major version
		public ushort MinerVersion;             //miner version
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct STATUSHEADER                             // Status information common header
	{
		public uint Size;                       // Size of Structure
		public STATUSVERSION Version;               // Version of Structure
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CARTRIDGEANDINKINFO
	{                                               //Cartridge and ink information
		public byte CartridgeType;              //Cartridge name code
		public uint ColorType;                  //Cartridge color code
		public byte InkRest;                    //Ink rest information
		public byte InkDimension;               //Ink dimension information
	}


	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PAPERPRINTCOUNT
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public char[] PaperSizeName;
		public uint PrintedNumber;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PAPERTRAYREMAIN
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public char[] TrayName;
		public uint PaperSizeType;
		public uint PaperRemain;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct STATUS_IJP
	{
		public uint Size;                                           // this struct size
		public STATUSVERSION Version;                               // struct version

		public byte StatusReplyType;                                // status reply type
		public byte StatusCode;                                     // status code
		public byte ErrorCode;                                      // error code
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] WarningCode;                                  // warning code

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] InkRemainInfo;                                // ink remain information

		public uint MonochromePrintedNumber;                        // monochrome printed number
		public uint ColorPrintedNumber;                             // color printed number

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public CARTRIDGEANDINKINFO[] CartridgeInk;                  // cartridge and ink information

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public byte[] SerialNo;                                     // serial number       

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public PAPERPRINTCOUNT[] PaperPrintCount;                   // printed count information of each paper size
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public PAPERTRAYREMAIN[] PaperTrayRemain;                   // paper tray information

	}

	//-------------------------------------
	//	OID information structure
	//-------------------------------------
	class OIDSTR
	{
		public const int SIZE = 128;                //Buffer size
	}
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	struct OIDINFO
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = OIDSTR.SIZE)]
		public char[] OID;                      //Area for storing OID as character 
												//string
		public int DataType;                    //Data type
		public IntPtr Buffer;                       //Buffer for value acquire/set
		public int BuffSize;                    //Size of Buffer
	}
#pragma warning restore 649

	//=============================================================================
	//	API definition
	//=============================================================================
	class API
	{
		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSInitialize();

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSRelease();

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSGetDeviceID(
										int PathType,
										[MarshalAs(UnmanagedType.LPStr)] string PrnPath,
										[Out] IntPtr IdBuff,
										ref int BuffLen,
										int StructVersion);

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSOpenCommunication(
										int PathType,
										[MarshalAs(UnmanagedType.LPStr)] string PrnPath,
										[In] IntPtr IdBuff,
										out IntPtr PrnHandle);

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSCloseCommunication(IntPtr PrnHandle);

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSGetInformation(
										IntPtr PrnHandle,
										[MarshalAs(UnmanagedType.LPStr)] string Command,
										[In] IntPtr GetParam,
										[Out] IntPtr GetBuff,
										ref int BuffLen);

		[DllImport("EpsonNetSDK.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public extern static int ENSGetSetSNMPRequest(
										IntPtr PrnHandle,
										int CommandType,
										IntPtr OidInfo,
										int OidNum);
	}
}

