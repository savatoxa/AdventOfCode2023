using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner10
{
    Parser parser = new Parser();
    List<List<char>> pipemap = new List<List<char>>();

    public void CreatePipemap(string data)
    {
        pipemap = parser.GetCharMatrix(data);
        parser.PrintMatrix(pipemap);
    }
    public Tuple<int, int> GetStart ()
    {
        for (var i = 0; i < pipemap.Count; i++)
            for (var j = 0; j < pipemap[0].Count; j++)
                if (pipemap[i][j] == 'S')
                    return Tuple.Create(i, j);
        return Tuple.Create(-1, -1);
    }

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreatePipemap(data);
        Console.WriteLine(GetStart());
        Console.WriteLine("___");
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}