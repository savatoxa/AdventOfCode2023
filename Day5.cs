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
        waterToLight = GetMap(parser.SplitStrByLines(dataStrArr[4]));
        lightToTemperature = GetMap(parser.SplitStrByLines(dataStrArr[5]));
        temperatureToHumidity = GetMap(parser.SplitStrByLines(dataStrArr[6]));
        humidityToLocation = GetMap(parser.SplitStrByLines(dataStrArr[7]));

        seeds.ForEach(e => Console.Write(e + " "));
        Console.WriteLine("");
        PrintMap(seedsToSoil);
        PrintMap(soilToFertilizer);
        PrintMap(fertilizerToWater);
        PrintMap(waterToLight);
        PrintMap(lightToTemperature);
        PrintMap(temperatureToHumidity);
        PrintMap(humidityToLocation);
    }
    public Dictionary<int, int> CreateSubmapDict(List<int> submapList)
    {
        Dictionary<int, int> submapDict = new Dictionary<int, int>();
        for (int i = 0; i < submapList[2]; i++)
            submapDict.Add(submapList[1] + i, submapList[0] + i);

        //foreach (var submap in submapDict)
        //    Console.WriteLine(submap);
        //Console.WriteLine("");
        return submapDict;
    }
    public Dictionary<int, int> CreateMappedAllNumsDict(List<int> nums, List<List<int>> map)
    {
        Dictionary<int, int> mappedNumsDict = new Dictionary<int, int>();
        foreach (var num in nums)
            mappedNumsDict.Add(num, num);
        for(var i = 0; i < map.Count; i++)
            foreach (var pair in CreateMappedNumsDict(nums, map[i]))
                mappedNumsDict[pair.Key] = pair.Value;

        Console.WriteLine("___");
        foreach (var kv in mappedNumsDict)
            Console.WriteLine(kv);
        Console.WriteLine("");

        return mappedNumsDict;
    }
    public Dictionary<int, int> CreateMappedNumsDict(List<int> nums, List<int> submap)
    {
        Dictionary<int, int> mappedNumsDict = new Dictionary<int, int>();
        var submap_ = CreateSubmapDict(submap);
        foreach (var num in nums)
        {
            if (submap_.ContainsKey(num))
                mappedNumsDict[num] = submap_[num];
        }
        return mappedNumsDict;
    }
    public void Run(string data)
    {
        GetAlmanac(data);
        var seedsToSoilMapped = CreateMappedAllNumsDict(seeds, seedsToSoil);
        var soilToFertilizerMapped = CreateMappedAllNumsDict(new List<int>(seedsToSoilMapped.Values), soilToFertilizer);

    }
}