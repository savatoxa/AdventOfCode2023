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
		//string dataStr3 = File.ReadAllText(workingDirectory + "\\" + "data3_test1.txt");
		//string dataStr3 = File.ReadAllText(workingDirectory + "\\" + "data3.txt");
		//string dataStr4 = File.ReadAllText(workingDirectory + "\\" + "data4_test1.txt");
		//string dataStr4 = File.ReadAllText(workingDirectory + "\\" + "data4.txt");
		//string dataStr5 = File.ReadAllText(workingDirectory + "\\" + "data5_test1.txt");
		//string dataStr5 = File.ReadAllText(workingDirectory + "\\" + "data5.txt");
		//string dataStr6 = File.ReadAllText(workingDirectory + "\\" + "data6_test1.txt");
		//string dataStr6 = File.ReadAllText(workingDirectory + "\\" + "data6.txt");
		string dataStr7 = File.ReadAllText(workingDirectory + "\\" + "data7.txt");
		//string dataStr7 = File.ReadAllText(workingDirectory + "\\" + "data7_test1.txt");



		Parser parser = new Parser();
		//Scanner1 scanner1 = new Scanner1();
		//Scanner2 scanner2 = new Scanner2();
		//Scanner3 scanner3 = new Scanner3();
		//Scanner4 scanner4 = new Scanner4();
		//Scanner5 scanner5 = new Scanner5();
		//Scanner6 scanner6 = new Scanner6();
		Scanner7 scanner7 = new Scanner7();
		//Console.WriteLine(scanner1.CalcCalib(dataStr1));
		//Console.WriteLine(scanner2.GetValidGames(dataStr2));
		//Console.WriteLine(scanner3.SumPartNumbers(dataStr3));
		//Console.WriteLine(scanner4.AllCardsNum(dataStr4));
		//scanner5.Run(dataStr5);
		scanner7.Run(dataStr7);
	}
}