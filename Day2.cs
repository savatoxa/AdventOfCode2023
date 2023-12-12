using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner2
{
    Parser parser = new Parser();
    public List<List<List<Tuple<int, string>>>> GetAllGames(string data)
    {
        return parser.GetAllGames(data);
    }
    public int GetValidGames(string data)
    {
        var allGames = GetAllGames(data);
        int sumgames = 0;
        for (var i = 0; i < allGames.Count; i++)
        {
            int maxred = 0;
            int maxgreen = 0;
            int maxblue = 0;
            int multcol = 0;
            foreach (var set in allGames[i])
            {
                foreach (var draw in set)
                {
                    if (draw.Item2 == "red" && draw.Item1 > maxred)
                        maxred = draw.Item1;
                    if (draw.Item2 == "green" && draw.Item1 > maxgreen)
                        maxgreen = draw.Item1; ;
                    if (draw.Item2 == "blue" && draw.Item1 > maxblue)
                        maxblue = draw.Item1;
                }
                multcol = maxred * maxgreen * maxblue;
            }
            sumgames += multcol;
        }
    return sumgames;
    }
}