using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner2
{
    Parser parser = new Parser();
    int maxred = 12;
    int maxgreen = 13;
    int maxblue = 14;
    public List<List<List<Tuple<int, string>>>> GetAllGames(string data)
    {
        return parser.GetAllGames(data);
    }
    public int GetValidGames(string data)
    {
        var allGames = GetAllGames(data);
        int sumgames = 1;
        bool gametrue = true;
        foreach (var game in allGames)
        {
            foreach (var set in game)
                set.ForEach(t => Console.WriteLine(t));
        }
        for (var i = 0; i < allGames.Count; i++)
        {
            foreach (var set in allGames[i])
            {
                foreach (var draw in set)
                {
                    if (draw.Item2 == "red" && draw.Item1 > maxred)
                        gametrue = false;
                    if (draw.Item2 == "green" && draw.Item1 > maxgreen)
                        gametrue = false;
                    if (draw.Item2 == "blue" && draw.Item1 > maxblue)
                        gametrue = false;
                }
                if (gametrue)
                    sumgames += i;
            }
        }
    return sumgames;
    }
}