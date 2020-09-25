using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Normalizer.CustomFormats
{
    [TestClass]
    public class StreetPropertyTest
    {
        private readonly StreetProperty streetProperty = new StreetProperty();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_With_Null_ArgumentExceptionExpected()
        {
            _ = streetProperty.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_With_StringEmpty_ArgumentExceptionExpected()
        {
            _ = streetProperty.Create(string.Empty);
        }

        [TestMethod]
        public void Create_With_String_ArgumentExceptionExpected()
        {
            var actual = streetProperty.Create("my street");
            actual.Should().Be("my street");
        }

        [TestMethod]
        public void Create_With_StringNewYork_ArgumentExceptionExpected()
        {
            var actual = streetProperty.Create("st.");
            actual.Should().Be("street");
        }

        [TestMethod]
        public void Create_With_StringCalifornia_ArgumentExceptionExpected()
        {
            var actual = streetProperty.Create("rd.");
            actual.Should().Be("road");
        }
    }
}