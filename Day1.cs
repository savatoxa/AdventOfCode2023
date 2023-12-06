using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner1
{
    Parser parser = new Parser();
    public string[] GetLines(string data)
    {
        return parser.SplitStrByLines(data);
    }
    public int CalcCalib(string data)
    {
        var lines = GetLines(data);
        string first = "";
        string last = "";
        int sum = 0;
        Dictionary<string, string> numbers = new Dictionary<string, string> { {"1","1"},{"2","2"},{"3","3"},{"4","4"},{"5","5"},
            {"6","6"},{"7","7"},{"8","8"},{"9","9"},{"one","1"},{"two","2"},{"three","3"},{"four","4"},{"five","5"},
            {"six","6"},{"seven","7"},{"eight","8"},{"nine","9"} };
        foreach (var line in lines)
        {
            int firstindex = 1000;
            int lastindex = 0;
            foreach (var k in numbers.Keys)
                if (line.IndexOf(k) < firstindex && line.IndexOf(k) != -1)
                {
                    first = k;
                    last = k;
                    firstindex = line.IndexOf(k);
                }
            foreach (var k in numbers.Keys)
                if (line.LastIndexOf(k) > lastindex && line.LastIndexOf(k) != -1)
                {
                    last = k;
                    lastindex = line.LastIndexOf(k);
                }
            sum += Int16.Parse(String.Concat(numbers[first], numbers[last]));
        }
        return sum;
    }
}