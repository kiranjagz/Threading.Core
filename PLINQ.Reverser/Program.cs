using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQ.Reverser
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine("Is background thread: {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine("Id: {0}", Thread.CurrentThread.ManagedThreadId);
            });

            var longTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello World Again!");
                Console.WriteLine("Is background thread: {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine("Long task Id: {0}", Thread.CurrentThread.ManagedThreadId);
            },TaskCreationOptions.LongRunning);
     

            string sentence = "the quick brown fox jumped over the lazy dog ";

            var words =
                sentence.Split()
                    .AsParallel()
                    .AsOrdered()
                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                    .Select(word => new string(word.Reverse().ToArray()));

            Console.WriteLine(string.Join(" ", words));

            Console.Read();
        }
    }
}
