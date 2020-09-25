using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.CountingBits.Library
{
    /// <summary>
    /// Algorithms to solve the challenge Counting Bits of Payvision
    /// </summary>
    public static class OneStep
    {
        /// <summary>
        /// This is my favorite implementation because perform both task in one buckle! and it's the Winner!
        /// Note: the number of digits 32 could be the Log2n(number), but it's increase the performance
        /// </summary>
        public static IEnumerable<byte> BitByBitGetCount(this int number)
        {
            const byte digits = 31;
            var bitsPositiveInfo = new List<byte>();
            byte count = 0;

            for (byte i = 0; i < digits; i++)
            {
                if ((number & 1 << i) == 0) continue;
                bitsPositiveInfo.Add(i);
                count++;
            }
            bitsPositiveInfo.Insert(0, count);

            return bitsPositiveInfo;
        }

        /// <summary>
        /// get the number of bits (digits) to store a given number
        /// </summary>
        public static byte Log2(int number)
        {
            short i;
            for (i = -1; number != 0; i++)
                number >>= 1;

            return i == -1 ? (byte)0 : (byte)(i + 1);
        }

        /// <summary>
        /// Trying to avoid loops
        /// </summary>
        public static IEnumerable<byte> BitByBitGetCountRevengeLog2(this int number)
        {
            var digits = Log2(number);
            var bitsPositiveInfo = new List<byte>();
            byte count = 0;

            for (byte i = 0; i < digits; i++)
            {
                if ((number & 1 << i) == 0) continue;
                bitsPositiveInfo.Add(i);
                count++;
            }

            bitsPositiveInfo.Insert(0, count);

            return bitsPositiveInfo;
        }

        /// <summary>
        /// This algorithm use Linq to get the desired values
        /// Note: Well it could be considered the faster way to program but not to get performance!
        /// </summary>
        public static IEnumerable<byte> LinqGetCount(this int number)
        {
            var bitsPositiveInfo = new List<byte>();

            var count = BitCounts.LinqBitCount(number);
            bitsPositiveInfo.Add(count);
            if (count > 0)
                bitsPositiveInfo.AddRange(Positions.LinqBitPosition(number));

            return bitsPositiveInfo;
        }

        /// <summary>
        /// This algorithm use the faster single task Precomputed2WordBitCount and BitPositions
        /// Note: I think it could be the best but isn't
        /// </summary>
        public static IEnumerable<byte> Precomputed2WordBitCountBitPositionsGetCount(this int number)
        {
            var bitsPositiveInfo = new List<byte>();

            var count = (byte)BitCounts.Precomputed2WordBitCount(number);
            bitsPositiveInfo.Add(count);
            if (count > 0)
                bitsPositiveInfo.AddRange(Positions.BitPositions(number));

            return bitsPositiveInfo;
        }

        /// <summary>
        /// This algorithm use the faster single task Precomputed2WordBitCount and BitsPositionByBits
        /// Note: I can't get better performance using it too
        /// </summary>
        public static IEnumerable<byte> Precomputed2WordBitCountBitsPositionByBitsGetCount(this int number)
        {
            var bitsPositiveInfo = new List<byte>();

            var count = (byte)BitCounts.Precomputed2WordBitCount(number);
            bitsPositiveInfo.Add(count);
            if (count > 0)
                bitsPositiveInfo.AddRange(number.BitsPositionByBits());

            return bitsPositiveInfo;
        }

        /// <summary>
        /// Using the Net Framework capacities
        /// </summary>
        public static IEnumerable<byte> NetFrameworkModeGetCount(this int number)
        {
            var bitsPositiveInfo = new List<byte>();
            byte count = 0;
            byte position = 0;
            var binary = Convert.ToString(number, 2).Reverse();

            foreach (var bit in binary)
            {
                if (bit == '1')
                {
                    count++;
                    bitsPositiveInfo.Add(position);
                }
                position++;
            }
            bitsPositiveInfo.Insert(0, count);
            return bitsPositiveInfo;
        }
    }
}
