using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner9
{
    Parser parser = new Parser();
    List<List<int>> envreport = new List<List<int>>();

    public void CreateEnvreport (string data)
    {
        foreach(var strarr in parser.SplitStrByLines(data))
            envreport.Add(parser.SplitStrBySpaces2(strarr).ToList().Select(s => Convert.ToInt32(s)).ToList());
    }
    public List<int> DiffSequense (List<int> sequense)
    {
        List<int> diffsequense = new List<int>();
        for(var i = sequense.Count - 1; i > 0; i --)
            diffsequense.Insert(0, sequense[i] - sequense[i-1]);
        return diffsequense;
    }
    public bool IfDiffsequenseZero(List<int> sequense)
    {
        foreach (var element in sequense)
            if (element != 0)
                return false;
        return true;
    }
    public List<List<int>> DiffSequensesList(List<int> sequense)
    {
        List<List<int>> diffsequensesList = new List<List<int>>();
        diffsequensesList.Add(sequense);
        while(!IfDiffsequenseZero(sequense))
        {
            sequense = DiffSequense(sequense);
            diffsequensesList.Add(sequense);
        }
        return diffsequensesList;
    }
    public List<List<int>> CompleteDiffSequensesList(List<List<int>> diffsequensesList)
    {
        diffsequensesList[diffsequensesList.Count - 1].Insert(0,0);
        for (var i = diffsequensesList.Count - 1; i > 0; i--)
            diffsequensesList[i - 1].Insert(0, (diffsequensesList[i - 1][0] - diffsequensesList[i][0]));
        return diffsequensesList;
    }
    public int SumOfLastElementsOfAllCompleteDiffSequensesList()
    {
        List<List<int>> completediffsequensesList = new List<List<int>>();
        int sum = 0;
        foreach (var l in envreport)
        {
            completediffsequensesList = CompleteDiffSequensesList(DiffSequensesList(l));
            sum += completediffsequensesList[0][0];
        }
        return sum;
    }
public void Run(string data)
{
    var watch = System.Diagnostics.Stopwatch.StartNew();
    CreateEnvreport(data);
        Console.WriteLine("___");
        Console.WriteLine(SumOfLastElementsOfAllCompleteDiffSequensesList());
    watch.Stop();
    var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine("___");
    Console.WriteLine(elapsedMs);
}
}