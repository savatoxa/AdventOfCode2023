using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner3
{
    Parser parser = new Parser();
    List<List<char>> matrix = new List<List<char>>();

    public List<List<char>> GetMatrix(string data)
    {
        return parser.GetCharMatrix(data);
    }
    public List<Tuple<int, int>> Radar(int row, int col)
    {
        List<Tuple<int, int>> adjacent = new List<Tuple<int, int>>();
        if (char.IsDigit(matrix[row][col+1]))
            adjacent.Add(Tuple.Create(row, col+1));
        if (char.IsDigit(matrix[row-1][col+1]))
            adjacent.Add(Tuple.Create(row-1, col+1));
        if (char.IsDigit(matrix[row-1][col]))
            adjacent.Add(Tuple.Create(row-1, col));
        if (char.IsDigit(matrix[row-1][col-1]))
            adjacent.Add(Tuple.Create(row-1, col-1));
        if (char.IsDigit(matrix[row][col-1]))
            adjacent.Add(Tuple.Create(row, col-1));
        if (char.IsDigit(matrix[row+1][col-1]))
            adjacent.Add(Tuple.Create(row+1, col-1));
        if (char.IsDigit(matrix[row+1][col]))
            adjacent.Add(Tuple.Create(row+1, col));
        if (char.IsDigit(matrix[row+1][col+1]))
            adjacent.Add(Tuple.Create(row+1, col+1));
        return adjacent;
    }
    public int GetNumber(Tuple<int,int> coord)
    {
        List<char> numstr = new List<char>();
        var startidx = coord.Item2;
        while (startidx >= 0 && char.IsDigit(matrix[coord.Item1][startidx]))
            startidx--;
        startidx++;
        for (var idx = startidx; idx < matrix[coord.Item1].Count; idx++)
        {
            if (char.IsDigit(matrix[coord.Item1][idx]))
                numstr.Add(matrix[coord.Item1][idx]);
            else
                break;
        }
        var num = Int32.Parse(string.Concat(numstr));
        return num;
    }
    public int SumPartNumbers(string data)
    {
        matrix = GetMatrix(data);
        List<Tuple<int, int>> symbolscoords = new List<Tuple<int, int>>();
        int sum = 0;

        for (int row = 0; row < matrix.Count - 1; row++)
            for (int col = 0; col < matrix[row].Count - 1; col++)
                if (matrix[row][col] == '*')
                    symbolscoords.Add(Tuple.Create(row,col));

        foreach (var coord in symbolscoords)
        {
            int gr = 1;
            HashSet<int> adjnums = new HashSet<int>();
            foreach (var p in Radar(coord.Item1, coord.Item2))
                adjnums.Add(GetNumber(p));
            if (adjnums.Count == 2)
            {
                foreach (var n in adjnums)
                    gr *= n;
                sum += gr;
            }
        }

        return sum;
    }
}