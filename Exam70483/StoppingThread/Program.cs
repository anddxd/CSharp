using System;
using System.Threading;

namespace StoppingThread
{
    class Program
    {
        static void Main(string[] args)
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Executando...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Precione qualquer tecla para finalizar...");
            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}
