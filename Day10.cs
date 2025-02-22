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
    }
    public Tuple<int, int> GetStart ()
    {
        for (var i = 0; i < pipemap.Count; i++)
            for (var j = 0; j < pipemap[0].Count; j++)
                if (pipemap[i][j] == 'S')
                    return Tuple.Create(i, j);
        return Tuple.Create(-1, -1);
    }
    public List<Tuple<int, int>> GetValidCells(Tuple<int, int> inputCell)
    {
        var upperCellChar = ',';
        var upperRightCellChar = ',';
        var rightCellChar = ',';
        var lowerRightCellChar = ',';
        var lowerCellChar = ',';
        var lowerLeftCellChar = ',';
        var leftCellChar = ',';
        var upperLeftCellchar = ',';

        if (inputCell.Item1 > 0)
            upperCellChar = pipemap[inputCell.Item1 - 1][inputCell.Item2];
        if (inputCell.Item1 > 0 && inputCell.Item2 < pipemap[0].Count - 1)
            upperRightCellChar = pipemap[inputCell.Item1 - 1][inputCell.Item2 + 1];
        if (inputCell.Item2 < pipemap[0].Count - 1)
            rightCellChar = pipemap[inputCell.Item1][inputCell.Item2 + 1];
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 < pipemap[0].Count - 1)
            lowerRightCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2 + 1];
        if (inputCell.Item1 < pipemap.Count - 1)
            lowerCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2];
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 > 0)
            lowerLeftCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2 - 1];
        if (inputCell.Item2 > 0)
            leftCellChar = pipemap[inputCell.Item1][inputCell.Item2 - 1];
        if (inputCell.Item1 > 0 && inputCell.Item2 > 0)
            upperLeftCellchar = pipemap[inputCell.Item1 - 1][inputCell.Item2 - 1];


        var inputcellChar = pipemap[inputCell.Item1][inputCell.Item2];
        Console.WriteLine(inputcellChar);
        Console.WriteLine(upperCellChar);
        Console.WriteLine(upperRightCellChar);
        Console.WriteLine(rightCellChar);
        Console.WriteLine(lowerRightCellChar);
        Console.WriteLine(lowerCellChar);
        Console.WriteLine(lowerLeftCellChar);
        Console.WriteLine(leftCellChar);
        Console.WriteLine(upperLeftCellchar);
        var outputcells = new List<Tuple<int, int>>();
        return outputcells;
    }
    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreatePipemap(data);
        parser.PrintMatrix(pipemap);
        Console.WriteLine("___");
        GetValidCells(Tuple.Create(0,0));
        //GetValidCells(GetStart());
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}