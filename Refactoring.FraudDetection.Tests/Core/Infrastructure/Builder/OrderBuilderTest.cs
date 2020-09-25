using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.FraudDetection.Core.Infrastructure.Builder;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Builder
{
    [TestClass]
    public class OrderBuilderTest
    {
        private readonly IObjectBuilder<IOrder> orderBuilder = new OrderBuilder();

        [TestMethod]
        public void Constructor_Empty()
        {
            var orderBuilder = new OrderBuilder();
            orderBuilder.IntProperty.Should().NotBeNull();
            orderBuilder.StringProperty.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithNullParameters()
        {
            _ = new OrderBuilder(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithSecondParameterInNull()
        {
            var intPropertyMock = new Mock<IPropertyBuilder<int>>();
            _ = new OrderBuilder(intPropertyMock.Object, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithFirstParameterInNull()
        {
            var stringPropertyMock = new Mock<IPropertyBuilder<string>>();
            _ = new OrderBuilder(null, stringPropertyMock.Object);
        }
    }
}