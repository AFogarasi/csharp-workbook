using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "O";
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };

        public static void Main()
        {
            do
            {
            DrawBoard(); 
            playerTurn = (playerTurn == "X") ? "O" : "X";
            GetInput();
            } while (!CheckForWin() && !CheckForTie());
            Console.WriteLine("Game Over!");

        // leave this command at the end so it does not close automatically
            Console.ReadLine();
        }

        public static void GetInput()
        {
        // Ask player to enter "row" and "collumn" coordinates to place their "X" or "O" on a spot
        // Collect the values of the row and collumn (spot) and assign them to variables
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = int.Parse(Console.ReadLine());
        // Check to see if spot is open. If not open, choose another. Otherwise put the mark in the spot.
        // If a new mark is placed in a spot, switch the player...X -> O, or O -> X after the mark is placed.
            if (board[row][column] == "X" || board[row][column] == "O"){
                Console.WriteLine("That square is already taken. Choose another:");
                playerTurn = (playerTurn == "X") ? "O" : "X";
            }
            else {PlaceMark (row, column); 
            }
        }

        public static void PlaceMark(int row, int column)
        {
        // place the playerTurn mark onto correct place on the board 
            board[row][column] = playerTurn;
        }

        public static bool CheckForWin()
        {
        // check the three posible win methods: horizantal, vertical and diagnal for a win

            bool anyWin = false;
            anyWin = (HorizontalWin() == true || VerticalWin() == true || DiagonalWin() == true);
            return anyWin;
        }

        public static bool CheckForTie()
        {
        // check to see if any spot is still open in any row
        // if there is still an open spot game continues
 
            string blank = " ";
            bool openOne      = false;
            bool openTwo      = false;
            bool openThree    = false;
            bool openSpot     = false;
            openOne          = (board[0][0] != blank && board[0][1] != blank && board[0][2] != blank);
            openTwo          = (board[1][0] != blank && board[1][1] != blank && board[1][2] != blank);
            openThree        = (board[2][0] != blank && board[2][1] != blank && board[2][2] != blank);
            openSpot         = (openOne == true && openTwo == true && openThree && true);

            if (openSpot == true) {
                Console.WriteLine("You tied. Try again");
            }
            return openSpot;
        }
        
        public static bool HorizontalWin()
        {
        // check all three array rows for a win
        // do the three index postitions in row1 have the same variable > if yes = win. repeat for row 2 and 3

            bool rowOne         = false;
            bool rowTwo         = false;
            bool rowThree       = false;
            bool winHorizantal  = false;
            rowOne          = (board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn);
            rowTwo          = (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn);
            rowThree        = (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn);
            winHorizantal   = (rowOne == true || rowTwo == true || rowThree == true);

            if (winHorizantal == true) {
                DrawBoard();
                Console.WriteLine("Player " +playerTurn +" Wins!");
            }
            return winHorizantal;
        }

        public static bool VerticalWin()
        {
        // check all three array columns for a win
        // do the three index postitions in column1 have the same variable > if yes = win. repeat for column 2 column 3

            bool columnOne     = false;
            bool columnTwo     = false;
            bool columnThree   = false;
            bool winVertical   = false;
            columnOne      = (board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn);
            columnTwo      = (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn);
            columnThree    = (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn);
            winVertical    = (columnOne == true || columnTwo == true || columnThree == true);

            if (winVertical == true) {
                DrawBoard();
                Console.WriteLine("Player " +playerTurn +" Wins!");
            }
            return winVertical;
        }

        public static bool DiagonalWin()
        {
        // check diagnal paths for a win
        // do the three index postitions in rightDown have the same variable > if yes = win. repeat leftDown

            bool rightDown     = false;
            bool leftDown      = false;
            bool winDiagnal    = false;
            rightDown      = (board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn);
            leftDown       = (board[0][2] == playerTurn && board[1][1] == playerTurn && board[2][0] == playerTurn);
            winDiagnal     = (rightDown == true || leftDown == true);

            if (winDiagnal == true) {
                DrawBoard();
                Console.WriteLine("Player " +playerTurn +" Wins!");
            }
            return winDiagnal;
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}
