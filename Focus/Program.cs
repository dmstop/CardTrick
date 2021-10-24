using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Focus
{
    class Program
    {
        private static readonly string[] CardValues = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly string[] CardMasts = { "♦", "♥", "♣", "♠" };

        private static readonly Random Random = new Random();

        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            
            while (true)
            {
                List<Card> fullDeck = (from cardValue in CardValues
                    from cardMast in CardMasts
                    select new Card
                    {
                        Mast = cardMast, Value = cardValue
                    }).ToList();

                List<Card> deck = new List<Card>();

                for (int i = 0; i < 21; i++)
                {
                    Card card = fullDeck[Random.Next(0, fullDeck.Count)];
                    deck.Add(card);
                    fullDeck.Remove(card);
                }

                Console.WriteLine("Запомни любую карту и нажми Enter: ");
                foreach (Card card in deck)
                {
                    Console.Write($"{card.Value}{card.Mast} ");
                }

                Console.ReadLine();

                for (int i = 0; i < 3; i++)
                {
                    List<Card> firstDeck = new List<Card>();
                    List<Card> secondDeck = new List<Card>();
                    List<Card> thirdDeck = new List<Card>();

                    for (int j = 0; j < 21; j += 3)
                    {
                        firstDeck.Add(deck[j]);
                        secondDeck.Add(deck[j + 1]);
                        thirdDeck.Add(deck[j + 2]);
                    }

                    Console.WriteLine("\n\nЗдесь есть ваша карта? (y or n)");
                    foreach (Card card in firstDeck)
                    {
                        Console.Write($"{card.Value}{card.Mast} ");
                    }

                    Console.WriteLine();
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        deck = secondDeck;
                        deck.AddRange(firstDeck);
                        deck.AddRange(thirdDeck);
                        continue;
                    }


                    Console.WriteLine("\n\nЗдесь есть ваша карта? (y or n)");
                    foreach (Card card in secondDeck)
                    {
                        Console.Write($"{card.Value}{card.Mast} ");
                    }

                    Console.WriteLine();
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        deck = firstDeck;
                        deck.AddRange(secondDeck);
                        deck.AddRange(thirdDeck);
                        continue;
                    }

                    deck = firstDeck;
                    deck.AddRange(thirdDeck);
                    deck.AddRange(secondDeck);
                }

                Console.WriteLine("\nВаша карта: " + deck[10].Value + deck[10].Mast);
                Console.ReadLine();
            }
        }
    }
}
