using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Board
    {
        public static List<string> _theBoard = new List<string>(); 
        
        public static void CreateBoard()
        {
            _theBoard.Add("  1 2 3 ");
            _theBoard.Add(" +-+-+-+");
            _theBoard.Add("A| | | |");
            _theBoard.Add(" +-+-+-+");
            _theBoard.Add("B| | | |");
            _theBoard.Add(" +-+-+-+");
            _theBoard.Add("C| | | |");
            _theBoard.Add(" +-+-+-+");

            Console.WriteLine(string.Join("\n", _theBoard));
        }
    }

