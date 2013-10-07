using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EmkesBot
{
    public static bool MyTurn { get; set; }
    public static List<string> CurrentBoard { get; set; }
    public static string CurrentBoardString { get; set; }
    private static List<int> posValue = new List<int>() { 3, 2, 3, 2, 4, 2, 3, 2, 3 };
    private static List<string> allPos = new List<string>(){"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3"};
    public static List<string> _posTakenX = new List<string>();
    public static List<string> _posTakenO = new List<string>();
    private static int highest;

    public static void StartHalfBrainBot()
    {
        
        Console.WriteLine("ProgramBoard Count: " + Board.ProgramBoard.Count);
        Board.MarkerType = Board.Player2Turn ? "O" : "X";
        ImportCurrentBoard();
        PosValue();

    }
    public static void ImportCurrentBoard()
    {
        CurrentBoard = new List<string>(Board.ProgramBoard);
        CurrentBoard.Insert(3, "\n");
        CurrentBoard.Insert(7, "\n");
        CurrentBoardString = string.Join("", CurrentBoard);
    }
    public static void IsItMyTurnYet()
    {
        // This is where it is decided if this bot acts as player 1 or 2
        MyTurn = Board.Player2Turn;

        if (MyTurn)
        {
            PosValue();
        }
    }
    public static void PosValue()
    {
        int i = 0;
       // int j = 0;
        //int k = 0;
        //int l = 0;
        //int m = 0;
        foreach (var item in allPos)
        {

            foreach (var match in KeyboardClass.list.Where(s => s.StartsWith(item)))
            {
                posValue[i] = 0;//puts all already assigned values to 0 so it never has the highest value  
            }
            i++;
        }
        

      /*  foreach (var item in allPos.Where(q=>q.StartsWith("A")))
        {
           
            
            j++;
        }
        foreach (var item in _posTakenX.Where(q => q.StartsWith("B")))
        {
            if (k == 2)
            {

                //posValue[j] += 2;
            }

            k++;
        }
        foreach (var item in _posTakenX.Where(q => q.StartsWith("C")))
        {
            if (l == 2)
            {

                //posValue[j] += 2;
            }

            l++;
        }*/

        highest = posValue.FindIndex(q => q == posValue.Max());//looks for the higest(and first) number and takes its index number

        PlaceComputerMarker(highest);
    }
    public static void PlaceComputerMarker(int position)
    {
        KeyboardClass.AddPosition(TranslatePositions(position));
        _posTakenO.Add(TranslatePositions(position));
        Board.PlaceMarker(TranslatePositions(position));

    }
    public static string TranslatePositions(int internalPosition)
    {
        Hashtable translate = new Hashtable
         {
            {0, "A1"},
            {1, "A2"},
            {2, "A3"},
            {3, "B1"},
            {4, "B2"},
            {5, "B3"},
            {6, "C1"},
            {7, "C2"},
            {8, "C3"}
        };

        string externalPosition = (string)translate[internalPosition];
        if (internalPosition < 0 || internalPosition > 8)
        {
            Console.WriteLine("Positionen är felaktig, den ska vara 0-8 men är nu {0}", internalPosition);
            string a = Console.ReadLine();
        }
        return externalPosition;
    }
    public static void ResetList()
    {
       
        posValue.Clear();
        posValue.AddRange(new int[] { 3, 2, 3, 2, 4, 2, 3, 2, 3 });
    }

}
