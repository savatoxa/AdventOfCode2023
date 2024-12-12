using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner8
{
    List<Tuple<string, string, string>> map = new List<Tuple<string, string, string>>();
    string moves;

    Parser parser = new Parser();

    public void CreateMoves(string data)
    {
        moves =  parser.SplitStrByEmptyLines(data)[0];
    }

    public void CreateMap(string data)
    {
        var mapsStr = parser.SplitStrByLines(parser.SplitStrByEmptyLines(data)[1]);
        foreach (var submap in mapsStr)
            map.Add(Tuple.Create(submap.Substring(0, 3), submap.Substring(7, 3), submap.Substring(12, 3)));
    }

    public string GetNodeByMove(string node, string move)
    {
    foreach (var nodes in map)
        if (nodes.Item1 == node)
        {
            if (move == "R")
                return nodes.Item3;
            if (move == "L")
                return nodes.Item2;
        }
        return "";
    }



    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreateMoves(data);
        CreateMap(data);
        Console.WriteLine(moves);
        map.ForEach(m => Console.WriteLine(m));
        Console.WriteLine("___");
        Console.WriteLine(GetNodeByMove("CCC", "L"));
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}
