using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner4
{
    Parser parser = new Parser();
    public List<Tuple<List<int>, List<int>>> GetAllCards(string data)
    {
        return parser.GetAllCards(data);
    }
    public int IntPow(int x, int n)
    {
        if (n == 0)
            return 1;
        else
            return x * IntPow(x, n-1);
    }
    public int AllCardsPoints(string data)
    {
        var allcards = GetAllCards(data);
        int allpoints = 0;

        foreach (var card in allcards)
        {
            //card.Item1.ForEach(n => Console.Write(n.ToString() + ","));
            //Console.Write("|");
            //card.Item2.ForEach(n => Console.Write(n.ToString() + ","));
            //Console.WriteLine("");

            int cardpoints = 0;
            int cardmatches = 0;
            foreach (var num in card.Item2)
            {
                if (card.Item1.Contains(num))
                    cardmatches ++;
                {
                    if (cardmatches == 0)
                        cardpoints = 0;
                    else
                        cardpoints = IntPow(2, cardmatches - 1);
                }
            }
            allpoints += cardpoints;
            //Console.WriteLine("matches: " + cardmatches.ToString());
        }

        return allpoints;
    }
}