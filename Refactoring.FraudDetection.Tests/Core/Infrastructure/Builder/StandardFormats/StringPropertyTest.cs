using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.StandardFormats;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Builder.StandardFormats
{
    [TestClass]
    public class StringPropertyTest
    {
        private readonly StringProperty stringProperty = new StringProperty();

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_ArgumentExceptionExpected(string input)
        {
            stringProperty.Create(input);
        }

        [DataTestMethod]
        [DataRow(" ", " ")]
        [DataRow("Roger Rabbit", "Roger Rabbit")]
        public void Create_String(string input, string expected)
        {
            var actual = stringProperty.Create(input);
            Assert.AreEqual(expected, actual, message: "The result is not the expected");
        }
    }
}
