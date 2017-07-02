using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select demo #");
            Console.WriteLine("1.A)Background Thread");
            Console.WriteLine("2.B)Foreground Thread");
            Console.WriteLine("3.Stopping a thread");
            Console.WriteLine("4.ThreadStatic field");
            var sel = Convert.ToInt32(Console.ReadLine());

            switch (sel)
            {
                case 1:
                    RunBackgroundThread();
                    break;
                case 2:
                    RunForegroundThread();
                    break;
                case 3:
                    StoppingAThread();
                    break;
                case 4:
                    ThreadSpecificFilead();
                    break;
                default:
                    break;
            }
        }

        static void SimpleLoop(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Worker running {0}", i);
                Thread.Sleep(2000);
            }
        }

        static void RunBackgroundThread()
        {
            var _backgroundThread = new Thread(new ParameterizedThreadStart(SimpleLoop));
            _backgroundThread.IsBackground = true;
            _backgroundThread.Start(5);
        }

        static void RunForegroundThread()
        {
            var _foregroundThread = new Thread(new ParameterizedThreadStart(SimpleLoop));
            _foregroundThread.IsBackground = false;
            _foregroundThread.Start(5);
        }

        static void StoppingAThread()
        {
            var _isTerminated = false;
            var _loopThread = new Thread(() =>
            {
                while (!_isTerminated)
                {
                    Console.WriteLine("Thread still running....{0}", DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            });

            _loopThread.Start();
            Console.WriteLine("Thread started. Press any key to stop the thread");
            Console.ReadKey();
            _isTerminated = true;
            _loopThread.Join();
        }

        [ThreadStatic]
        static int _ThreadSpecificFilead_StaticField;
        static int _ThreadSpecificFilead_NoneStaticField;
        static ThreadLocal<int> _ThreadLocal_Field = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });
        static void ThreadSpecificFilead()
        {
            Action action = () =>
              {
                  for (int i = 0; i < 10; i++)
                  {
                      _ThreadSpecificFilead_NoneStaticField++;
                      _ThreadSpecificFilead_StaticField++;
                      Thread.Sleep(1000);
                      Console.WriteLine("Thread-{0},Static Field: {2} vs None-Static Field: {1}",
                          _ThreadLocal_Field,
                          _ThreadSpecificFilead_NoneStaticField,
                          _ThreadSpecificFilead_StaticField);
                  }
              };
            Console.WriteLine("Howmany thread you want to run?");
            Parallel.Invoke(Enumerable.Repeat(action,
                Convert.ToInt32(Console.ReadLine()))
                .ToArray());
            Console.WriteLine("Press any key for termination...");
            Console.ReadKey();
            _ThreadLocal_Field.Dispose();
        }
    }
}