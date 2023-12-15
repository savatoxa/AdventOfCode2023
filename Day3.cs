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
    public int GetNumber(Tuple<int,int> coordinate)
    {
        return 0;
    }
    public int SumPartNumbers(string data)
    {
        matrix = GetMatrix(data);
        List<Tuple<int, int>> symbolscoords = new List<Tuple<int, int>>();
        parser.PrintMatrix(matrix);
        int sum = 0;

        for (int row = 0; row < matrix.Count - 1; row++)
            for (int col = 0; col < matrix[row].Count - 1; col++)
                if (!char.IsDigit(matrix[row][col]) && matrix[row][col] != '.')
                    symbolscoords.Add(Tuple.Create(row,col));

        Console.WriteLine("___");
        foreach (var coord in symbolscoords)
        {
            Console.WriteLine("---");
            Console.WriteLine("{0}, {1}", matrix[coord.Item1][coord.Item2], coord);
            var adj = Radar(coord.Item1, coord.Item2);
            foreach (var p in adj)
                Console.WriteLine("{0}, {1}", matrix[p.Item1][p.Item2], p);
        }

        return sum;
    }
}