using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner5
{
    List<long> seeds = new List<long>();
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
    public long MapNumThroughSubmap(List<Int64> submapList, long num)
    {
        if (num >= submapList[1] && num < submapList[1] + submapList[2])
            return (num - submapList[1]) + submapList[0];
        else
            return num;
    }
    //public long MapNumThroughMap(long num, List<List<Int64>> submapList)
    //{
    //    Parallel.ForEach(submapList, (submap, state) =>
    //    {
    //        var mappednum = MapNumThroughSubmap(submap, num);
    //        if (num != mappednum)
    //        {
    //            num = mappednum;
    //            state.Break();
    //        }
    //    });
    //    return num;
    //}
    public long MapNumThroughMap(long num, List<List<Int64>> submapList)
    {
        foreach (var submap in submapList)
        {
            var mappednum = MapNumThroughSubmap(submap, num);
            if (num != mappednum)
            {
                num = mappednum;
                break;
            }
        }
        return num;
    }

    public void Run(string data)
    {
        long res = 9223372036854775807;
        GetAlmanac(data);
        var watch = System.Diagnostics.Stopwatch.StartNew();
        for (var i = 0; i < seeds.Count - 1; i += 2)
        {
            //Parallel.For(seeds[i], seeds[i + 1] + seeds[i], seed =>
            //{
            //    var seedToSoilMapped = MapNumThroughMap(seed, seedsToSoil);
            //    var soilToFertilizerMapped = MapNumThroughMap(seedToSoilMapped, soilToFertilizer);
            //    var fertilizerToWaterMapped = MapNumThroughMap(soilToFertilizerMapped, fertilizerToWater);
            //    var waterToLightMapped = MapNumThroughMap(fertilizerToWaterMapped, waterToLight);
            //    var lightToTemperatureMapped = MapNumThroughMap(waterToLightMapped, lightToTemperature);
            //    var temperatureToHumidityMapped = MapNumThroughMap(lightToTemperatureMapped, temperatureToHumidity);
            //    var humidityToLocationMapped = MapNumThroughMap(temperatureToHumidityMapped, humidityToLocation);
            //    if (res > humidityToLocationMapped)
            //        res = humidityToLocationMapped;
            //});
            for (Int64 seed = seeds[i]; seed < seeds[i + 1] + seeds[i]; seed++)
            {
                var seedToSoilMapped = MapNumThroughMap(seed, seedsToSoil);
                var soilToFertilizerMapped = MapNumThroughMap(seedToSoilMapped, soilToFertilizer);
                var fertilizerToWaterMapped = MapNumThroughMap(soilToFertilizerMapped, fertilizerToWater);
                var waterToLightMapped = MapNumThroughMap(fertilizerToWaterMapped, waterToLight);
                var lightToTemperatureMapped = MapNumThroughMap(waterToLightMapped, lightToTemperature);
                var temperatureToHumidityMapped = MapNumThroughMap(lightToTemperatureMapped, temperatureToHumidity);
                var humidityToLocationMapped = MapNumThroughMap(temperatureToHumidityMapped, humidityToLocation);
                if (res > humidityToLocationMapped)
                    res = humidityToLocationMapped;
            }
        }
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine("{0}, {1}", res + " ", elapsedMs);
    }
}