using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner5
{
    List<int> seeds = new List<int>();
    List<List<int>> seedsToSoil = new List<List<int>>();
    Parser parser = new Parser();
    public void GetSeeds(string data)
    {
        var dataStrArr = parser.SplitStrByEmptyLines(data);
        var seedStrArr = parser.SplitStrBySpaces2(dataStrArr[0]);
        var seedsToSoilStrArr = parser.SplitStrByLines(dataStrArr[1]);
        for (int i = 1; i < seedStrArr.Length; i++)
            seeds.Add(Int32.Parse(seedStrArr[i]));
        seeds.ForEach(e => Console.Write(e + " "));
        Console.WriteLine("");
        //for (int i = 1; i < seedsToSoilStrArr.Length; i++)

    }
}