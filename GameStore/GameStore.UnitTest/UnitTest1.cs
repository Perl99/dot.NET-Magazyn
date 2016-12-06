using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string login = "admin";

            Assert.AreEqual(login, "admin");
        }
    }
}
