using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jacaranda.Utilities.Test
{
    [TestClass]
    public class ExceptionExtensionTest
    {
        [TestMethod]
        public void GetFullMessagesTest()
        {
            var ex = new Exception("This is a test exception", new Exception("This is the inner exception"));
            Assert.AreEqual(ex.GetFullMessages("-->"), "This is a test exception --> This is the inner exception");
        }
    }
}
