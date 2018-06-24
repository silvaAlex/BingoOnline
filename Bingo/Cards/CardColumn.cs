using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Cards
{
    public class CardColumn
    {
        public int Count { get; set; }
        public List<CardEmpty> Rows { get; set; }

        public CardColumn()
        {
            Rows = new List<CardEmpty>();
        }
    }
}
