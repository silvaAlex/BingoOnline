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
            string raffleNumberList = "";
            List<int> raffleNumbers = Enumerable.Range(1, 15).Select(x => x = Randomizer.Random()).ToList();


            raffleNumberList += string.Join(",", raffleNumbers);


            return raffleNumberList;
        }
    }
}