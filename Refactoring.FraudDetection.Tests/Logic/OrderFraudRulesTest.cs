using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Logic;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Tests.Logic
{
    [TestClass]
    public class OrderFraudRulesTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Create_Constructor_WithOrderRules(IOrder order1, IOrder order2, bool expected)
        {
            var orderFraudRules = new OrderFraudRules();
            var actual = orderFraudRules.IsFraud(order1, order2);
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] // same
            {
                new Order
                {
                    OrderId = 1,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                new Order
                {
                    OrderId = 2,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                false
            };
            yield return new object[] // Different email
            {
                new Order
                {
                    OrderId = 1,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                new Order
                {
                    OrderId = 2,
                    DealId = 1,
                    Email = "2",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                false
            };
            yield return new object[] // Different Creditcard
            {
                new Order
                {
                    OrderId = 1,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                new Order
                {
                    OrderId = 2,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "2"
                },
                true
            };
            yield return new object[] // Different address
            {
                new Order
                {
                    OrderId = 1,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "1", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                new Order
                {
                    OrderId = 2,
                    DealId = 1,
                    Email = "1",
                    DealAddress = new Address {City = "2", State = "1", Street = "1", ZipCode = "1"},
                    CreditCard = "1"
                },
                false
            };
        }
    }
}