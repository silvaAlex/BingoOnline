using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoOnline.Utils
{
    public static class Randomizer
    {

        static Random sortedRandom;
        static ArrayList sortedNumbers;

        static Randomizer()
        {
            sortedRandom = new Random();
            sortedNumbers = new ArrayList();
        }

        public static int Random()
        {
            int value = sortedRandom.Next(2, 101);
            while (true)
            {
                if (!sortedNumbers.Contains(value))
                {
                    sortedNumbers.Add(value);
                    return value;
                }
                value = sortedRandom.Next(2, 101);
            }
        }
    }
}