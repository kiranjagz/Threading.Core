using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task.Core
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var task = Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return "Jefff";
            });

            // use result
            Console.Write("Your name is ");
            Console.Write(task.Result);
          

            var error = System.Threading.Tasks.Task.Factory.StartNew(() => {

                Thread.Sleep(2000);
                Console.WriteLine("Hello World");

                #region thread information
                Console.WriteLine("Is background thread: {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
                #endregion

                #region throw exception
                throw new InvalidOperationException("Something went wrong");
                #endregion

            });

            // wait for task to complete
            error.Wait();
        }
    }
}
