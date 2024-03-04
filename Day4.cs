using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner4
{
    Parser parser = new Parser();
    public List<Tuple<List<int>, List<int>>> allcards = new List<Tuple<List<int>, List<int>>>();
    public List<int> cardscopies = new List<int>();
    public void GetAllCards(string data)
    {
        allcards = parser.GetAllCards(data);
        for (var i = 0; i < allcards.Count; i++)
            cardscopies.Add(1);
    }
    public int IntPow(int x, int n)
    {
        if (n == 0)
            return 1;
        else
            return x * IntPow(x, n-1);
    }
    public int GetNextCards(int cardnum)
    {
        List<int> nextCards = new List<int>();
        int cardmatches = 0;
        foreach (var num in allcards[cardnum].Item2)
            if (allcards[cardnum].Item1.Contains(num))
                cardmatches++;
        return cardmatches;
    }
    public int AllCardsNum(string data)
    {
        GetAllCards(data);
        int totalcards = 0;

        for (var i = 0; i < allcards.Count; i++)
        {
            var nextcards = GetNextCards(i);
            for (var j = 0; j < nextcards; j++)
            {
                cardscopies[i + 1 + j] += cardscopies[i];
            }
        }
        for (var i = 0; i < cardscopies.Count; i++)
            totalcards += cardscopies[i];
        return totalcards;
    }
}