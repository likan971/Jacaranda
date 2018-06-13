using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jacaranda.Utilities.Test
{
    [TestClass]
    public class ConfigReaderTest
    {
        [TestMethod]
        public void ReadStringTest()
        {
            var result = ConfigReader.GetAppSettings<string>("string");
            Assert.IsTrue(result.GetType() == typeof(string));
            Assert.AreEqual(result, "abc");
        }

        [TestMethod]
        public void ReadNumberTest()
        {
            var result = ConfigReader.GetAppSettings<int>("number");
            Assert.IsTrue(result.GetType() == typeof(int));
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void ReadDecimalTest()
        {
            var result = ConfigReader.GetAppSettings<decimal>("decimal");
            Assert.IsTrue(result.GetType() == typeof(decimal));
            Assert.AreEqual(result, (decimal)1.5);
        }

        [TestMethod]
        public void ReadFloatTest()
        {
            var result = ConfigReader.GetAppSettings<float>("float");
            Assert.IsTrue(result.GetType() == typeof(float));
            Assert.AreEqual(result, (float)3.1415926);
        }

        [TestMethod]
        public void ReadDateTimeTest()
        {
            var result = ConfigReader.GetAppSettings<DateTime>("datetime");
            Assert.IsTrue(result.GetType() == typeof(DateTime));
            Assert.AreEqual(result, new DateTime(2018, 6, 1));
        }

        [TestMethod]
        public void ReadNotSetEntryTest()
        {
            var result1 = ConfigReader.GetAppSettings<int>("notset");
            Assert.AreEqual(result1, default(int));

            var result2 = ConfigReader.GetAppSettings("notset", 2);
            Assert.AreEqual(result2, 2);

            var result3 = ConfigReader.GetAppSettings("notset", string.Empty);
            Assert.AreEqual(result3, string.Empty);
        }
    }
}
