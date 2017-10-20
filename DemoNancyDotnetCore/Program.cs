using Nancy.Hosting.Self;
using System;
using System.Diagnostics;
using System.Threading;

namespace DemoNancyDotnetCore
{
    class Program
    {
        public static bool _runing = false;

        private static void Main(string[] args)
        {
            var port = 3721;
            var uri = new Uri("http://localhost:" + port);

            using (var host = new NancyHost(uri))
            {
                Console.Write("等待通用积分计算API启动 ...");
                host.Start();
                Process p = Process.GetCurrentProcess();
                Console.Write("启动成功\n");
                Console.WriteLine("Port:\t" + uri.Port);
                Console.WriteLine("PID:\t" + p.Id);

                _runing = true;
                for (; _runing;)
                {
                    Thread.Sleep(5000);
                }
            }
            _runing = false;
        }
    }
}