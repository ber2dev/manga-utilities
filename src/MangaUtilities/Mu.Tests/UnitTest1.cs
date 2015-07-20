using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mu.Core;

namespace Mu.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var env = MuEnvironment.Instance;
            env.Load();
        }
    }
}
