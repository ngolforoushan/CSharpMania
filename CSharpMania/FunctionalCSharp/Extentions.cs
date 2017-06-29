using System;
using System.Threading;

namespace FunctionalCSharp
{
    public static class Extentions
    {
        /// <summary>
        /// Retry action before throw an exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T WithRetry<T>(this Func<T> action) {
            var result = default(T);
            int retyCount = 0;
            bool succesful = false;
            do
            {
                try
                {
                    result = action();
                    succesful = true;
                }
                catch (Exception ex)
                {
                    retyCount++;
                    Thread.Sleep(500);
                }
            } while (retyCount<3 && !succesful);
            return result;
        }
    }
}
