using System;
using System.IO;

public static class DirectoriesMethods
{
	public static string DirUp(string dirName, int depth)
	{
		for (var i = dirName.Length - 1; i > 0; i--)
		{
			if (dirName[i].ToString() == "\\")
			{
				var dirParentName = dirName.Substring(0, i);
				depth--;
				if (depth == 0)
					return dirParentName;
				else
					return DirUp(dirParentName, depth);
			}
		}
		return dirName.Substring(0, 2);
	}
}

class Program
{
	static void Main(string[] args)
	{
		var workingDirectory = DirectoriesMethods.DirUp(Environment.CurrentDirectory, 2);

		//string dataStr1 = File.ReadAllText(workingDirectory + "\\" + "data1.txt");
		//string dataStr1 = File.ReadAllText(workingDirectory + "\\" + "data1_test_1.txt");
		//string dataStr1 = File.ReadAllText(workingDirectory + "\\" + "data1_test_2.txt");
        //string dataStr2 = File.ReadAllText(workingDirectory + "\\" + "data2_test1.txt");
        //string dataStr2 = File.ReadAllText(workingDirectory + "\\" + "data2.txt");
		string dataStr3 = File.ReadAllText(workingDirectory + "\\" + "data3_test1.txt");
		Parser parser = new Parser();
		//Scanner1 scanner1 = new Scanner1();
		//Scanner2 scanner2 = new Scanner2();
		Scanner3 scanner3 = new Scanner3();
		//Console.WriteLine(scanner1.CalcCalib(dataStr1));
		//Console.WriteLine(scanner2.GetValidGames(dataStr2));
		Console.WriteLine(scanner3.PartNumbers(dataStr3));
	}
}