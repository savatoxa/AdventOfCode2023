using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner5
{
    List<int> seeds = new List<int>();
    List<List<int>> seedsToSoil = new List<List<int>>();
    List<List<int>> soilToFertilizer = new List<List<int>>();
    List<List<int>> fertilizerToWater = new List<List<int>>();
    List<List<int>> waterToLight = new List<List<int>>();
    List<List<int>> lightToTemperature = new List<List<int>>();
    List<List<int>> temperatureToHumidity = new List<List<int>>();
    List<List<int>> humidityToLocation = new List<List<int>>();
    Parser parser = new Parser();

    public List<List<int>> GetMap(string[] mapStr)
    {
        List<List<int>> mapParsed = new List<List<int>>();
        for (int i = 1; i < mapStr.Length; i++)
        {
            List<int> nums = new List<int>();
            foreach (var num in parser.SplitStrBySpaces(mapStr[i]))
                nums.Add(num);
            mapParsed.Add(nums);
        }
        return mapParsed;
    }
    public void PrintMap(List<List<int>> map)
    {
        foreach (var l in map)
        {
            l.ForEach(e => Console.Write(e + " "));
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }
    public void GetAlmanac(string data)
    {
        var dataStrArr = parser.SplitStrByEmptyLines(data);
        var seedStrArr = parser.SplitStrBySpaces2(dataStrArr[0]);
        for (int i = 1; i < seedStrArr.Length; i++)
            seeds.Add(Int32.Parse(seedStrArr[i]));
        seedsToSoil = GetMap(parser.SplitStrByLines(dataStrArr[1]));
        soilToFertilizer = GetMap(parser.SplitStrByLines(dataStrArr[2]));
        fertilizerToWater = GetMap(parser.SplitStrByLines(dataStrArr[3]));

        seeds.ForEach(e => Console.Write(e + " "));
        Console.WriteLine("");
        PrintMap(seedsToSoil);
        PrintMap(soilToFertilizer);
        PrintMap(fertilizerToWater);
    }

}