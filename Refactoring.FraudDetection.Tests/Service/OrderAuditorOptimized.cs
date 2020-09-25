using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.FraudDetection.Core.Infrastructure.Repository;
using Refactoring.FraudDetection.Logic.Contracts;
using Refactoring.FraudDetection.Models.Contracts;
using Refactoring.FraudDetection.Service;
using Refactoring.FraudDetection.Tests.Utils;

namespace Refactoring.FraudDetection.Tests.Service
{
    [TestClass]
    public class OrderAuditorOptimizedTest
    {
        [TestMethod]
        public void Create_Constructor_WithOrderRules()
        {
            var orderRules = new Mock<IFraudRules<IOrder>>();

            var orderAuditorOptimized = new OrderAuditorOptimized(orderRules.Object);

            orderAuditorOptimized.OrderRules.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Analyze_With_Null_Orders()
        {
            var orderAuditorOptimized = new OrderAuditorOptimized();
            _ = orderAuditorOptimized.Analyze(null);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Analyze_With_Orders(int expectedFrauds, IEnumerable<IOrder> orders)
        {
            var orderAuditorOptimized = new OrderAuditorOptimized();
            var actual = orderAuditorOptimized.Analyze(orders);
            actual.Count().Should().Be(expectedFrauds);
        }

        public static IEnumerable<object[]> GetTestData()
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
    }
}
