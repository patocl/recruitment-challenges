using System.Collections.Generic;
using System.Linq;
using Algorithms.CountingBits.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.CountingBits.Tests.Library
{
    [TestClass]
    public class PositionsTest
    {

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 0, new List<byte>() };
            yield return new object[] { 1, new List<byte> { 0 } };
            yield return new object[] { 15, new List<byte> { 0, 1, 2, 3 } };
            yield return new object[] { 161, new List<byte> { 0, 5, 7 } };
            yield return new object[] { int.MaxValue, new List<byte> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 } };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitArrayBitCount(int number, List<byte> expected)
        {
            var actual = Positions.BitPositions(number);
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitsPositionByBits(int number, List<byte> expected)
        {
            var actual = Positions.BitsPositionByBits(number);
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitsPositionUsingModule(int number, List<byte> expected)
        {
            var actual = Positions.BitsPositionUsingModule(number);
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_LinqBitPosition(int number, List<byte> expected)
        {
            var actual = Positions.LinqBitPosition(number);
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitsPositionWithoutModule(int number, List<byte> expected)
        {
            var actual = Positions.BitsPositionWithoutModule(number);
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }
    }
}
