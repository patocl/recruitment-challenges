// <copyright file="PositiveBitCounterTest.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.CountingBits.Tests
{
    [TestClass]
    public class PositiveBitCounterTest
    {
        private readonly PositiveBitCounter bitCounter = new PositiveBitCounter();

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Count_NegativeValue_ArgumentExceptionExpected()
        {
            this.bitCounter.Count(-2);
        }

        [TestMethod]
        public void Count_Zero_NoOccurrences()
        {
            CollectionAssert.AreEqual(
                expected: new List<byte> { 0 },
                actual: this.bitCounter.Count(0).ToList(),
                message: "The result is not the expected");
        }

        [TestMethod]
        public void Count_ValidInput_OneOcurrence()
        {
            CollectionAssert.AreEqual(
                expected: new List<byte> { 1, 0 },
                actual: this.bitCounter.Count(1).ToList(),
                message: "The result is not the expected");
        }

        [TestMethod]
        public void Count_ValidInput_MultipleOcurrence()
        {
            CollectionAssert.AreEqual(
                expected: new List<byte> { 3, 0, 5, 7 },
                actual: this.bitCounter.Count(161).ToList(),
                message: "The result is not the expected");
        }

        /// <summary>
        /// Added by HG
        /// Check the result when all digits are 1, by example number 15
        /// </summary>
        [TestMethod]
        public void Count_ValidInput_FullOcurrence()
        {
            CollectionAssert.AreEqual(
                expected: new List<byte> { 4, 0, 1, 2, 3 },
                actual: this.bitCounter.Count(15).ToList(),
                message: "The result is not the expected");
        }

        /// <summary>
        /// Added by HG
        /// Added to evaluate the maximum integer value possible
        /// </summary>
        [TestMethod]
        public void Count_ValidInput_MaxIntegerValue()
        {
            CollectionAssert.AreEqual(
                expected: new List<byte> { 31, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
                actual: this.bitCounter.Count(int.MaxValue).ToList(),
                message: "The result is not the expected");
        }
    }
}