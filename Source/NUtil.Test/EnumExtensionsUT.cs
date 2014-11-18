namespace NUtil.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EnumExtensionsUT
    {
        enum X
        {
            x1, x2, x3, x4,
            X5, X6, X7, X8
        }

        [TestMethod]
        public void EnumAsStringMustReturnCorrectValue()
        {
            var enumVal = X.X5;

            var myX = enumVal.AsString();

            Assert.AreEqual("X5", myX);
        }

        [TestMethod]
        public void StringAsEnumMustRoundTrip()
        {
            var enumVal = X.X5;
            var myX = enumVal.AsString();

            X valAsEnum = myX.AsEnum<X>();

            Assert.IsTrue(valAsEnum == enumVal);
            Assert.AreEqual("X5", myX);
        }

        [TestMethod]
        public void StringAsEnumShouldIgnoreCase()
        {
            var enumVal = X.X5;
            var myX = enumVal.AsString();
            myX = myX.ToLowerInvariant();

            X valAsEnum = myX.AsEnum<X>();

            Assert.AreEqual("x5", myX);
            Assert.IsTrue(valAsEnum == enumVal);
        }
    }
}
