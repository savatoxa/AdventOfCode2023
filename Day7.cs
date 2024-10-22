using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner7
{
    List<Tuple<string, int, int>> cards = new List<Tuple<string, int, int>>();
    Dictionary<char, int> cardsAlphabet = new Dictionary<char, int> { {'A', 0}, {'K', 1}, {'Q', 2}, {'J', 3}, {'T', 4}, {'9', 5}, {'8', 6}, {'7', 7},
        {'6', 8}, {'5', 9}, {'4', 10}, {'3', 11}, {'2', 12} };
    public string SortByAlphabet(string card)
    {
        char[] sortedChars = card.OrderBy(c => cardsAlphabet[c]).ToArray();
        return new string(sortedChars);
    }
    public int CompareStrings(string card1, string card2)
    {
        for(var i = 0; i < card1.Length; i++)
        {
            if (cardsAlphabet[card1[i]] > cardsAlphabet[card2[i]])
                return 2;
            else if (cardsAlphabet[card1[i]] < cardsAlphabet[card2[i]])
                return 1;
        }
        return 0;
    }
    public void SortTuplesListByItem3(List<Tuple<string, int, int>> cardslist)
    {
        cardslist.Sort((x, y) => y.Item3.CompareTo(x.Item3));
    }
    public List<Tuple<string, int, int>> SwapTwoInCardslist(List<Tuple<string, int, int>> cardslist, int idx1, int idx2)
    {
        var elemtmp = cardslist[idx1];
        cardslist[idx1] = cardslist[idx2];
        cardslist[idx2] = elemtmp;
        return cardslist;
    }
    public List<Tuple<string, int, int>> BubbleSortStrings(List<Tuple<string, int, int>> cardslist)
    {
        for (int i = 0; i < cardslist.Count - 1; i++)
        {
            for (int j = 0; j < cardslist.Count - i - 1; j++)
            {
                if (CompareStrings(cardslist[j].Item1, cardslist[j + 1].Item1) == 1)
                    SwapTwoInCardslist(cardslist, j, j + 1);
            }
        }
        return cardslist;
    }
    public void GetCards(string data)
    {
        Parser parser = new Parser();
        var cardsStr = parser.CreateListOfRoundsStr(data);
        foreach(var cardStr in cardsStr)
            cards.Add(Tuple.Create(cardStr.Item1, Int32.Parse(cardStr.Item2), GetCardStrength(cardStr.Item1)));
        SortTuplesListByItem3(cards);
    }
    public List<Tuple<string, int, int>> GetSublist(int start, int end)
    {
        List<Tuple<string, int, int>> sublist = new List<Tuple<string, int, int>>();
        for (int i = start; i <= end; i++)
            sublist.Add(cards[i]);
        return sublist;
    }
    public List<Tuple<int, int>> GetIndexes()
    {
        List<Tuple<int, int>> indexes = new List<Tuple<int, int>>();
        int c = 0;
        for(var i = 0; i < cards.Count - 1; i++)
        {
            c++;
            if (cards[i].Item3 != cards[i + 1].Item3)
            {
                indexes.Add(Tuple.Create(i + 1 - c, i));
                c = 0;
            }
        }
        for(var i = cards.Count - 1; i >= 0; i--)
        {
            if (cards[i].Item3 != cards[i - 1].Item3)
            {
                indexes.Add(Tuple.Create(i, cards.Count - 1));
                break;
            }
        }
        return indexes;
    }
    public List<Tuple<string, int, int>> SortSublists(List<Tuple<int, int>> indexes)
    {
        List<Tuple<string, int, int>> sortedList = new List<Tuple<string, int, int>>();
        foreach(var index in indexes)
        {
            var sublist = BubbleSortStrings(GetSublist(index.Item1, index.Item2));
            sortedList.AddRange(sublist);
        }
        return sortedList;
    }
    public int TotalWins()
    {
        var cardslist = SortSublists(GetIndexes());
        var totalwins = 0;
        for (var i = 0; i < cardslist.Count; i++)
            totalwins += (i + 1) * cardslist[i].Item2;
        return totalwins;
    }
    public int GetCardStrength(string card)
    {   if (FindFiveOfAKind(card))
            return 1;
        if (FourOfAKind(card))
            return 2;
        if (FullHouse(card))
            return 3;
        if (ThreeOfAKind(card))
            return 4;
        if (TwoPair(card))
            return 5;
        if (OnePair(card))
            return 6;
        if (HighCard(card))
            return 7;
        return 0;
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
        cards.ForEach(c => Console.WriteLine(c));
        Console.WriteLine("___");
        //GetIndexes().ForEach(c => Console.WriteLine(c));
        //SortSublists(GetIndexes()).ForEach(c => Console.WriteLine(c));
        //Console.WriteLine(TotalWins());
        cards.ForEach(c => Console.WriteLine(SortByAlphabet(c.Item1)));
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}