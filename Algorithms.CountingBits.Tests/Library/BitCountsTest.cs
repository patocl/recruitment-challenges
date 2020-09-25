using Algorithms.CountingBits.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.CountingBits.Tests.Library
{
    [TestClass]
    public class BitCountsTest
    {
        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_BitArrayBitCount(int number, byte result)
        {
            var expected = result;
            var actual = BitCounts.BitArrayBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_BitByBitCount(int number, byte result)
        {
            var expected = result;
            var actual = (byte) BitCounts.BitByBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_IteratedBitCount(int number, byte result)
        {
            var expected = result;
            var actual = BitCounts.IteratedBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_LinqBitCount(int number, byte result)
        {
            var expected = result;
            var actual = BitCounts.LinqBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_PreComputedListManualRecursiveBitCount(int number, byte result)
        {
            var expected = result;
            var actual = (byte) BitCounts.PreComputedListManualRecursiveBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_Precomputed2WordBitCount(int number, byte result)
        {
            var expected = result;
            var actual = (byte) BitCounts.Precomputed2WordBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_Precomputed4BytesBitCount(int number, byte result)
        {
            var expected = result;
            var actual = (byte) BitCounts.Precomputed4BytesBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_RecursiveBitCount(int number, byte result)
        {
            var expected = result;
            var actual = (byte) BitCounts.RecursiveBitCount(number);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, (byte)0)]
        [DataRow(1, (byte)1)]
        [DataRow(15, (byte)4)]
        [DataRow(161, (byte)3)]
        [DataRow(int.MaxValue, (byte)31)]
        public void Check_SparseBitCount(int number, byte result)
        {
            var expected = result;
            var actual = BitCounts.SparseBitCount(number);
            Assert.AreEqual(expected, actual);
        }
    }
}
