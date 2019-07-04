using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SexConvertert : ITypeConverter<int, string>
    {
        /// <summary>
        /// 性别的数字类型转换成文本类型
        /// </summary>
        /// <param name="source">数字类型</param>
        /// <param name="destination">文本类型</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string Convert(int source, string destination, ResolutionContext context)
        {
            switch (source)
            {
                case 0:
                    destination = "女";
                    break;
                case 1:
                    destination = "男";
                    break;
                default:
                    destination = "未知";
                    break;
            }
            return destination;
        }
    }
    public class SourceProfile : Profile
    {        
        public SourceProfile()
        {
            CreateMap<Source, DTOSource>()//会自动忽略大小写
                .ForMember(c => c.NianLing, q => q.MapFrom(z => z.Age))//不同属性名的映射
                .ForMember(c => c.Content, q => q.NullSubstitute("值为空"))//添加为null时的空值
                .ForMember("Name", q => q.Ignore());//忽略源数据的值
            CreateMap<int, string>()
                //.ConvertUsing(new SexConvertert());//两种写法，效果一样
                .ConvertUsing<SexConvertert>();
        }
    }
    public class Program
    {

        static Mutex GmOne1;
        static Mutex GmTwo2;
        const int ITERS = 100;
        static AutoResetEvent Event1 = new AutoResetEvent(false);
        static AutoResetEvent Event2 = new AutoResetEvent(false);
        static AutoResetEvent Event3 = new AutoResetEvent(false);
        static AutoResetEvent Event4 = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            //**********************************************************//
            //Mapper.Initialize(x =>
            //{
            //    x.CreateMap<Source, DTOSource>()
            //    .ForMember(c => c.NianLing, q => { q.MapFrom(z => z.Age); });
            //});
            Mapper.Initialize(x => { x.AddProfile<SourceProfile>(); });
            Source s = new Source { Id = 1, Age = 20, Name = "嘻嘻" };
            List<Source> slist = new List<Source> { s, new Source { Sex = 0 }, new Source { Sex = 1 }, new Source { Sex = 3 }, };
            DTOSource dto = Mapper.Map<DTOSource>(s);
            var dtolist = Mapper.Map<List<DTOSource>>(slist);

            //***********************************************************//
            Console.WriteLine("开始创建GM1有名字，GM2没有名字");
            GmOne1 = new Mutex(true, "MyMutex");
            GmTwo2 = new Mutex(true);
            Console.WriteLine("创建完毕");
            AutoResetEvent[] Evs = new AutoResetEvent[4];
            Evs[0] = Event1;
            Evs[1] = Event2;
            Evs[2] = Event3;
            Evs[3] = Event4;
            Program p = new Program();
            Thread t1 = new Thread(new ThreadStart(p.T1Start));
            Thread t2 = new Thread(new ThreadStart(p.T2Start));
            Thread t3 = new Thread(new ThreadStart(p.T3Start));
            Thread t4 = new Thread(new ThreadStart(p.T4Start));
            t1.Start();// 使用Mutex.WaitAll()方法等待一个Mutex数组中的对象全部被释放  
            t2.Start();// 使用Mutex.WaitOne()方法等待gM1的释放  
            t3.Start();// 使用Mutex.WaitAny()方法等待一个Mutex数组中任意一个对象被释放  
            t4.Start();// 使用Mutex.WaitOne()方法等待gM2的释放  
            Thread.Sleep(2000);
            Console.WriteLine(" 开始释放GmOne1  线程t2,t3结束条件满足");
            GmOne1.ReleaseMutex(); //线程t2,t3结束条件满足              

            Thread.Sleep(1000);
            Console.WriteLine(" 开始释放GmTwo2  线程t1,t4结束条件满足  ");
            GmTwo2.ReleaseMutex(); //线程t1,t4结束条件满足  

            //等待所有四个线程结束  
            WaitHandle.WaitAll(Evs);
            Console.WriteLine("结束");
            Console.ReadLine();
        }
        public void T1Start()
        {
            Console.WriteLine("T1开始，使用Mutex.WaitAll()方法等待一个Mutex数组中的对象全部被释放");
            Mutex[] Gms = new Mutex[2] { GmOne1,GmTwo2 };
            WaitHandle.WaitAll(Gms);
            Thread.Sleep(2000);
            Console.WriteLine("T1结束，所有都被安全释放！");
            Event1.Set();
        }
        public void T2Start()
        {
            Console.WriteLine("T2开始，使用Mutex.WaitOne()方法等待gM1的释放  ");
            GmOne1.WaitOne();            
            Console.WriteLine("T2结束，所有都被安全释放！");
            Event2.Set();
        }
        public void T3Start()
        {
            Console.WriteLine("T3开始，使用Mutex.WaitAny()方法等待一个Mutex数组中任意一个对象被释放  ");
            Mutex[] Gms = new Mutex[2] { GmOne1, GmTwo2 };
            WaitHandle.WaitAny(Gms);
            Console.WriteLine("T3结束，所有都被安全释放！");
            Event3.Set();
        }
        public void T4Start()
        {
            Console.WriteLine("T4开始，使用Mutex.WaitOne()方法等待gM2的释放 ");
            GmTwo2.WaitOne();
            Console.WriteLine("T4结束，所有都被安全释放！");
            Event4.Set();
        }
    }
    public class Source
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
    }

    public class DTOSource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int NianLing { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
    }
}

