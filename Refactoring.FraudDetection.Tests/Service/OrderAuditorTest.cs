using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.FraudDetection.Core.Infrastructure.Repository;
using Refactoring.FraudDetection.Core.Specifications.Extensions;
using Refactoring.FraudDetection.Logic.Contracts;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models.Contracts;
using Refactoring.FraudDetection.Service;
using Refactoring.FraudDetection.Tests.Utils;

namespace Refactoring.FraudDetection.Tests.Service
{
    [TestClass]
    public class OrderAuditorTest
    {
        [TestMethod]
        public void Create_Constructor_WithOrderRules()
        {
            var orderRules = new Mock<IFraudRules<IOrder>>();

            var orderAuditor = new OrderAuditor(orderRules.Object);

            orderAuditor.OrderRules.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Analyze_With_Null_Orders()
        {
            var orderAuditor = new OrderAuditor();
            _ = orderAuditor.Analyze(null);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Analyze_With_Orders(int expectedFrauds, IEnumerable<IOrder> orders)
        {
            var orderAuditor = new OrderAuditor();
            var actual = orderAuditor.Analyze(orders);
            actual.Count().Should().Be(expectedFrauds);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestDataNewOrderRules), DynamicDataSourceType.Method)]
        public void Analyze_With_Orders_With_NewOrderRules(int expectedFrauds, IEnumerable<IOrder> orders)
        {
            var orderAuditor = new OrderAuditor();
            var newOrderRules = new NewOrderFraudRules();
            orderAuditor.OrderRules = newOrderRules;
            var actual = orderAuditor.Analyze(orders);
            actual.Count().Should().Be(expectedFrauds);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 0, GetOrders("OneLineFile.txt") };
            yield return new object[] { 1, GetOrders("TwoLines_FraudulentSecond.txt") };
            yield return new object[] { 1, GetOrders("ThreeLines_FraudulentSecond.txt") };
            yield return new object[] { 2, GetOrders("FourLines_MoreThanOneFraudulent.txt") };
        }

        public static IEnumerable<object[]> GetTestDataNewOrderRules()
        {
            yield return new object[] { 0, GetOrders("OneLineFile.txt") };
            yield return new object[] { 1, GetOrders("TwoLines_FraudulentSecond.txt") };
            yield return new object[] { 1, GetOrders("ThreeLines_FraudulentSecond.txt") };
            yield return new object[] { 2, GetOrders("FourLines_MoreThanOneFraudulent.txt") };
        }
        private static IList<IOrder> GetOrders(string filePath)
        {
            var fileReader = FakeHelper.CreateFakeFileJsonInMemoryReader(filePath);
            var orders = new OrderJsonRepository().GetAll(fileReader).ToList();
            return orders;
        }

        public class NewOrderFraudRules : IFraudRules<IOrder>
        {
            public bool IsFraud(IOrder order, IOrder current)
            {
                var distinctCreditCard = new DistinctCreditCardSpecification(order.CreditCard);
                var sameDealId = new SameDealIdSpecification(order.DealId);

                var rule = sameDealId
                    .And(distinctCreditCard)
                    .IsSatisfiedBy(current);

                return rule;
            }
        }
    }
}
