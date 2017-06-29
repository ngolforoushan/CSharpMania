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
        public void TestMethod1()
        {
            var res= TimeKeeper.RunTime(() => {
                Thread.Sleep(200);
            });
            Assert.IsTrue(res.Milliseconds >= 200);

        }

    }
}
