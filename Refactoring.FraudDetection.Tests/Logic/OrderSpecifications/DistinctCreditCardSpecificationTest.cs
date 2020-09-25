using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Tests.Logic.OrderSpecifications
{
    [TestClass]
    public class DistinctCreditCardSpecificationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Create_Constructor_WithOrderRules(string creditcard, IOrder order, bool expected)
        {
            var distinctCreditCardSpecification = new DistinctCreditCardSpecification(creditcard);
            var actual = distinctCreditCardSpecification.IsSatisfiedBy(order);
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { "1", new Order { CreditCard = "1" }, false };
            yield return new object[] { "2", new Order { CreditCard = "1" }, true };
            yield return new object[] { "1", new Order { CreditCard = "2" }, true };
            yield return new object[] { "1", new Order { CreditCard = "" }, true }; //checking empty values
            yield return new object[] { "", new Order { CreditCard = "1" }, true }; //checking empty values
        }
    }
}
