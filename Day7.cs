using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner7
{
    List<Tuple<string, int>> cards = new List<Tuple<string, int>>();
    Dictionary<char, int> cardStrength = new Dictionary<char, int> { {'A', 0}, {'K', 1}, {'Q', 2}, {'J', 3}, {'T', 4}, {'9', 5}, {'8', 6}, {'7', 7},
        {'6', 8}, {'5', 9}, {'4', 10}, {'3', 11}, {'2', 12} };
    public string SortByAlphabet(string card)
    {
        char[] sortedChars = card.OrderBy(c => cardStrength[c]).ToArray();
        return new string(sortedChars);
    }
    public void GetCards(string data)
    {
        Parser parser = new Parser();
        var cardsStr = parser.CreateListOfRoundsStr(data);
        foreach(var cardStr in cardsStr)
            cards.Add(Tuple.Create(cardStr.Item1, Int32.Parse(cardStr.Item2)));
        cards.ForEach(c => Console.WriteLine(c));
    }
    public int NumberOfOccurrences (char symbol, string word)
    {
        int count = 0;
        foreach (var s in word)
        {
            if (symbol == s)
                count++;
        }
        return count;
    }
    public List<char> ListOfOtherChars(char symbol, string card)
    {
        List<char> otherChars = new List<char>();
        foreach(var s in card)
        {
            if (symbol != s)
                otherChars.Add(s);
        }
        return otherChars;
    }
    public bool FourOfAKind (string card)
    {
        foreach(var s in card)
        {
            if (NumberOfOccurrences(s, card) == 4)
                return true;
        }
        return false;
    }
    public bool FullHouse(string card)
    {
        foreach(var s in card)
            if (NumberOfOccurrences(s, card) == 3)
            {
                var otherChars = ListOfOtherChars(s, card);
                if (otherChars[0] == otherChars[1])
                    return true;
            }
        return false;
    }
    public bool ThreeOfAKind(string card)
    {
        foreach (var s in card)
            if (NumberOfOccurrences(s, card) == 3)
            {
                var otherChars = ListOfOtherChars(s, card);
                if (otherChars[0] != otherChars[1])
                    return true;
            }
        return false;
    }
    public bool FindFiveOfAKind(string card)
    {
        for(int i = 0; i < card.Length - 1; i++)
        {
            if (card[i] != card[i + 1])
                return false;
        }
        return true;
    }
    public bool TwoPair(string card)
    {
        foreach(var s1 in card)
        {
            if(NumberOfOccurrences(s1, card) == 2)
            {
                var otherChars = ListOfOtherChars(s1, card);
                foreach(var s2 in otherChars)
                {
                    if (NumberOfOccurrences(s2, string.Concat(otherChars)) == 2)
                        return true;
                }
            }
        }
        return false;
    }
    public bool HighCard(string card)
    {
        for (int i = 0; i < card.Length - 1; i++)
        {
            if (card[i] == card[i + 1])
                return false;
        }
        return true;
    }
    public bool OnePair(string card)
    {
        foreach(var s in card)
        {
            if (NumberOfOccurrences(s, card) == 2)
            {
                if (HighCard(string.Concat(ListOfOtherChars(s, card))))
                    return true;
                else
                    return false;
            }
        }
        return false;
    }

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        GetCards(data);
        //Console.WriteLine(OnePair("abbdc"));
        cards.ForEach(c => Console.WriteLine(SortByAlphabet(c.Item1)));
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}