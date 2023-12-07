using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scanner2
{
    Parser parser = new Parser();
    public List<List<List<Tuple<int, string>>>> GetAllGames(string data)
    {
    List<List<List<Tuple<int, string>>>> allGames = new List<List<List<Tuple<int, string>>>>();
    parser.GetAllGames(data);
    return allGames;
    }
}