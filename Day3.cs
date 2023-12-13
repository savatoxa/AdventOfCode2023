using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner3
{
    Parser parser = new Parser();
    public List<List<char>> GetMatrix(string data)
    {
        return parser.GetCharMatrix(data);
    }
    public int SumPartNumbers(string data)
    {
        var numSymMatrix = GetMatrix(data);
        parser.PrintMatrix(numSymMatrix);
        int sum = 0;

        for (int j = 0; j < numSymMatrix.Count - 1; j++)
            for (int i = 0; i < numSymMatrix[j].Count - 1; i++)
            {
                var numsym = numSymMatrix[j][i];
                if (!char.IsDigit(numsym) && numsym != '.')
                {
                    Console.WriteLine("{0}, {1}, {2}", numsym, i, j);
                }
            }

        return sum;
    }
}