using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer;

namespace Refactoring.FraudDetection.Tests.Core.Infrastructure.Normalizer
{
    [TestClass]
    public class OrderNormalizerTest
    {
        [TestMethod]
        public void Constructor_Empty()
        {
            var orderNormalizer = new OrderNormalizer();
            orderNormalizer.EmailBuilder.Should().NotBeNull();
            orderNormalizer.StateBuilder.Should().NotBeNull();
            orderNormalizer.StateBuilder.Should().NotBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_All_ParametersNull()
        {
            _ = new OrderNormalizer(null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Parameters_FirstOk_SecondNull_ThirdNull()
        {
            var emailBuilder = new Mock<IPropertyBuilder<string>>();

            _ = new OrderNormalizer(emailBuilder.Object, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Parameters_FirstOk_SecondOk_ThirdNull()
        {
            var emailBuilder = new Mock<IPropertyBuilder<string>>();
            var streetBuilder = new Mock<IPropertyBuilder<string>>();

            _ = new OrderNormalizer(emailBuilder.Object, streetBuilder.Object, null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Parameters_FirstNull_SecondOk_ThirdOk()
        {
            var streetBuilder = new Mock<IPropertyBuilder<string>>();
            var stateBuilder = new Mock<IPropertyBuilder<string>>();

            _ = new OrderNormalizer(null, streetBuilder.Object, stateBuilder.Object);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Parameters_FirstNull_SecondNUll_ThirdOk()
        {
            var stateBuilder = new Mock<IPropertyBuilder<string>>();

            _ = new OrderNormalizer(null, null, stateBuilder.Object);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Parameters_FirstParamOk_SecondNull_ThirdOk()
        {
            var emailBuilder = new Mock<IPropertyBuilder<string>>();
            var stateBuilder = new Mock<IPropertyBuilder<string>>();

            _ = new OrderNormalizer(emailBuilder.Object, null, stateBuilder.Object);
        }

        [TestMethod]
        public void Constructor_Parameters_FirstOk_SecondOk_ThirdOk()
        {
            var emailBuilder = new Mock<IPropertyBuilder<string>>();
            var streetBuilder = new Mock<IPropertyBuilder<string>>();
            var stateBuilder = new Mock<IPropertyBuilder<string>>();

            var orderNormalizer = new OrderNormalizer(emailBuilder.Object, streetBuilder.Object, stateBuilder.Object);

            orderNormalizer.EmailBuilder.Should().NotBeNull();
            orderNormalizer.StateBuilder.Should().NotBeNull();
            orderNormalizer.StateBuilder.Should().NotBeNull();
        }
    }
}
