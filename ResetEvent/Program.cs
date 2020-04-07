using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResetEvent
{
    class Program
    {
        //true 若要将初始状态设置为终止状态; false 将初始状态设置为非终止
        //可以简单为true有信号，false没有信号
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Task.Run(Begin);
            Thread.Sleep(1000);
            Console.WriteLine($"【{DateTime.Now:mm:ss}】 灯光关闭");
            Thread.Sleep(1000);
            Console.WriteLine($"【{DateTime.Now:mm:ss}】 演员入场");
            Thread.Sleep(1000);
            Console.WriteLine($"【{DateTime.Now:mm:ss}】 道具准备完毕");
            autoResetEvent.Set();
            Console.ReadLine();
        }

        private static void Begin()
        {
            Console.WriteLine($"【{DateTime.Now:mm:ss}】 话剧准备中");
            //阻止当前线程，知道收到信号
            autoResetEvent.WaitOne();
            Console.WriteLine($"【{DateTime.Now:mm:ss}】 话剧开始了");
        }
    }
}
