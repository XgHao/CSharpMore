using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //NewTask();

            SleepTask();

            //ParentTask();

            Console.ReadKey();
        }

        static void ParentTask()
        {
            Task mainTask = Task.Factory.StartNew(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("2000");
                }, TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("1000");
                });

                Thread.Sleep(3000);
                Console.WriteLine("3000");
            });

            mainTask.Wait();
            Console.WriteLine("All");
        }


        /// <summary>
        /// Task的创建
        /// </summary>
        static void NewTask()
        {
            Task task1 = new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("task1 complete");
            });
            task1.Start();

            Task task2 = Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Console.WriteLine("task2 complete");
            });
            Task.WaitAll(task1, task2);
            Task task3 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Console.WriteLine("task3 complete");
            });

            Task.WhenAll(task1, task2, task3).ContinueWith(task4 =>
            {
                Console.WriteLine("任务都完成了");
            });
        }


        static void SleepTask()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            CancellationToken token = tokenSource.Token;

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < Int32.MaxValue; i++)
                {
                    bool canelled = token.WaitHandle.WaitOne(1000);

                    Console.WriteLine($"Task1-int value {i}.Cancelled?{canelled}");

                    if (canelled)
                    {
                        throw new OperationCanceledException(token);
                    }
                }
            }, token);

            Console.WriteLine("Press enter to cancel token.");
            Console.ReadLine();

            tokenSource.Cancel();
            Console.WriteLine("Main method complete");
            Console.ReadKey();
        }
    }
}
