using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParentChild
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("------开启父线程------");
                while (!tokenSource.IsCancellationRequested) 
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("我是父线程我是父线程");
                    Thread.Sleep(1000);
                    if (i < 3)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            switch (i++)
                            {
                                case 0:
                                    Console.WriteLine($"+++线程1开启+++");
                                    while (true)
                                    {
                                        Thread.Sleep(2500);
                                        Console.WriteLine($"我是子线程1");
                                    }
                                case 1:
                                    Console.WriteLine($"+++线程2开启+++");
                                    while (true)
                                    {
                                        Thread.Sleep(2500);
                                        Console.WriteLine($"我是子线程2");
                                    }
                                case 2:
                                    Console.WriteLine($"+++线程3开启+++");
                                    while (true)
                                    {
                                        Thread.Sleep(2500);
                                        Console.WriteLine($"我是子线程3");
                                    }
                                default:
                                    break;
                            }

                        }, TaskCreationOptions.AttachedToParent);
                    }
                }
            }, tokenSource.Token);

            Console.ReadLine();
        }
    }
}
