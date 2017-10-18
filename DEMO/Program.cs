using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace PointRuler
{
    internal class Program
    {
        public static bool _runing = false;

        private static void Main(string[] args)
        {
            var port = 3721;
            var uri = new Uri("http://localhost:" + port);

            using (var host = new NancyHost(uri))
            {
                Console.Write("Wait Fishing-Fork running ...");
                host.Start();
                Process p = Process.GetCurrentProcess();
                //File.WriteAllText("./realtime.pid", p.Id.ToString());
                Console.Write("OK\n");
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
