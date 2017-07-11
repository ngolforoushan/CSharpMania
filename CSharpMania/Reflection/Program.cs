using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        const int ITERATIONS = 10000000;
        static void Main(string[] args)
        {
            loop();
        }

        private static void loop()
        {
            int sel;
            do
            {
                list_print();
                sel = Convert.ToInt32(Console.ReadLine());
                switch (sel)
                {
                    case 1:
                        PerformanceTest();
                        break;
                    default:
                        break;
                }
            } while (sel != 0);
        }

        private static void list_print()
        {

            Console.WriteLine("***********************");
            Console.WriteLine("1.Performance Compare  ");
            Console.WriteLine("***********************");
        }

        private static void results_print(Action action)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
            action();
        }

        private static void PerformanceTest()
        {
            Console.WriteLine("Output>>>");

            PerformanceTest_StaticCreate(ITERATIONS);
            PerformanceTest_ReflectionCreate(ITERATIONS);
            PerformanceTest_StaticCallAdd(ITERATIONS);
            PerformanceTest_ReflectionCallAdd(ITERATIONS);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PerformanceTest_StaticCallAdd(int iterations)
        {
            var startTime = DateTimeOffset.Now;
            var list = new List<int>();
            for (int i = 0; i < iterations; i++)
            {
                list.Add(i);
            }
            var endTime = DateTimeOffset.Now;
            results_print(() =>
            {
                Console.WriteLine("Static Add Duration:{0}ms", GetDuration(startTime, endTime));
            });
        }

        private static void PerformanceTest_ReflectionCallAdd(int iterations)
        {
            var startTime = DateTimeOffset.Now;
            var list = new List<int>();
            Type listType = typeof(List<int>);
            Type[] parametersType = { typeof(int) };
            MethodInfo method = listType.GetMethod("Add", parametersType);
            for (int i = 0; i < iterations; i++)
            {
                method.Invoke(list,new object[]{i});
            }
            var endTime = DateTimeOffset.Now;
            results_print(() =>
            {
                Console.WriteLine("Reflection Add Duration:{0}ms", GetDuration(startTime, endTime));
            });
        }

        private static void PerformanceTest_ReflectionCreate(int iterations)
        {
            Type listType = typeof(List<int>);
            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                var list = Activator.CreateInstance(listType);
            }
            var endTime = DateTimeOffset.Now;

            results_print(() =>
            {
                Console.WriteLine("Reflection Creation Duration:{0}ms", GetDuration(startTime, endTime));
            });
        }

        private static void PerformanceTest_StaticCreate(int iterations)
        {
            var startTime = DateTimeOffset.Now;
            for (int i = 0; i < iterations; i++)
            {
                var list = new List<int>();
            }
            var endTime = DateTimeOffset.Now;
            results_print(() =>
            {
                Console.WriteLine("Static Creation Duration:{0}ms", GetDuration(startTime, endTime));
            });
        }

        private static int GetDuration(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            return (endTime - startTime).Milliseconds;
        }
    }
}