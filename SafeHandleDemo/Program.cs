using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafeHandleDemo
{
    class Program
    {
        //Testing harness that injects faults.
        //测试注入故障的保护
        private static bool _printToConsole = false;
        private static bool _workerStarted = false;

        private static void Usage()
        {
            Console.WriteLine("Usage:");
            //Assume that application is named HexViwer.
            //假设应用程序名为HexViwer
            Console.WriteLine("HexViwer <fileName> [-fault]");
            Console.WriteLine(" -falut Runs hex viwer repeatedly, injecting faults.");
        }

        private static void ViewInHex(object fileName)
        {
            _workerStarted = true;
            byte[] bytes;

            using (MyFileReader reader = new MyFileReader(fileName.ToString())) 
            {
                bytes = reader.ReadContents(20);
            }

            if (_printToConsole)
            {
                //Print up to 20 bytes.
                //最多打印20个字节
                int printNBytes = Math.Min(20, bytes.Length);
                Console.WriteLine($"First {printNBytes} bytes of {fileName} in hex");
                for (int i = 0; i < printNBytes; i++)
                {
                    Console.WriteLine($"{bytes[i]:x}");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 2 || args[0] == "-?" || args[0] == "/?") 
            {
                Usage();
                return;
            }

            string fileName = args[0];
            bool injectFaultMode = args.Length > 1;
            if (!injectFaultMode)
            {
                _printToConsole = true;
                ViewInHex(fileName);
            }
            else
            {
                Console.WriteLine("Injecting faults - watch handle count in perfmon (press Ctrl-C when done)");
                int numIterations = 0;
                while (true)
                {
                    _workerStarted = false;
                    Thread t = new Thread(ViewInHex);
                    t.Start(fileName);
                    Thread.Sleep(1);
                    while (!_workerStarted)
                    {
                        Thread.Sleep(0);
                    }
                    t.Abort();
                    numIterations++;
                    if (numIterations % 10 == 0) 
                    {
                        GC.Collect();
                    }
                    if (numIterations % 1000 == 0) 
                    {
                        Console.WriteLine(numIterations);
                    }
                }
            }
        }
    }
}
