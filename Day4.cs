using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner4
{
    Parser parser = new Parser();
    public List<Tuple<List<int>, List<int>>> allcards = new List<Tuple<List<int>, List<int>>>();
    public Dictionary<int, int> cardscopies = new Dictionary<int, int>();
    public void GetAllCards(string data)
    {
        allcards = parser.GetAllCards(data);
        for (var i = 0; i < allcards.Count; i++)
            cardscopies[i] = 1;
    }
    public int IntPow(int x, int n)
    {
        if (n == 0)
            return 1;
        else
            return x * IntPow(x, n-1);
    }
    public List<int> GetNextCards(int cardnum)
    {
        List<int> nextCards = new List<int>();
        int cardmatches = 0;
        foreach (var num in allcards[cardnum].Item2)
            if (allcards[cardnum].Item1.Contains(num))
                cardmatches++;
        Console.WriteLine("cardnum: " + cardnum.ToString());
        Console.WriteLine("cardmatches: " + cardmatches.ToString());
        for (var i = 1; i <= cardmatches; i++)
        {
            nextCards.Add(cardnum + i);
        }
        return nextCards;
    }
    public int AllCardsNum(string data)
    {
        GetAllCards(data);
        int totalcards = allcards.Count;

        for (var i = 0; i < allcards.Count; i++)
        {
            //card.Item1.ForEach(n => Console.Write(n.ToString() + ","));
            //Console.Write("|");
            //card.Item2.ForEach(n => Console.Write(n.ToString() + ","));
            //Console.WriteLine("");
            var nextcards = GetNextCards(i);
            Console.Write("nextcards: ");
            nextcards.ForEach(t => Console.Write(t));
            Console.WriteLine("");
            //for (var j = 0; j < nextcards.Count; j++)
            //{
            //    GetNextCards(j);
            //}
            Console.WriteLine("");
            foreach (var j in nextcards)
                cardscopies[j]++;
        }
        foreach (var card in cardscopies)
            Console.WriteLine(card);
        for (var i = 0; i < cardscopies.Count; i++)
            totalcards += cardscopies[i];
        Console.WriteLine("__");
        return totalcards;
    }
}