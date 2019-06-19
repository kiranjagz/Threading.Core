using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading.Core.BackgroundThreads
{
    internal static class Back
    {
        public static void DoSomething()
        {
            //Closes only when foreground thread is complete
            Thread t = new Thread(() => {
                Console.WriteLine("Thread is starting, press ENTER to continue..");
                Console.ReadLine();
            });
            t.IsBackground = false;
            t.Name = "background";
            t.Start();
        }
    }
}
