using System;
using System.Diagnostics;

namespace KllProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取本机运行的所有进程ID和进程名,并输出进程所使用的工作集和私有工作集
            foreach (Process ps in Process.GetProcesses())
            {
                if (ps.ProcessName.Equals("devenv"))
                {
                    PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", ps.ProcessName);
                    PerformanceCounter pf2 = new PerformanceCounter("Process", "Working Set", ps.ProcessName);
                    var zong = ps.WorkingSet64 / 1024;
                    Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集(进程类)", zong);
                    Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集        ", pf2.NextValue() / 1024);
                    //私有工作集
                    Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "私有工作集    ", pf1.NextValue() / 1024);
                    if (zong < 10000)
                    {
                        Console.WriteLine("因为低于最小值，已被杀死");
                        ps.Kill();
                    }
                    Console.WriteLine("");
                }
            }
        }
    }
}
