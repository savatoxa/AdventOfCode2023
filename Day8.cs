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

    public Tuple<string, string, string> GetNodesByString(string input)
    {
        foreach (var node in map)
            if (node.Item1 == input)
                return node;
        return Tuple.Create("", "", "");
    }

    public string GetNodeByMove(string input)
    {
        if (input == "ZZZ")
            return "ZZZ";
        else
        {
            foreach (var move in moves)
            {
                if (move == 'L')
                    input = GetNodesByString(input).Item2;
                else if (move == 'R')
                    input = GetNodesByString(input).Item3;
            }
            GetNodeByMove(input);
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
        //Console.WriteLine(GetNodeByString("CCC"));
        Console.WriteLine(GetNodeByMove("AAA"));
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}
