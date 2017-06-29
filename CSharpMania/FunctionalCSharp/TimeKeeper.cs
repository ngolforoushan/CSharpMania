using System;
using System.Diagnostics;

namespace FunctionalCSharp
{
    public static class TimeKeeper
    {
        public static TimeSpan RunTime(Action action) {
            var meter = new Stopwatch();
            meter.Start();
            action();
            return meter.Elapsed;
        }

        public static Func<TResult> Partial <TParam1, TResult>(this Func<TParam1, TResult> func, TParam1 parameter)
        {
            return () => func(parameter);
        }
    }
}
