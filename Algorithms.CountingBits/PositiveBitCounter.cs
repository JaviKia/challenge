// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException();
            var positions = new List<int>
            {
                0
            };
            int currentPosition = 0;
            while (input > 0)
            {
                if ((input & 1) == 1)
                {
                    positions.Add(currentPosition);
                    positions[0] ++;
                }
                input >>= 1;
                currentPosition++;
            }
            return positions;
        }

    }
}
