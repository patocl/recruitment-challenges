using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Tests.Logic.OrderSpecifications
{
    [TestClass]
    public class SameDealIdSpecificationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Create_Constructor_WithOrderRules(int dealId, IOrder order, bool expected)
        {
            var sameDealIdSpecification = new SameDealIdSpecification(dealId);
            var actual = sameDealIdSpecification.IsSatisfiedBy(order);
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, new Order { DealId = 1 }, true };
            yield return new object[] { 2, new Order { DealId = 1 }, false };
            yield return new object[] { 1, new Order { DealId = 2 }, false };
        }
    }
}