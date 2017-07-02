using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Queuing a work item to a thread pool can be useful, but it has its shortcomings. There is no built-in way to know when the operation has finished and what the return value is.
This is why the .NET Framework introduces the concept of a Task, which is an object that represents some work that should be done.The Task can tell you if the work is completed
and if the operation returns a result, the Task gives you the result.A task scheduler is responsible for starting the Task and managing it.By default, the Task scheduler uses threads 
from the thread pool to execute the Task.Tasks can be used to make your application more responsive.If the thread that manages the user interface offloads work to another thread 
from the thread pool, it can keep processing user events and ensure that the application can still be used.But it doesn’t help with scalability. If a thread receives a web request 
and it would start a new Task, it would just consume another thread from the thread pool while the original thread waits for results.Executing a Task on another thread makes sense 
only if you want to keep the user interface thread free for other work or if you want to parallelize your work on to multiple processors");
            Console.WriteLine("Please select demo #");
            Console.WriteLine("1.Simple Task");
            Console.WriteLine("2.");
            Console.WriteLine("3.");
            Console.WriteLine("4.");
            var sel = Convert.ToInt32(Console.ReadLine());

            switch (sel)
            {
                case 1:
                    SimpleTask();
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }

        private static void SimpleTask()
        {
            Task.Run(() => {
                Console.WriteLine("Hello from task!");
                Thread.Sleep(1000);
            }).Wait();
        }
    }
}