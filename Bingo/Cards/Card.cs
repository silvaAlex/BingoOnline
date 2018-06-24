using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Cards
{
    public class Card
    {
        readonly int CARD_MIN = 1;
        readonly int CARD_MAX = 100;

        public CardBase GetCard()
        {
            List<int> availableNumbers = Enumerable.Range(CARD_MIN, CARD_MAX).ToList();
            CardBase card = new CardBase();

            //looping for 9 columns
            for (var col = 0; col < CARD_COL_COUNT; col++)
            {
                var cardColumn = new CardColumn();

                //looping for 3 rows in each column
                for (var row = 0; row < CARD_ROW_COUNT; row++)
                {
                    var cardRow = new CardEmpty();

                    //getting a random number from availableNumbers and removing that number from list to avoid duplicate numbers.
                    int rand = new Random(255);

                    cardRow.Value = availableNumbers[rand];
                    availableNumbers.RemoveAt(rand);

                    //I believe somewhere here I should check if there will be more than 5 numbers in a row, or should randomly generate empty blocks? Can't really figure out...
                    cardColumn.Rows.Add(cardRow);
                }

                card.Columns.Add(cardColumn);
            }

            return card;
        }
    }
    }
}
