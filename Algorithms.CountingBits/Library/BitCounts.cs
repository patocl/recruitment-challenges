using System;
using System.Collections;
using System.Linq;

namespace Algorithms.CountingBits.Library
{
    /// <summary>
    /// A set of algorithms to calculate How many 1-bits are in its binary representation of a given number
    /// Note: each one use different mechanism, bitwise operations, .NET specific functions, etc.
    /// </summary>
    public static class BitCounts
    {
        private static int[] _listCount2Words;
        private static short[] _listCount4Bytes;

        static BitCounts()
        {
            PrecomputedListCount2Words();
            PrecomputedListCount4Bytes();
        }

        private static void PrecomputedListCount2Words()
        {
            _listCount2Words = new int[65536];
            var position1 = -1;
            var position2 = -1;
            for (var i = 1; i < 65536; i++, position1++)
            {
                if (position1 == position2)
                {
                    position1 = 0;
                    position2 = i;
                }
                _listCount2Words[i] = _listCount2Words[position1] + 1;
            }
        }

        private static void PrecomputedListCount4Bytes()
        {
            _listCount4Bytes = new short[256];

            for (var i = 0; i < 256; i++)
                _listCount4Bytes[i] = (short)((i & 1) + _listCount4Bytes[i / 2]);
        }

        public static int RecursiveBitCount(int number)
        {
            if (number == 0)
                return 0;

            return (number & 1) + RecursiveBitCount(number >> 1);
        }

        public static byte SparseBitCount(int number)
        {
            byte count = 0;
            while (number != 0)
            {
                count++;
                number &= number - 1;
            }
            return count;
        }

        public static byte IteratedBitCount(int number)
        {
            var test = number;
            byte count = 0;

            while (test != 0)
            {
                if ((test & 1) == 1)
                    count++;

                test >>= 1;
            }
            return count;
        }

        public static int Precomputed2WordBitCount(int number)
        {
            return _listCount2Words[number & 65535]
                + _listCount2Words[number >> 16 & 65535];
        }

        public static int Precomputed4BytesBitCount(int number)
        {
            return _listCount4Bytes[number & 255]
                + _listCount4Bytes[number >> 8 & 255]
                + _listCount4Bytes[number >> 16 & 255]
                + _listCount4Bytes[number >> 24];
        }

        private static readonly int[] ListCountManual = { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4 };

        public static int PreComputedListManualRecursiveBitCount(int number)
        {
            if (number == 0)
                return ListCountManual[0];

            var nibble = number & 0xf;
            return ListCountManual[nibble]
                + PreComputedListManualRecursiveBitCount(number >> 4);
        }

        public static int BitByBitCount(int number)
        {
            const byte digits = 32;
            byte count = 0;

            for (byte i = 0; i < digits; i++)
                if ((number & 1 << i) != 0)
                    count++;

            return count;
        }

        public static byte LinqBitCount(int number)
            => (byte) Convert.ToString(number, 2).Count(digit => digit == '1');

        public static byte BitArrayBitCount(int number)
        {
            var b = new BitArray(new[] { number });
            var bits = new bool[b.Count];
            b.CopyTo(bits, 0);
            byte count = 0;
            foreach (var bit in bits)
            {
                if (bit)
                    count++;
            }

            return count;
        }
    }
}
