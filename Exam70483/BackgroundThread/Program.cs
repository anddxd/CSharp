using System;
using System.Threading;

namespace BackgroundThread
{
    class Program
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            // Quando a thread é background o CLR é executado imediatamente, fechando a aplicação. 
            // Quando a thread é foreground toda a thread é executada antes do CLR ser executado.
            t.IsBackground = false;
            t.Start();
        }
    }
}
