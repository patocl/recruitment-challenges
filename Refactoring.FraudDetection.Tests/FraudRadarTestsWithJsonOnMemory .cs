// <copyright file="FraudRadarTests.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.FraudDetection.Core.Infrastructure.Repository;
using Refactoring.FraudDetection.Models.Contracts;
using Refactoring.FraudDetection.Tests.Utils;

namespace Refactoring.FraudDetection.Tests
{
    [TestClass]
    public class FraudRadarTestsWithJsonOnMemory
    {
        [TestMethod]
        public void CheckFraud_OneLineFile_NoFraudExpected()
        {
            var result = ExecuteTest("OneLineFile.txt");

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(0, "The result should not contains fraudulent lines");
        }

        [TestMethod]
        public void CheckFraud_TwoLines_SecondLineFraudulent()
        {
            var result = ExecuteTest("TwoLines_FraudulentSecond.txt");

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_ThreeLines_SecondLineFraudulent()
        {
            var result = ExecuteTest("ThreeLines_FraudulentSecond.txt");

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(1, "The result should contains the number of lines of the file");
            result.First().IsFraudulent.Should().BeTrue("The first line is not fraudulent");
            result.First().OrderId.Should().Be(2, "The first line is not fraudulent");
        }

        [TestMethod]
        public void CheckFraud_FourLines_MoreThanOneFraudulent()
        {
            var result = ExecuteTest("FourLines_MoreThanOneFraudulent.txt");

            result.Should().NotBeNull("The result should not be null.");
            result.Should().HaveCount(2, "The result should contains the number of lines of the file");
        }

        /// <summary>
        /// Fake Reader, to read from Memory Json Format!
        /// </summary>
        private static IList<IFraudResult> ExecuteTest(string filePath)
        {
            var fraudRadar = new FraudRadar(new OrderJsonRepository());
            var fileReader = FakeHelper.CreateFakeFileJsonInMemoryReader(filePath);
            return fraudRadar.Check(fileReader).ToList();
        }
    }
}