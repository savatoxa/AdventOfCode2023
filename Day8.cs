using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner8
{
    List<Tuple<string, string, string>> map = new List<Tuple<string, string, string>>();
    List<string> nodesA = new List<string>();
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

    public string GetNodeByMove(string node, char move)
    {
    foreach (var nodes in map)
        if (nodes.Item1 == node)
        {
            if (move == 'R')
                return nodes.Item3;
            if (move == 'L')
                return nodes.Item2;
        }
        return "";
    }

    public List<string> GetListOfNodesByMove(List<string> inputnodes, char move)
    {
        List<string> outputnodes = new List<string>();
        foreach (var node in inputnodes)
        {

        }
        return outputnodes;
    }

    public Tuple<string, int> GetNodeByAllMoves(string inputnode, int count)
    {
        foreach(var move in moves)
        {
            inputnode = GetNodeByMove(inputnode, move);
            count++;
        }
        if (inputnode[2] == 'Z')
            return Tuple.Create(inputnode, count);
        else
            return GetNodeByAllMoves(inputnode, count);
    }

    public List<string> GetNodesA()
    {
        List<string> nodesC = new List<string>();
        foreach(var node in map)
        {
            if (node.Item1[2] == 'A')
                nodesC.Add(node.Item1);
        }
        return nodesC;
    }

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreateMoves(data);
        CreateMap(data);
        nodesA = GetNodesA();
        Console.WriteLine(moves);
        map.ForEach(m => Console.WriteLine(m));
        Console.WriteLine("___");
        //Console.WriteLine(GetNodeByAllMoves("22A", 0));
        nodesA.ForEach(n => Console.WriteLine(n));
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}
