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
    public List<Tuple<int, int, Char>> GetValidCells(Tuple<int, int, Char> inputCell)
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
        {
            var upperCell = Tuple.Create(inputCell.Item1 - 1, inputCell.Item2, pipemap[inputCell.Item1 - 1][inputCell.Item2]);
        }
        if (inputCell.Item1 > 0 && inputCell.Item2 < pipemap[0].Count - 1)
        {
            var upperRightCell = Tuple.Create(inputCell.Item1 - 1, inputCell.Item2 + 1, pipemap[inputCell.Item1 - 1][inputCell.Item2 + 1]);
        }
        if (inputCell.Item2 < pipemap[0].Count - 1)
        {
            var rightCell = Tuple.Create(inputCell.Item1, inputCell.Item2 + 1, pipemap[inputCell.Item1][inputCell.Item2 + 1]);
        }
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 < pipemap[0].Count - 1)
        {
            var lowerRightCell = Tuple.Create(inputCell.Item1+1, inputCell.Item2+1, pipemap[inputCell.Item1 + 1][inputCell.Item2 + 1]);
        }
        if (inputCell.Item1 < pipemap.Count - 1)
        {
            var lowerCell = Tuple.Create(inputCell.Item1+1, inputCell.Item2, pipemap[inputCell.Item1 + 1][inputCell.Item2]);
        }
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 > 0)
        {
            var lowerLeftCell = Tuple.Create(inputCell.Item1+1, inputCell.Item2-1, pipemap[inputCell.Item1 + 1][inputCell.Item2 - 1]);
        }
        if (inputCell.Item2 > 0)
        {
            var leftCell = Tuple.Create(inputCell.Item1, inputCell.Item2-1, pipemap[inputCell.Item1][inputCell.Item2 - 1]);
        }
        if (inputCell.Item1 > 0 && inputCell.Item2 > 0)
        {
            var upperLeftCell = Tuple.Create(inputCell.Item1-1, inputCell.Item2-1, pipemap[inputCell.Item1 - 1][inputCell.Item2 - 1]);
        }


        var inputcellChar = pipemap[inputCell.Item1][inputCell.Item2];
        Console.WriteLine(inputСell);
        Console.WriteLine(upperCell);
        Console.WriteLine(upperRightCellChar);
        Console.WriteLine(rightCellChar);
        Console.WriteLine(lowerRightCellChar);
        Console.WriteLine(lowerCellChar);
        Console.WriteLine(lowerLeftCellChar);
        Console.WriteLine(leftCellChar);
        Console.WriteLine(upperLeftCellchar);
        var outputcells = new List<Tuple<int, int, Char>>();
        return outputcells;
    }
    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreatePipemap(data);
        parser.PrintMatrix(pipemap);
        Console.WriteLine("___");
        GetValidCells(Tuple.Create(0,0, ' '));
        //GetValidCells(GetStart());
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}