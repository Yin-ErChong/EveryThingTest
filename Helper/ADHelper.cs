using EpsonNetSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EveryThingTest.Helper
{
    /// <summary>
    /// 计算机AD域帮助类
    /// </summary>
    public class ADHelper
    {
        [DllImport("kernel32.dll", EntryPoint = "SetComputerNameEx")]
        public static extern int apiSetComputerNameEx(int type, string lpComputerName);

        public static void ChangeConputerName(string computerName) 
        {
            int rtn = apiSetComputerNameEx(5, computerName);
            System.Console.WriteLine("Computer name set result=" + rtn);
        }
        public static int SetDomainMembership(string DomainName, string UserName, string Password, out string err) 
        {
            err = "System Error!";
            // Invoke WMI to join the domain
            using (ManagementObject wmiObject = new ManagementObject(new ManagementPath("Win32_ComputerSystem.Name='" + System.Environment.MachineName + "'")))
            {
                try
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams = wmiObject.GetMethodParameters("JoinDomainOrWorkgroup");


                    inParams["Name"] = DomainName;
                    inParams["Password"] = Password;
                    inParams["UserName"] = UserName + "@" + DomainName;
                    inParams["AccountOU"] = null;
                    inParams["FJoinOptions"] = 3; //
                    // Execute the method and obtain the return values.
                    ManagementBaseObject outParams = wmiObject.InvokeMethod("JoinDomainOrWorkgroup", inParams, null);

                    switch (outParams["ReturnValue"].ToString())
                    {
                        case "5":
                            err = "Access is denied";
                            break;
                        case "87":
                            err = "The parameter is incorrect";
                            break;
                        case "110":
                            err = "The system cannot open the specified object";
                            break;
                        case "1323":
                            err = "Unable to update the password";
                            break;
                        case "1326":
                            err = "Logon failure: unknown username or bad password";
                            break;
                        case "1355":
                            err = "The specified domain either does not exist or could not be contacted";
                            break;
                        case "2224":
                            err = "The account already exists";
                            break;
                        case "2691":
                            err = "The machine is already joined to the domain";
                            break;
                        case "2692":
                            err = "The machine is not currently joined to a domain";
                            break;
                    }
                    return Convert.ToInt32(outParams["ReturnValue"]);
                }
                catch (ManagementException e)
                {
                    // It didn't work                    
                    return -1;
                }
            }
        }
    }
}
