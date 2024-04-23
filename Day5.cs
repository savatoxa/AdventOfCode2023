using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner5
{
    List<Int64> seeds = new List<Int64>();
    List<List<Int64>> seedsToSoil = new List<List<Int64>>();
    List<List<Int64>> soilToFertilizer = new List<List<Int64>>();
    List<List<Int64>> fertilizerToWater = new List<List<Int64>>();
    List<List<Int64>> waterToLight = new List<List<Int64>>();
    List<List<Int64>> lightToTemperature = new List<List<Int64>>();
    List<List<Int64>> temperatureToHumidity = new List<List<Int64>>();
    List<List<Int64>> humidityToLocation = new List<List<Int64>>();
    Parser parser = new Parser();

    public List<List<Int64>> GetMap(string[] mapStr)
    {
        List<List<Int64>> mapParsed = new List<List<Int64>>();
        for (int i = 1; i < mapStr.Length; i++)
        {
            List<Int64> nums = new List<Int64>();
            foreach (var num in parser.SplitStrBySpaces(mapStr[i]))
                nums.Add(num);
            mapParsed.Add(nums);
        }
        return mapParsed;
    }
    public void PrintMap(List<List<Int64>> map)
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
            seeds.Add(Int64.Parse(seedStrArr[i]));
        seedsToSoil = GetMap(parser.SplitStrByLines(dataStrArr[1]));
        soilToFertilizer = GetMap(parser.SplitStrByLines(dataStrArr[2]));
        fertilizerToWater = GetMap(parser.SplitStrByLines(dataStrArr[3]));
        waterToLight = GetMap(parser.SplitStrByLines(dataStrArr[4]));
        lightToTemperature = GetMap(parser.SplitStrByLines(dataStrArr[5]));
        temperatureToHumidity = GetMap(parser.SplitStrByLines(dataStrArr[6]));
        humidityToLocation = GetMap(parser.SplitStrByLines(dataStrArr[7]));

        //seeds.ForEach(e => Console.Write(e + " "));
        //Console.WriteLine("");
        //PrintMap(seedsToSoil);
        //PrintMap(soilToFertilizer);
        //PrintMap(fertilizerToWater);
        //PrintMap(waterToLight);
        //PrintMap(lightToTemperature);
        //PrintMap(temperatureToHumidity);
        //PrintMap(humidityToLocation);
    }
    public List<Int64> CreateAllSeeds()
    {
        List<Int64> allseeds = new List<Int64>();
        for (int i = 0; i < seeds.Count - 1; i += 2)
        {
            Console.WriteLine(seeds[i].ToString() + " " + seeds[i+1].ToString());
            for (Int64 j = seeds[i]; j < seeds[i + 1]; j++)
            {
                Console.WriteLine("___");
                Console.Write(j.ToString() + "  ");
            }
        }
        return allseeds;
    }
    public Dictionary<Int64, Int64> CreateSubmap(List<Int64> submapList, List<Int64> nums)
    {
        Dictionary<Int64, Int64> submap = new Dictionary<long, long>();
        foreach (var num in nums)
        {
            long mappednum;
            if (num >= submapList[1] && num < submapList[1] + submapList[2])
            {
                mappednum = (num - submapList[1]) + submapList[0];
                submap.Add(num, mappednum);
            }
        }
        return submap;
    }
    public Dictionary<Int64, Int64> CreateMap(List<Int64> nums, List<List<Int64>> mapList)
    {
        Dictionary<Int64, Int64> map = new Dictionary<Int64, Int64>();
        nums.ForEach(n => map.Add(n, n));
        foreach(var submap in mapList)
            foreach (var pair in CreateSubmap(submap, nums))
                map[pair.Key] = pair.Value;
        return map;
    }
    public void Run(string data)
    {
        GetAlmanac(data);
        //var seedsToSoilMapped = CreateMap(seeds, seedsToSoil);
        //var soilToFertilizerMapped = CreateMap(new List<Int64>(seedsToSoilMapped.Values), soilToFertilizer);
        //var fertilizerToWaterMapped = CreateMap(new List<Int64>(soilToFertilizerMapped.Values), fertilizerToWater);
        //var waterToLightMapped = CreateMap(new List<Int64>(fertilizerToWaterMapped.Values), waterToLight);
        //var lightToTemperatureMapped = CreateMap(new List<Int64>(waterToLightMapped.Values), lightToTemperature);
        //var temperatureToHumidityMapped = CreateMap(new List<Int64>(lightToTemperatureMapped.Values), temperatureToHumidity);
        //var humidityToLocationMapped = CreateMap(new List<Int64>(temperatureToHumidityMapped.Values), humidityToLocation);
        //var ordered = humidityToLocationMapped.OrderBy(x => x.Value);
        //Console.WriteLine(ordered.ToList()[0]);
        CreateAllSeeds();
        //foreach (var kv in ordered)
        //    Console.WriteLine(kv);
    }
}