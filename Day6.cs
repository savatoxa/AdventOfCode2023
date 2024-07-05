using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner6
{
    List<int> time = new List<int>();
    List<int> dist = new List<int>();
    long timecorr;
    long distcorr;

    public void GetTimeDist(string data)
    {
        Parser parser = new Parser();
        var timeStrArr = parser.SplitStrBySpaces2((parser.SplitStrByLines(data)[0]));
        var distStrArr = parser.SplitStrBySpaces2((parser.SplitStrByLines(data)[1]));
        var timecorrStr = "";
        var distcorrStr = "";
        for (var i = 1; i < timeStrArr.Count(); i++)
        {
            time.Add(Convert.ToInt32(timeStrArr[i]));
            timecorrStr += timeStrArr[i];
        }
        for (var i = 1; i < distStrArr.Count(); i++)
        {
            dist.Add(Convert.ToInt32(distStrArr[i]));
            distcorrStr += distStrArr[i];
        }
        timecorr = Int64.Parse(timecorrStr);
        distcorr = Int64.Parse(distcorrStr);
    }
    public List<long> GetDistances(long timerace)
    {
        List<long> distances = new List<long>();
        for(var t = 0; t <= timerace; t++)
        {
            distances.Add((timerace - t) * t);
        }
        return distances;
    }

    public long MoreRecords(long timerace, long recorddist)
    {
        long numdists = 0;
        foreach (long distance in GetDistances(timerace))
            if (distance > recorddist)
                numdists++;
        return numdists;
    }

    //public int GetAllRecords()
    //{
    //    int allRecords = 1;
    //    for(var i =0; i < time.Count; i++)
    //        allRecords *= MoreRecords(time[i], dist[i]);
    //    return allRecords;
    //}

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        GetTimeDist(data);
        time.ForEach(t => Console.WriteLine(t));
        Console.WriteLine("");
        dist.ForEach(t => Console.WriteLine(t));
        Console.WriteLine("");
        //GetDistances(time[0]).ForEach(d => Console.WriteLine(d));
        Console.WriteLine("___");
        Console.WriteLine(MoreRecords(timecorr, distcorr));
        //Console.WriteLine(GetAllRecords());
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}