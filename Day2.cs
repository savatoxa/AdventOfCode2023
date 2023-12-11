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
        int sumgames = 0;
        //foreach (var game in allGames)
        //{
        //    foreach (var set in game)
        //        set.ForEach(t => Console.WriteLine(t));
        //}
        for (var i = 0; i < allGames.Count; i++)
        {
            bool gametrue = true;
            Console.WriteLine("___");
            Console.WriteLine(i);
            foreach (var set in allGames[i])
            {
                Console.WriteLine("---");
                foreach (var draw in set)
                {
                    Console.WriteLine(draw);
                    if (draw.Item2 == "red")
                    {
                        Console.WriteLine(draw.Item2);
                        if (draw.Item1 > maxred)
                        {
                            Console.WriteLine(draw.Item1);
                            gametrue = false;
                            Console.WriteLine(gametrue);
                        }
                    }
                    if (draw.Item2 == "green")
                    {
                        Console.WriteLine(draw.Item2);
                        if (draw.Item1 > maxgreen)
                        {
                            Console.WriteLine(draw.Item1);
                            gametrue = false;
                            Console.WriteLine(gametrue);
                        }
                    }
                    if (draw.Item2 == "blue")
                    {
                        Console.WriteLine(draw.Item2);
                        if (draw.Item1 > maxblue)
                        {
                            Console.WriteLine(draw.Item1);
                            gametrue = false;
                            Console.WriteLine(gametrue);
                        }
                    }
                }
            }
            if (gametrue)
            {
                sumgames += i+1;
                Console.WriteLine("{0}, {1}, {2}", gametrue.ToString(), sumgames.ToString(), i.ToString());
            }
        }
        Console.WriteLine("res:");
    return sumgames;
    }
}