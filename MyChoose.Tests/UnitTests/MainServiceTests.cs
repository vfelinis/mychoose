using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyChoose.Tests.UnitTests
{
    [TestClass]
    public class MainServiceTests
    {
        [TestMethod]
        public void Test()
        {
            var expected = 10;

            var actual = 5 * 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
