using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Tests.Logic.OrderSpecifications
{
    [TestClass]
    public class SameEmailSpecificationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Create_Constructor_WithOrderRules(string mail, IOrder order, bool expected)
        {
            var sameEmailSpecification = new SameEmailSpecification(mail);
            var actual = sameEmailSpecification.IsSatisfiedBy(order);
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { "1", new Order { Email = "1" }, true };
            yield return new object[] { "2", new Order { Email = "1" }, false };
            yield return new object[] { "1", new Order { Email = "2" }, false };
            yield return new object[] { "1", new Order { Email = "" }, false };
            yield return new object[] { "", new Order { Email = "1" }, false };
        }
    }
}