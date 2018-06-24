using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BingoOnline.Models;
using BingoOnline.Utils;

namespace BingoOnline.Cards
{
    public class GenerateCard
    {
        public string CreateSortedNumbers()
        {
            string sortedList = "";
            List<int> sortedNumbers = Enumerable.Range(1, 15).Select(x => x = Randomizer.Random()).ToList();

            foreach (int sorted in sortedNumbers)
            {
                sortedList += sorted.ToString() + ",";
            }

            return sortedList;
        }
    }
}