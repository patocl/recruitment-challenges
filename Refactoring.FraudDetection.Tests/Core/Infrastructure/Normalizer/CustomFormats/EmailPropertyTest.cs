using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats;
using System;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Normalizer.CustomFormats
{
    [TestClass]
    public class EmailPropertyTest
    {
        private readonly EmailProperty emailProperty = new EmailProperty();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_With_Null_ArgumentExceptionExpected()
        {
            _ = emailProperty.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_ArgCreate_With_StringEmpty_ArgumentExceptionExpectedmentExceptionExpected()
        {
            _ = emailProperty.Create("");
        }

        [TestMethod]
        public void Create()
        {
            var actual = emailProperty.Create("bugs@bunny.com");
            actual.Should().Be("bugs@bunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithoutSymbolAt()
        {
            _ = emailProperty.Create("bugsbunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithPlusAtBegin()
        {
            var actual = emailProperty.Create("+bugs@bunny.com");
            actual.Should().Be("bugsbunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithPlusAtMidle()
        {
            _ = emailProperty.Create("bugs+lucas@bunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithManyPlusAtBegin()
        {
            _ = emailProperty.Create("bugs+lucas@bunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithManyPlusAtEnd()
        {
            _ = emailProperty.Create("bugs+lucas+elmer@bunny.com");
        }

        // TOODO (HG) Must to Enable this TestCase when the rules about Mail be clear
        [TestMethod]
        [Ignore]
        public void Create_WithInvalidMailWithManyPlusAfterAtSymbol()
        {
            var actual = emailProperty.Create("bugs@bun+ny.com");
            actual.Should().Be("bug"); //funny email :D
        }

        // TOODO (HG) Must to Enable this TestCase when the rules about Mail be clear
        [TestMethod]
        [Ignore]
        public void Create_WithInvalidMailWithPlusAfterAtSymbol()
        {
            var actual = emailProperty.Create("bugs@+bunny.com");
            actual.Should().Be("bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMail_WithoutstringBeforeAt()
        {
            _ = emailProperty.Create("@bunny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailPlusAtMidleAfterAtSymbol_WithoutstringBeforeAt()
        {
            _ = emailProperty.Create("@bun+ny.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithPlusAtEndAfterAtSymbol()
        {
            _ = emailProperty.Create("@bunny.com+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithMultiplesAtAtSymbol()
        {
            _ = emailProperty.Create("bunny@lucas@elmer.com");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WithInvalidMailWithoutAtSymbol()
        {
            var actual = emailProperty.Create("bunnylucaselmer");
        }
    }
}
