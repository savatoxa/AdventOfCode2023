using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner5
{
    List<int> seeds = new List<int>();
    Parser parser = new Parser();
    public void GetSeeds(string data)
    {
     var seedStrArr =  parser.SplitStrBySpaces2(parser.SplitStrByEmptyLines(data)[0]);
        foreach (var str_ in seedStrArr)
            Console.WriteLine(str_);
    }
}