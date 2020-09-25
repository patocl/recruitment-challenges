using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Normalizer.CustomFormats
{
    [TestClass]
    public class StatePropertyTest
    {
        private readonly StateProperty stateProperty = new StateProperty();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_With_Null_ArgumentExceptionExpected()
        {
            _ = stateProperty.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_With_StringEmpty_ArgumentExceptionExpected()
        {
            _ = stateProperty.Create(string.Empty);
        }

        [TestMethod]
        public void Create_With_String_ArgumentExceptionExpected()
        {
            var actual = stateProperty.Create("colorado");
            actual.Should().Be("colorado");
        }

        [TestMethod]
        public void Create_With_StringNewYork_ArgumentExceptionExpected()
        {
            var actual = stateProperty.Create("ny");
            actual.Should().Be("new york");
        }

        [TestMethod]
        public void Create_With_StringCalifornia_ArgumentExceptionExpected()
        {
            var actual = stateProperty.Create("ca");
            actual.Should().Be("california");
        }

        [TestMethod]
        public void Create_With_Stringillinois_ArgumentExceptionExpected()
        {
            var actual = stateProperty.Create("il");
            actual.Should().Be("illinois");
        }

        [TestMethod]
        public void Create_With_StringCaliforniaUppercase_ArgumentExceptionExpected()
        {
            var actual = stateProperty.Create("CA");
            actual.Should().Be("CA");
        }
    }
}