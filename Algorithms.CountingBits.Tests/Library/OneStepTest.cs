using System.Collections.Generic;
using System.Linq;
using Algorithms.CountingBits.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.CountingBits.Tests.Library
{
    [TestClass]
    public class OneStepTest
    {
        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 0, new List<byte> { 0 } };
            yield return new object[] { 1, new List<byte> { 1, 0 } };
            yield return new object[] { 15, new List<byte> { 4, 0, 1, 2, 3 } };
            yield return new object[] { 161, new List<byte> { 3, 0, 5, 7 } };
            yield return new object[] { int.MaxValue, new List<byte> { 31, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 } };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitByBitGetCount(int number, List<byte> expected)
        {
            var actual = number.BitByBitGetCount();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_BitByBitGetCountRevengeLog2(int number, List<byte> expected)
        {
            var actual = number.BitByBitGetCountRevengeLog2();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_LinqGetCount(int number, List<byte> expected)
        {
            var actual = number.LinqGetCount();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_Precomputed2WordBitCountBitPositionsGetCount(int number, List<byte> expected)
        {
            var actual = number.Precomputed2WordBitCountBitPositionsGetCount();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_Precomputed2WordBitCountBitsPositionByBitsGetCount(int number, List<byte> expected)
        {
            var actual = number.Precomputed2WordBitCountBitsPositionByBitsGetCount();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Check_NetFrameworkModeGetCount(int number, List<byte> expected)
        {
            var actual = number.NetFrameworkModeGetCount();
            CollectionAssert.AreEqual(expected, actual.ToList(), message: "The result is not the expected");
        }
    }
}
