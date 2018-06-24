using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Cards
{
    public class CardBase
    {
        public string CardId { get; set; }
        public List<CardColumn> Columns { get; set; }

        public CardBase()
        {
            Columns = new List<CardColumn>();
        }
    }
}
