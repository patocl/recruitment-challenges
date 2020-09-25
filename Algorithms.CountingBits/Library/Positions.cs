using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.CountingBits.Library
{
    /// <summary>
    /// Algorithms to get  the respective one-indexed locations of each 1-bit from most to least significant
    /// Note: The results are in in ascending order
    /// </summary>
    public static class Positions
    {
        public static IEnumerable<byte> BitPositions(int number)
        {
            var positions = new List<byte>();
            byte position = 0;
            while (number != 0)
            {
                if ((number & 1) != 0)
                    positions.Add(position);

                position++;
                number >>= 1;
            }
            return positions;
        }

        public static IEnumerable<byte> BitsPositionByBits(this int number)
        {
            const int digits = 32;
            var positions = new List<byte>();

            for (byte i = 0; i < digits; i++)
            {
                if ((number & 1 << i) != 0)
                    positions.Add(i);
            }

            return positions;
        }

        public static IEnumerable<byte> LinqBitPosition(int number) 
            => Convert.ToString(number, 2)
                .Reverse()
                .Select((bits, position) => bits.Equals('1') ? (byte)position : byte.MaxValue)
                .Where(position => position != byte.MaxValue);

        public static IEnumerable<byte> BitsPositionUsingModule(this int number)
        {
            var positions = new List<byte>();
            byte count = 0;
            while (number > 0)
            {
                if ((number % 2) != 0)
                    positions.Add(count);
                number /= 2;           
                count++;
            }
            return positions;
        }

        public static IEnumerable<byte> BitsPositionWithoutModule(this int number)
        {
            var positions = new List<byte>();
            byte count = 0;
            while (number > 0)
            {
                if ((number & 1) != 0) // I replaced the Mod operator % to bitwise And Operator
                    positions.Add(count);
                number /= 2;
                count++;
            }
            return positions;
        }
    }
}
