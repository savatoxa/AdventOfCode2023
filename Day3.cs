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
    public int PartNumbers(string data)
    {
        var numSymMatrix = GetMatrix(data);
        parser.PrintMatrix(numSymMatrix);
        int sum = 0;
        return sum;
    }
}