using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoOnline.Utils
{
    public static class Randomizer
    {

        static Random raffleRandom;
        static ArrayList raffleNumbers;

        static Randomizer()
        {
            raffleRandom = new Random();
            raffleNumbers = new ArrayList();
        }

        public static int Random()
        {
            int value = raffleRandom.Next(2, 101);
            while (true)
            {
                if (!raffleNumbers.Contains(value))
                {
                    raffleNumbers.Add(value);
                    return value;
                }
                value = raffleRandom.Next(2, 101);
            }
        }
    }
}