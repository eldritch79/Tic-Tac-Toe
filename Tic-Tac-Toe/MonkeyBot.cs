using System;
using System.Collections;
using System.Linq;

// This is the computer player made by mrapan.
// Prepare to loose!

class MonkeyBot
{

    public static void StartMonkeyBot()
    {
        Board.MarkerType = Board.Player2Turn ? "O" : "X";
        if (!Board.GameOver) WinOrBlock();
    }

    // Translate array positions 0-8 to the kind of position input the games likes.
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
            // Error message if somethings goes wrong
            Console.WriteLine("Something terrible has happened on position {0}", internalPosition);
            string a = Console.ReadLine();
        }
        return externalPosition;
    }

    public static void WinOrBlock()
    {
        int? emptySpot = null;
        int k = 0;

        // Array of winning rows
        int[,] winners = new int[,]
                   {
                        {0,1,2},
                        {3,4,5},
                        {6,7,8},
                        {0,3,6},
                        {1,4,7},
                        {2,5,8},
                        {0,4,8},
                        {2,4,6}
                   };

        // This checks if the bot has 2 in a row, if it does, BAM! Time to win!
        // This is just a reversed version of the block method. Read comments down there instead!
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ("O" == Board.ProgramBoard[winners[i, j]]) k++;

                if ("X" == Board.ProgramBoard[winners[i, j]]) k--;

                else if (" " == Board.ProgramBoard[winners[i, j]])
                {
                    emptySpot = winners[i, j];
                }

                if (k == 2)
                {
                    int x = j + 1;

                    if (emptySpot == null && " " == Board.ProgramBoard[winners[i, x]])
                    {
                        PlacePiece(winners[i, x]);
                    }

                    if (emptySpot != null && " " == Board.ProgramBoard[(int)emptySpot])
                    {
                        PlacePiece((int)emptySpot);
                    }

                    break;
                }
            }
            k = 0;
            emptySpot = null;
        }

        // This loops thru the positions in the Winners array to check
        // if the player who just put his mark, now has two in a row
        // anywhere on the board.
        for (int i = 0; i < 8; i++) // The "outer" array in Winners
        {
            for (int j = 0; j < 3; j++) // The "inner" array in Winners
            {
                // If winning row contains opponents mark, X, add 1 to k.
                if ("X" == Board.ProgramBoard[winners[i, j]]) k++;

                // If winning row contains bots mark, O, delete 1 from k, 
                // As this is not a possible winning row anymore
                if ("O" == Board.ProgramBoard[winners[i, j]]) k--;

                else if (" " == Board.ProgramBoard[winners[i, j]])
                {
                    emptySpot = winners[i, j];
                }
                // If k reaches 2, it means that we have had 2 of the players
                // MarkerType on a winning row, STOP HIM!
                if (k == 2)
                {
                    // Make a move!
                    int x = j + 1;
                    if (emptySpot != null && " " == Board.ProgramBoard[(int)emptySpot])
                    {
                        PlacePiece((int)emptySpot);
                    }
                    if (emptySpot == null && " " == Board.ProgramBoard[winners[i, x]])
                    {
                        PlacePiece(winners[i, x]);
                    }
                    break;
                }
            }
            k = 0;
            emptySpot = null;
        }
        PlaceMidOrCorner();
    }

    public static void PlaceMidOrCorner()
    {
        // Arrays of the positions
        int[] corners = { 0, 2, 6, 8 };
        int[] lastResort = { 1, 3, 5, 7 };
        
        bool emptyCornerFound = false;
        bool madeAMove = false;
        Random random = new Random();

        // If center is available, place marker in center.
        if (Board.ProgramBoard[4] == " ")
        {
            PlacePiece(4);
            madeAMove = true;
        }

        // While it has not found an empty corner, keep looking for one. If a move haven't been made already.
        while (!emptyCornerFound && !madeAMove)
        {
            // Choose a random corner from the array, don't want to be predictable
            int randomNumber = random.Next(0, corners.Length);
            // If the random corner is empty, place the mark here.
            if (Board.ProgramBoard[randomNumber] == " ")
            {
                emptyCornerFound = true;
                PlacePiece(randomNumber);
                madeAMove = true;
            }
                // If the random corner is not empty, remove it from the array and keep looping.
            else
            {
                int cornerToRemove = corners[randomNumber];
                corners = corners.Where(val => val != cornerToRemove).ToArray();
            }
            // If there's no empty corners left, break.
            if (corners.Length == 0) break;
        }

        // If bot couldn't win or block, and the center and corners were occupied
        // Pick random from position 1, 3, 5 and 6, same as above but for the worst positions.
        while (!madeAMove)
        {
            int randomNumber = random.Next(0, lastResort.Length);

            if (Board.ProgramBoard[randomNumber] == " ")
            {
                PlacePiece(randomNumber);
                madeAMove = true;
            }
            else
            {
                int lastResortToRemove = lastResort[randomNumber];
                lastResort = lastResort.Where(val => val != lastResortToRemove).ToArray();
            }
            if (lastResort.Length == 0) break;
        }
    }

    public static void PlacePiece(int position)
    {
        KeyboardClass.AddPosition(TranslatePositions(position));
        Board.PlaceMarker(TranslatePositions(position));
    }
}
