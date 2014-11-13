using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NUtil.Test
{
    [TestClass]
    public class DictionaryExtensionsUT
    {
        [TestMethod]
        public void TestTryGetValue()
        {
            var dic = new Dictionary<int, int>();
            dic.Add(1, 2);

            var result = dic.TryGetValue(1);

            Assert.IsTrue(result.Succes);
            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void TestTryGetValueNoValue()
        {
            var dic = new Dictionary<int, int>();
            var result = dic.TryGetValue(1);

            Assert.IsFalse(result.Succes);
            Assert.AreEqual(default(int), result.Value);
        }

        [TestMethod]
        public void TestGetValueOrDefault()
        {
            var dic = new Dictionary<int, string>();
            dic.Add(1, "Awesome");

            var value = dic.GetValueOrDefault(1);

            Assert.AreEqual("Awesome", value);
        }

        [TestMethod]
        public void TestGetValueOrDefaultNoValue()
        {
            var dic = new Dictionary<int, string>();

            var value = dic.GetValueOrDefault(1);

            Assert.IsNull(value);
        }
    }
}
