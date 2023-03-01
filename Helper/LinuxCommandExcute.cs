using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace YinSoundPlayer
{
    public class LinuxCommandExcute
    {
        public static bool Execute(string fileName,string arguments)
        {
            try
            {
                var psi = new ProcessStartInfo(fileName, arguments) { RedirectStandardOutput = true, CreateNoWindow=false };
                //启动
                var proc = Process.Start(psi);
                if (proc == null)
                {
                    Console.WriteLine("Can not exec.");
                }
                else
                {
                    Console.WriteLine("-------------Start read standard output--------------");
                    //开始读取
                    using (var sr = proc.StandardOutput)
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }

                        if (!proc.HasExited)
                        {
                            proc.Kill();
                        }
                    }
                    Console.WriteLine("---------------Read end------------------");
                }
                return true;
            }
            catch (Exception ee)
            {

                Console.WriteLine($"执行命令异常:{ee}");
                return false;
            }
           
        }

        public static string Execute2(string command) 
        {
            string result = "";
            try
            {
                Console.WriteLine($"执行命令:{command}");
                
                using (System.Diagnostics.Process proc = new System.Diagnostics.Process())
                {
                    proc.StartInfo.FileName = "/bin/bash";
                    proc.StartInfo.Arguments = "-c \" " + command + " \"";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.Start();

                    result += proc.StandardOutput.ReadToEnd();
                    result += proc.StandardError.ReadToEnd();

                    proc.WaitForExit();
                }
                return result;
            }
            catch (Exception ee)
            {
                Console.WriteLine($"执行命令异常:{ee}");
                return result;
            }
           
        }
    }
}

