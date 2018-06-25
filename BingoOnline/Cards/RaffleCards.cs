using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoOnline.Models;
using BingoOnline.Utils;
using Microsoft.Ajax.Utilities;

namespace BingoOnline.Cards
{
    public class RaffleCards
    {
        DataContext dbContext = new DataContext();
        List<int> raffleNumbers = new List<int>();
        readonly Dictionary<int, List<int>> cardHitDictionary = new Dictionary<int, List<int>>();


        public int CheckCardHits(Card card)
        {
            Action toRepeat = () =>
            {
                card.CardHits = AddCardHit(card);
                Save(card, card.CardHits);
            };

            var query = (from c in GetAll()
                         where c.CardID == card.CardID && c.CardHits <= 15
                         select c.CardHits).FirstOrDefault();

            Enumerable.Repeat(toRepeat, 15);

            return AddCardHit(card);
        }

        int AddCardHit(Card card)
        {
            List<int> raffleCardNumber = Enumerable.Range(1, 15).Select(x => x = Randomizer.Random()).ToList();

            foreach (int raffleNumber in raffleCardNumber)
            {
                bool isRaffleCard = CheckCardNumber(card).Contains(raffleNumber);

                if (isRaffleCard)
                {
                    raffleNumbers.Add(raffleNumber);
                    cardHitDictionary[card.CardID] = raffleNumbers;
                }
            }

            return raffleNumbers.Count;
        }

        List<int> CheckCardNumber(Card card)
        {
            var result = card.CardValues.Split(',').Select(Int32.Parse);

            List<int> cards = new List<int>();

            foreach (var item in result)
            {
                cards.Add(item);
            }

            return cards;
        }

        void Save(Card card, int cardHits)
        {
            card.CardHits = cardHits;
            dbContext.SaveChanges();
        }

        List<Card> GetAll()
        {
            return dbContext.Cards.ToList();
        }
    }
}