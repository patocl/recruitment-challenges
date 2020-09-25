using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Tests.Logic.OrderSpecifications
{
    [TestClass]
    public class SameDealAddressSpecificationTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Create_Constructor_WithOrderRules(IAddress address1, IAddress address2, bool expected)
        {
            var sameDealAddressSpecificationTest = new SameDealAddressSpecification(address1);
            var actual = sameDealAddressSpecificationTest.IsSatisfiedBy(address2);
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1"}, 
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1" }, 
                true
            };
            yield return new object[]
            {
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1"},
                new Address { City = "2", State = "1", Street = "1", ZipCode = "1" },
                false
            };
            yield return new object[]
            {
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1"},
                new Address { City = "1", State = "2", Street = "1", ZipCode = "1" },
                false
            };
            yield return new object[]
            {
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1"},
                new Address { City = "1", State = "1", Street = "2", ZipCode = "1" },
                false
            };
            yield return new object[]
            {
                new Address { City = "1", State = "1", Street = "1", ZipCode = "1"},
                new Address { City = "1", State = "1", Street = "1", ZipCode = "2" },
                false
            };
        }
    }
}
