using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public class KeyboardClass
{
    private static string FakeMarkerPosition = "";
    private static string FakeMarker = "?";
    private static int positionNum = 1;
    private static int positionLetter = 1;
    private static List<string> list = new List<string>();//Holds the saved positions when we press Enter

    public static void MoveMarker(ConsoleKeyInfo key)
    {

        if (key.Key == ConsoleKey.RightArrow)
        {
            //when we press Right we increase by 1
            positionNum++;
            if (positionNum >= 3) positionNum = 3;
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            //when we press Left we decrease by 1
            positionNum--;
            if (positionNum <= 1) positionNum = 1;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            //when we press Down we increase by 1
            positionLetter++;
            if (positionLetter >= 3) positionLetter = 3;
            
        }
        else if (key.Key == ConsoleKey.UpArrow)
        {
            //when we press Up we decrease by 1
            positionLetter--;
            if (positionLetter <= 1) positionLetter = 1;
            
        }
        //puts the letter and number together
        FakeMarkerPosition = ConvertToLetter(positionLetter) + positionNum.ToString();
        //set the marker at the position...
        PlaceFakeMarker(FakeMarkerPosition);
    }
    //when we click enter we add a position i.e A2.
    public static void AddPosition(string position)
    {
        list.Add(position);
    }
    public static void ClearList()
    {
        list.Clear();
    }
    //converts a number to a letter...
    private static string ConvertToLetter(int num)
    {
        string theLetter = "";
        if (num == 1)
        {
            theLetter = "A";
        }
        else if (num == 2)
        {
            theLetter = "B";
        }
        else if (num == 3)
        {
            theLetter = "C";
        }
        return theLetter;
    }
    public static string getMarkerPosition()
    {
        return FakeMarkerPosition;
    }
    public static void PlaceFakeMarker(string position)
    {
        int positionToPlaceMarker = Board.PositionTableForVisualBoard(position);

        var j = Board.VisualBoard.FindIndex(q => q == "?");
        if (j != -1)
        {
            //needed so we can stand on an X or O
            Board.VisualBoard[j] = " ";
            //if the position we want to stand on is the same as any of the lists saved positions **every Enter click saves a position**
            if (position == list.Find(q => q == position))
            {
                //just for testing, this is the position we are at
                //Console.WriteLine("POSITION ");
            }
            else
            {
                //replace the former position we were at with a space
                Board.VisualBoard[j] = " ";
            }

            /*Console.WriteLine("i: "+string.Join(" ", i));
            Console.WriteLine("list " + string.Join(", ", list));
            Console.WriteLine("j: " + string.Join(" ", j));
            Console.WriteLine("visualboard j: " + Board.VisualBoard[j]);*/
        }
        if (!(position == list.Find(q => q == position)))
        {

            Board.VisualBoard.RemoveAt(positionToPlaceMarker);
            Board.VisualBoard.Insert(positionToPlaceMarker, FakeMarker);

        }

        Console.Clear();
        Console.WriteLine(string.Join(" ", Board.VisualBoard));
    }

}