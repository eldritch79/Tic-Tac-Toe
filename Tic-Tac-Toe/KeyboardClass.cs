using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public class KeyboardClass
{
    public static bool EnterBool = false;
    private static string FakeMarkerPosition = "";
    private static string FakeMarker = "?";
    private static int positionNum = 1;
    private static int positionLetter = 1;
    private static List<string> list = new List<string>();

    public static void MoveMarker(ConsoleKeyInfo key)
    {

        if (key.Key == ConsoleKey.RightArrow)
        {
            positionNum++;
            if (positionNum >= 3) positionNum = 3;
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
            positionNum--;
            if (positionNum <= 1) positionNum = 1;
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
            positionLetter++;
            if (positionLetter >= 3) positionLetter = 3;
            //ConvertToLetter(positionLetter);
        }
        else if (key.Key == ConsoleKey.UpArrow)
        {
            positionLetter--;
            if (positionLetter <= 1) positionLetter = 1;
            //ConvertToLetter(positionLetter);
        }

        FakeMarkerPosition = ConvertToLetter(positionLetter) + positionNum.ToString();
        //Board.PlaceFakeMarker(FakeMarkerPosition, FakeMarker);
        PlaceFakeMarker(FakeMarkerPosition);
    }
    public static void AddPosition(string position)
    {
        list.Add(position);
    }
    public static void ClearList()
    {
        list.Clear();
    }
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
        var i = Board.VisualBoard.FindIndex(q => q == "X");
        if (j != -1)
        {
            Board.VisualBoard[j] = " ";
            if (position == list.Find(q => q == position))
            {

                Console.WriteLine("POSITION ");
            }
            else
            {

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

        //Console.Clear();
        Console.WriteLine(string.Join(" ", Board.VisualBoard));
    }

}