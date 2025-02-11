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

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreatePipemap(data);
        Console.WriteLine("___");
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}