using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Cards
{
    public class CardEmpty
    {
        public int Value { get; set; }
        public bool IsBlank { get; set; }

        public CardEmpty()
        {
            IsBlank = false;
        }
    }
}
