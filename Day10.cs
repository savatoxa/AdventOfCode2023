﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scanner10
{
    Parser parser = new Parser();
    List<List<char>> pipemap = new List<List<char>>();

    public void CreatePipemap(string data)
    {
        pipemap = parser.GetCharMatrix(data);
    }
    public Tuple<int, int> GetStart ()
    {
        for (var i = 0; i < pipemap.Count; i++)
            for (var j = 0; j < pipemap[0].Count; j++)
                if (pipemap[i][j] == 'S')
                    return Tuple.Create(i, j);
        return Tuple.Create(-1, -1);
    }
    public List<Tuple<int, int>> GetValidCells(Tuple<int, int> inputCell)
    {
        var outputcells = new List<Tuple<int, int>>();
        var upperCellChar = 'x';
        var upperRightCellChar = 'x';
        var rightCellChar = 'x';
        var lowerRightCellChar = 'x';
        var lowerCellChar = 'x';
        var lowerLeftCellChar = 'x';
        var leftCellChar = 'x';
        var upperLeftCellChar = 'x';

        if (inputCell.Item1 > 0)        
            upperCellChar = pipemap[inputCell.Item1 - 1][inputCell.Item2];
        if (inputCell.Item1 > 0 && inputCell.Item2 < pipemap[0].Count - 1)
            upperRightCellChar = pipemap[inputCell.Item1 - 1][inputCell.Item2 + 1];
        if (inputCell.Item2 < pipemap[0].Count - 1)
            rightCellChar = pipemap[inputCell.Item1][inputCell.Item2 + 1];
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 < pipemap[0].Count - 1) 
            lowerRightCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2 + 1];
        if (inputCell.Item1 < pipemap.Count - 1)        
            lowerCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2];
        if (inputCell.Item1 < pipemap.Count - 1 && inputCell.Item2 > 0)
            lowerLeftCellChar = pipemap[inputCell.Item1 + 1][inputCell.Item2 - 1];
        if (inputCell.Item2 > 0)
            leftCellChar = pipemap[inputCell.Item1][inputCell.Item2 - 1];
        if (inputCell.Item1 > 0 && inputCell.Item2 > 0)
            upperLeftCellChar = pipemap[inputCell.Item1 - 1][inputCell.Item2 - 1];

        switch (pipemap[inputCell.Item1][inputCell.Item2])
        {
            case 'S':
                //Console.WriteLine("Case: " + 'S');
                if (upperCellChar == '|' || upperCellChar == '7' || upperCellChar == 'F')
                    outputcells.Add(Tuple.Create(inputCell.Item1 - 1, inputCell.Item2));
                if (rightCellChar == 'J' || rightCellChar == '-' || rightCellChar == '7')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 + 1));
                if (lowerCellChar == '|' || lowerCellChar == 'J' || lowerCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1 + 1, inputCell.Item2));
                if (leftCellChar == '-' || leftCellChar == 'F' || leftCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 - 1));
                break;
            case '.':
                //Console.WriteLine("Case: " + '.');
                break;
            case 'F':
                //Console.WriteLine("Case: " + 'F');
                if (rightCellChar == 'J' || rightCellChar == '-' || rightCellChar == '7')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 + 1));
                if (lowerCellChar == '|' || lowerCellChar == 'J' || lowerCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1 + 1, inputCell.Item2));
                break;
            case '7':
                //Console.WriteLine("Case: " + '7');
                if (lowerCellChar == '|' || lowerCellChar == 'J' || lowerCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1 + 1, inputCell.Item2));
                if (leftCellChar == '-' || leftCellChar == 'F' || leftCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 - 1));
                break;
            case 'J':
                //Console.WriteLine("Case: " + 'J');
                if (upperCellChar == '|' || upperCellChar == '7' || upperCellChar == 'F')
                    outputcells.Add(Tuple.Create(inputCell.Item1 - 1, inputCell.Item2));
                if (leftCellChar == '-' || leftCellChar == 'F' || leftCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 - 1));
                break;
            case 'L':
               //Console.WriteLine("Case: " + 'L');
                if (upperCellChar == '|' || upperCellChar == '7' || upperCellChar == 'F')
                    outputcells.Add(Tuple.Create(inputCell.Item1 - 1, inputCell.Item2));
                if (rightCellChar == 'J' || rightCellChar == '-' || rightCellChar == '7')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 + 1));
                break;
            case '-':
                //Console.WriteLine("Case: " + '-');
                if (leftCellChar == '-' || leftCellChar == 'F' || leftCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 - 1));
                if (rightCellChar == 'J' || rightCellChar == '-' || rightCellChar == '7')
                    outputcells.Add(Tuple.Create(inputCell.Item1, inputCell.Item2 + 1));
                break;
            case '|':
                //Console.WriteLine("Case: " + '|');
                if (upperCellChar == '|' || upperCellChar == '7' || upperCellChar == 'F')
                    outputcells.Add(Tuple.Create(inputCell.Item1 - 1, inputCell.Item2));
                if (lowerCellChar == '|' || lowerCellChar == 'J' || lowerCellChar == 'L')
                    outputcells.Add(Tuple.Create(inputCell.Item1 + 1, inputCell.Item2));
                break;
            default:
                break;
        }
        var inputcellChar = pipemap[inputCell.Item1][inputCell.Item2];
        //Console.WriteLine(inputCell);
        //Console.WriteLine(upperCellChar);
        //Console.WriteLine(upperRightCellChar);
        //Console.WriteLine(rightCellChar);
        //Console.WriteLine(lowerRightCellChar);
        //Console.WriteLine(lowerCellChar);
        //Console.WriteLine(lowerLeftCellChar);
        //Console.WriteLine(leftCellChar);
        //Console.WriteLine(upperLeftCellChar);
        return outputcells;
    }
    public bool IfTupleInTupleList(Tuple<int, int> incell, List<Tuple<int, int>> cellslist)
    {   
        foreach(var cell in cellslist)
            if (incell.Equals(cell))
                return true;
        return false;
    }
    public List<Tuple<int, int>> NotCoincidingCells(List<Tuple<int, int>> incomingcellslist, List<Tuple<int, int>> prevcellslist)
    {
        List<Tuple<int, int>> notCoincidingCells = new List<Tuple<int, int>>();
        foreach (var incomingcell in incomingcellslist)
            if (!IfTupleInTupleList(incomingcell, prevcellslist))
                notCoincidingCells.Add(incomingcell);
        return notCoincidingCells;
    }
    public List<Tuple<int, int>> GatAllValidCells(List<Tuple<int, int>> inputcells)
    {
        Console.WriteLine("inputcells:");
        inputcells.ForEach(c => Console.WriteLine(pipemap[c.Item1][c.Item2]));
        var outputcells = new List<Tuple<int, int>>();
        int cnt = 0;
        foreach (var cell in inputcells)
        {
            //Console.WriteLine("inputcell:");
            //Console.WriteLine(pipemap[cell.Item1][cell.Item2]);
            cnt++;
            var notCoincidingCells = NotCoincidingCells(GetValidCells(cell), inputcells);
            Console.WriteLine("notCoincidingCells");
            notCoincidingCells.ForEach(c => Console.WriteLine(pipemap[c.Item1][c.Item2]));
            outputcells.AddRange(notCoincidingCells);
            //GetValidCells(cell).ForEach(c => Console.WriteLine(pipemap[c.Item1][c.Item2]));
        }
        if (cnt == 20)
            return outputcells;
        Console.WriteLine("outputcells:");
        outputcells.ForEach(c => Console.WriteLine(pipemap[c.Item1][c.Item2]));
        return GatAllValidCells(outputcells);
    }

    public void TestNotCoincidingCells()
    {
        var incomcells = new List<Tuple<int, int>> { Tuple.Create(3, 3), Tuple.Create(1, 1) };
        var prevcells = new List<Tuple<int, int>> { Tuple.Create(3, 3), Tuple.Create(1, 1) };
        NotCoincidingCells(incomcells, prevcells).ForEach(c => Console.WriteLine(c));
    }

    public void Run(string data)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        CreatePipemap(data);
        parser.PrintMatrix(pipemap);
        //Console.WriteLine(GetStart());
        Console.WriteLine("___");
        //GetValidCells(Tuple.Create(2,1)).ForEach(c => Console.WriteLine(c));
        GatAllValidCells(new List<Tuple<int, int>> { GetStart()}).ForEach(c => Console.WriteLine(c));
        //TestNotCoincidingCells();
        watch.Stop();
        var elapsedMs = watch.Elapsed.TotalMilliseconds;
        Console.WriteLine(elapsedMs);
    }
}