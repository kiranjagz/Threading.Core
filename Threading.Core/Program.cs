using System;
using System.Threading;
using Threading.Core.BackgroundThreads;

namespace Threading.Core
{
    class Program
    {
        private const int count = 1000;

        public static void DoWork()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write("B");
            }
        }

        public static void Main(string[] args)
        {

            // strange behaviour, because threads are time sliced by cpu. 
            // Run interval is called time slice, max amount of time a thread can be run, until suspended and allow another thread to run
            // start new thread
            // Thread t1 = new Thread (new ThreadStart(DoWork));
            // t1.Start ();
 
            Thread t2 = new Thread(DoWork);
            t2.Name = "worker";
            t2.Start();

            //Thread t3 = new Thread(() => { DoWork(); });
            //t3.Start();
            
            for (int i = 0; i < count; i++)
            {
                Console.Write("A");
            }

            Back.DoSomething();

            Console.Read();
        }
    }
}
