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
        moves = parser.SplitStrByEmptyLines(data)[0];
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
            outputnodes.Add(GetNodeByMove(node, move));
        return outputnodes;
    }
    public bool IsListZ(List<string> inputlist)
    {
        foreach (var node in inputlist)
            if (node[2] != 'Z')
                return false;
        return true;
    }
    public Tuple<List<string>, int> GetListOfNodesByAllMoves(List<string> inputlist, int count)
    {
        foreach (var move in moves)
        {
            inputlist = GetListOfNodesByMove(inputlist, move);
            count++;
        }
        if (IsListZ(inputlist))
            return Tuple.Create(inputlist, count);
        else
            return GetListOfNodesByAllMoves(inputlist, count);
    }
    public Tuple<string, int> GetNodeByAllMoves(string inputnode, int count)
    {
        foreach (var move in moves)
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
        foreach (var node in map)
        {
            if (node.Item1[2] == 'A')
                nodesC.Add(node.Item1);
        }
        return nodesC;
    }
    public int GCD(int m, int n)
    {
        while(m != n)
        {
            if (m > n)
                m = m - n;
            else
                n = n - m;
        }
        return n;
    }
    public int GCDMyltiplyN(List<int> numlist)
    {
        int gcd = GCD(numlist[0], numlist[1]);
        for (var i = 2; i < numlist.Count; i++)
            gcd = GCD(gcd, numlist[i]);
        return gcd;
    }
    public long LCMMyltiplyN()
    {
        List<int> allSeq = new List<int>();
        foreach (var node in nodesA)
            allSeq.Add(GetNodeByAllMoves(node, 0).Item2);
        long gcdAllSeq = GCDMyltiplyN(allSeq);
        long lcmAllseq = (allSeq[0] * allSeq[1]) / gcdAllSeq;
        for (var i = 2; i < allSeq.Count; i++)
            lcmAllseq = (lcmAllseq * allSeq[i]) / gcdAllSeq;
        return lcmAllseq;
    }
    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreateMoves(data);
        CreateMap(data);
        nodesA = GetNodesA();
        Console.WriteLine("___");
        foreach (var node in nodesA)
            Console.WriteLine(GetNodeByAllMoves(node, 0));
        Console.WriteLine("___");
        Console.WriteLine(LCMMyltiplyN());
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}