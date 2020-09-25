// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>
using Algorithms.CountingBits.Library;
using System;
using System.Collections.Generic;

namespace Algorithms.CountingBits
{
    public class PositiveBitCounter
    {
        public IEnumerable<byte> Count(int input)
            => input >= 0 
                ? input.BitByBitGetCount() 
                : throw new ArgumentException("should be positive", nameof(input));
    }
}
