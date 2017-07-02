using System;
using System.Threading;

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
            var sel =Convert.ToInt32(Console.ReadLine());

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
                default:
                    break;
            }
        }

        static void SimpleLoop(object o) {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Worker running {0}",i);
                Thread.Sleep(2000);
            }
        }

        static void RunBackgroundThread() {
            var _backgroundThread = new Thread(new ParameterizedThreadStart(SimpleLoop));
            _backgroundThread.IsBackground = true;
            _backgroundThread.Start(5);
        }

        static void RunForegroundThread() {
            var _foregroundThread = new Thread(new ParameterizedThreadStart(SimpleLoop));
            _foregroundThread.IsBackground = false;
            _foregroundThread.Start(5);
        }

        static void StoppingAThread() {
            var _isTerminated = false;
            var _loopThread = new Thread(() => {
                while (! _isTerminated)
                {
                    Console.WriteLine("Thread still running....{0}",DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            });

            _loopThread.Start();
            Console.WriteLine("Thread started. Press any key to stop the thread");
            Console.ReadKey();
            _isTerminated = true;
            _loopThread.Join();
        }
    }
}