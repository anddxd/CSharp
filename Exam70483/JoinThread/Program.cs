using System;
using System.Threading;

namespace JoinThread
{
    class Program
    {
        static Thread t1, t2;
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread secundária: {0}. Estado da thread primária: {1}. Estado da thread secundária: {2}.", i, t2.ThreadState, t1.ThreadState);
                Thread.Sleep(0); // indica que a thread foi finalizada, trocando imediatamente para outra thread
            }
        }
        static void Main(string[] args)
        {
            t1 = new Thread(new ThreadStart(ThreadMethod));
            t1.Start();
            for (int i = 0; i < 5; i++)
            {
                t2 = Thread.CurrentThread;
                Console.WriteLine("Thread principal: {0}. Estado da thread primária: {1}. Estado da thread secundária: {2}.", i, Thread.CurrentThread.ThreadState, t1.ThreadState);
                Thread.Sleep(100);
            }
            t1.Join(); // método de sincronização que bloqueia a thread de chamada até que seja concluída.
            Console.ReadKey();
        }
    }
}
