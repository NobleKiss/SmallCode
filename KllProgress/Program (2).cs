using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp2
{
    //public class Ts
    //{
    //    public string Name { get; set; }
    //    public int Index { get; set; } = 1;
    //}
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            //List<Ts> Listts = new List<Ts> {
            //    new Ts { Name = "美" },
            //    new Ts { Name = "小" },
            //    new Ts { Name = "丑",Index =2 },
            //    new Ts { Name = "大" },
            //    new Ts { Name = "八" },
            //    new Ts { Name = "丑",Index =3 },
            //    new Ts { Name = "大" },
            //    new Ts { Name = "丑" }
            //};
            //Console.WriteLine("未排序的顺序是：");
            //foreach (var item in Listts)
            //    Console.Write("{0}-{1}   ", item.Name, item.Index);
            //List<string> strList = new List<string> { "美", "丑", "大", "八", "小" };
            //List<Ts> PxList = new List<Ts>();
            //var dd = Listts.GroupBy(p => p.Index).ToList();
            //foreach (var ditem in dd)
            //    foreach (var item in strList)
            //        //PxList.AddRange(Listts.Where(p => p.Name.Equals(item)));
            //    PxList.AddRange((ditem.ToList() as List<Ts>).Where(p => p.Name.Equals(item)));
            //Console.WriteLine("\r\n排序后的顺序是：");
            //foreach (var item in PxList)
            //    Console.Write("{0}-{1}   ", item.Name, item.Index);

            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Multiselect = true;
            //dialog.DereferenceLinks = false;

            //var result = dialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    foreach (var path in dialog.FileNames)
            //    {

            //        if (!string.IsNullOrEmpty(path))
            //        {
            //            //var app = new App()
            //            //{
            //            //    FileName = Path.GetFileName(path).Replace(".lnk", ""),
            //            //    Path = path
            //            //};
            //            //if (apps.All(a => a.FileName != app.FileName))
            //            //{
            //            //    apps.Add(app);
            //            //    InitCheckBoxList();
            //            //}
            //        }
            //    }
            //}

            Process proc = new Process();
            proc.StartInfo.WorkingDirectory = string.Format(@"C:\Users\Administrator\Desktop\");
            // 文件名字
            proc.StartInfo.FileName = "Program.bat";
            proc.StartInfo.Arguments = string.Format("10");
            proc.Start();
            proc.WaitForExit();


            //try
            //{
            //    Process[] MyProcesses = Process.GetProcesses();
            //    string[] Minfo = new string[6];
            //    foreach (Process MyProcess in MyProcesses)
            //    {
            //        if (MyProcess.MainWindowTitle.Length > 0)
            //        {
            //            Minfo[0] = MyProcess.MainWindowTitle;
            //            Minfo[1] = MyProcess.Id.ToString();
            //            Minfo[2] = MyProcess.ProcessName;
            //            Minfo[3] = MyProcess.StartTime.ToString();
            //            Console.WriteLine("标题：" + Minfo[0]);
            //            Console.WriteLine("编号：" + Minfo[1]);
            //            Console.WriteLine("进程：" + Minfo[2]);
            //            Console.WriteLine("开始时间" + Minfo[3]);

            //        }
            //    }
            //}
            //catch { }
            //新建一个Stopwatch变量用来统计程序运行时间
            //Stopwatch watch = Stopwatch.StartNew();

            //获取本机运行的所有进程ID和进程名,并输出进程所使用的工作集和私有工作集
            //    foreach (Process ps in Process.GetProcesses())
            //{
            //    if (ps.ProcessName.Equals("devenv"))
            //    {
            //        PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", ps.ProcessName);
            //        PerformanceCounter pf2 = new PerformanceCounter("Process", "Working Set", ps.ProcessName);
            //        var zong = ps.WorkingSet64 / 1024;
            //        Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集(进程类)", zong);
            //        Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "工作集        ", pf2.NextValue() / 1024);
            //        //私有工作集
            //        Console.WriteLine("{0}:{1}  {2:N}KB", ps.ProcessName, "私有工作集    ", pf1.NextValue() / 1024);
            //        if (zong < 10000)
            //        {
            //            Console.WriteLine("因为低于最小值，已被杀死");
            //            ps.Kill();
            //        }
            //        Console.WriteLine("");
            //    }
            //}

            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.ReadLine();
            //获取当前进程对象
            //Process cur = Process.GetCurrentProcess();

            //PerformanceCounter curpcp = new PerformanceCounter("Process", "Working Set - Private", cur.ProcessName);
            //PerformanceCounter curpc = new PerformanceCounter("Process", "Working Set", cur.ProcessName);
            //PerformanceCounter curtime = new PerformanceCounter("Process", "% Processor Time", cur.ProcessName);

            ////上次记录CPU的时间
            //TimeSpan prevCpuTime = TimeSpan.Zero;
            ////Sleep的时间间隔
            //int interval = 1000;

            //PerformanceCounter totalcpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            //SystemInfo sys = new SystemInfo();
            //const int KB_DIV = 1024;
            //const int MB_DIV = 1024 * 1024;
            //const int GB_DIV = 1024 * 1024 * 1024;
            //while (true)
            //{
            //    //第一种方法计算CPU使用率
            //    //当前时间
            //    TimeSpan curCpuTime = cur.TotalProcessorTime;
            //    //计算
            //    double value = (curCpuTime - prevCpuTime).TotalMilliseconds / interval / Environment.ProcessorCount * 100;
            //    prevCpuTime = curCpuTime;

            //    Console.WriteLine("{0}:{1}  {2:N}KB CPU使用率：{3}", cur.ProcessName, "工作集(进程类)", cur.WorkingSet64 / 1024, value);//这个工作集只是在一开始初始化，后期不变
            //    Console.WriteLine("{0}:{1}  {2:N}KB CPU使用率：{3}", cur.ProcessName, "工作集        ", curpc.NextValue() / 1024, value);//这个工作集是动态更新的
            //    //第二种计算CPU使用率的方法
            //    Console.WriteLine("{0}:{1}  {2:N}KB CPU使用率：{3}%", cur.ProcessName, "私有工作集    ", curpcp.NextValue() / 1024, curtime.NextValue() / Environment.ProcessorCount);
            //    //Thread.Sleep(interval);

            //    //第一种方法获取系统CPU使用情况
            //    Console.Write("\r系统CPU使用率：{0}%", totalcpu.NextValue());
            //    //Thread.Sleep(interval);

            //    //第二章方法获取系统CPU和内存使用情况
            //    Console.Write("\r系统CPU使用率：{0}%，系统内存使用大小：{1}MB({2}GB)", sys.CpuLoad, (sys.PhysicalMemory - sys.MemoryAvailable) / MB_DIV, (sys.PhysicalMemory - sys.MemoryAvailable) / (double)GB_DIV);
            //    Thread.Sleep(interval);
            //}

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
