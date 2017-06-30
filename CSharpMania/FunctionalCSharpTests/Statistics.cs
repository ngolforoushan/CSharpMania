using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalCSharp;
using System.Threading;

namespace FunctionalCSharpTests
{
    [TestClass]
    public class Statistics
    {
        [TestMethod]
        public void action_runing_time_is_mesurable()
        {
            var res= TimeKeeper.RunTime(() => {
                Thread.Sleep(200);
            });
            Assert.IsTrue(res.Milliseconds >= 200);

        }

        [TestMethod]
        public void partial_test() {
            Func<string,string> testfunc = (name) => {
                return $"Hello {name}";
            };
            var res = testfunc.Partial("navid").WithRetry();
            Assert.AreEqual(res, "Hello navid");
        }
    }
}
