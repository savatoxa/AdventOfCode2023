using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner3
{
    Parser parser = new Parser();
    List<List<char>> numSymMatrix = new List<List<char>>();

    public List<List<char>> GetMatrix(string data)
    {
        return parser.GetCharMatrix(data);
    }
    public List<Tuple<int, int>> Radar(int x, int y)
    {
        List<Tuple<int, int>> adjacent = new List<Tuple<int, int>>();
        if (char.IsDigit(numSymMatrix[x + 1][y]))
            adjacent.Add(Tuple.Create(x + 1, y));
        if (char.IsDigit(numSymMatrix[x + 1][y - 1]))
            adjacent.Add(Tuple.Create(x + 1, y - 1));
        if (char.IsDigit(numSymMatrix[x][y - 1]))
            adjacent.Add(Tuple.Create(x, y - 1));
        if (char.IsDigit(numSymMatrix[x - 1][y - 1]))
            adjacent.Add(Tuple.Create(x - 1, y - 1));
        if (char.IsDigit(numSymMatrix[x - 1][y]))
            adjacent.Add(Tuple.Create(x - 1, y));
        if (char.IsDigit(numSymMatrix[x - 1][y + 1]))
            adjacent.Add(Tuple.Create(x - 1, y + 1));
        if (char.IsDigit(numSymMatrix[x][y + 1]))
            adjacent.Add(Tuple.Create(x, y + 1));
        if (char.IsDigit(numSymMatrix[x + 1][y + 1]))
            adjacent.Add(Tuple.Create(x + 1, y + 1));
        return adjacent;
    }
    public int SumPartNumbers(string data)
    {
        numSymMatrix = GetMatrix(data);
        List<Tuple<int, int>> symbolscoords = new List<Tuple<int, int>>();
        parser.PrintMatrix(numSymMatrix);
        int sum = 0;

        for (int j = 0; j < numSymMatrix.Count - 1; j++)
            for (int i = 0; i < numSymMatrix[j].Count - 1; i++)
                if (!char.IsDigit(numSymMatrix[j][i]) && numSymMatrix[j][i] != '.')
                    symbolscoords.Add(Tuple.Create(i,j));

        foreach (var coord in symbolscoords)
        {
            Console.WriteLine(coord);
            Console.WriteLine(numSymMatrix[coord.Item2][coord.Item1]);
        }
        Console.WriteLine("___");
        var adj = Radar(symbolscoords[0].Item2, symbolscoords[0].Item1);
        foreach (var p in adj)
        {
            Console.WriteLine(p);
            Console.WriteLine(numSymMatrix[p.Item1][p.Item2]);
        }

        return sum;
    }
}