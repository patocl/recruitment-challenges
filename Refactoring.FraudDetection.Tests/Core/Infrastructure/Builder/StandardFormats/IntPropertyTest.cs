using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.StandardFormats;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Builder.StandardFormats
{
    [TestClass]
    public class IntPropertyTest
    {
        private readonly IntProperty intProperty = new IntProperty();

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_ArgumentExceptionExpected(string input)
        {
            intProperty.Create(input);
        }

        [DataTestMethod]
        [DataRow("1a")]
        [DataRow("-1a")]
        [DataRow("2147483649")] // int.MaxValue + 1 ;)
        [ExpectedException(typeof(InvalidCastException))]
        public void Create_InvalidCastExceptionExpected(string input)
        {
            intProperty.Create(input);
        }

        [DataTestMethod]
        [DataRow("1",1)]
        [DataRow("2147483647", int.MaxValue)]
        public void Create_Numbers(string input, int expected)
        {
            var actual = intProperty.Create(input);
            Assert.AreEqual(expected, actual, message: "The result is not the expected");
        }
    }
}
