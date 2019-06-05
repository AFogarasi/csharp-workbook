using System;
using System.Collections.Generic;
using System.Linq;

namespace moreplay
{
    class Program
    {

        static void Main(string[] args)
        {

        Board board = new Board();
 
        board.GenerateCheckers();
        board.DrawBoard();

        Console.Write("MOVE CHECKER: Enter starting row and column, " + "separated by a comma: ");
        string[] fromSpot = Console.ReadLine().Split(',');
        int Frow = 0; 
        int Fcol = 0;
        foreach(string val in fromSpot)  
        {
            if(Int32.TryParse(val, out int eachNum))
                if(Frow == 0)
                {
                    Frow = eachNum;
                }
            Fcol = eachNum;
        }
        Checker Frcheck = board.SelectChecker(Frow,Fcol);
        Console.WriteLine(String.Format("{0} {1} {2}", Frcheck.Color,Frcheck.row,Frcheck.column));


        Console.Write("MOVE CHECKER: Enter ending row and column, " + "separated by a comma: ");
        string[] toSpot = Console.ReadLine().Split(',');
        int Trow = 0; 
        int Tcol = 0;
        foreach(string val in toSpot)  
        {
            if(Int32.TryParse(val, out int eachNum1))
                if(Trow == 0)
                {
                    Trow = eachNum1;
                }
            Tcol = eachNum1;
        }
        Frcheck.row = Trow;
        Frcheck.column = Tcol;
        Frcheck = board.SelectChecker(Trow,Tcol);
        if (Frcheck == null)
        {
            Console.WriteLine( "Is null");
        }
        else 
        {
            Console.WriteLine(String.Format("{0} {1} {2}", Frcheck.Color,Frcheck.row,Frcheck.column));
        }
        board.DrawBoard();

        }
    }

    public class Checker
    {
        public string Symbol;
        public int row { get; set; }
        public int column { get; set; }
        public string Color { get;}


        public Checker(string color, int r, int c)
        {
            Color = color;
            row = r; 
            column = c;    

            int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
            string openCircle = char.ConvertFromUtf32(openCircleId);

            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            string closedCircle = char.ConvertFromUtf32(closedCircleId);

            if (color == "White")
            {
                Symbol = closedCircle;
            }
            else 
            {
                Symbol = openCircle;
            }      
        }
    }    
    public class Board
    {
        // fields 

        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
        Checkers = new List<Checker>();
        }
        
        // Creating the grid that is the board
        public string[][] CreateGrid()
        {
            Console.WriteLine("in create grid;");
            string[][] Grid;
            // CREATE ROWS - 9 index position row of rows
            // "Grid" 9 rows each with an empty row
            Grid = new string[9][];
            // Loop from first row (row) to last row (row) (9 rows)
            for (int row = 0; row < Grid.Length; row ++)
            {
                // CREATE COLUMNS - 0 -> 9 in each ROW
                Grid[row] = new string[9] {" "," "," "," "," "," "," "," "," ",};
            }

            // POPULATE HEADINGS TO "0" COLUMN AND "0" ROWS
            // Loops from first column (row) to last column (row) (9 columns) 
            for (int col = 1; col < 9; col ++)
            {
                // Places a string value starting with "1" -> "8" in each Column of the "0" Row
                Grid[0][col] = (col).ToString();
            }
            // Loops from first row (row) to last row (row) (9 rows)
            for (int row = 1; row < 9; row ++)
            {         
                // Within each row; Loops from first col (row) to last col (row) (9 columns)
                for (int col = 0; col < 9; col ++)
                {
                    // If Column is index "0", sets the value of that row position to the string of that value 
                    if (col == 0)
                    {
                        Grid[row][col] = (row).ToString();
                    }
                }
            }
            foreach (Checker check in Checkers)
            {
                Console.WriteLine("Setting grid for checker at {0}, {1}", check.row, check.column);
                Grid[check.row][check.column] = check.Symbol;
            }
                
            return Grid;
        }

        // View the game board
        public void DrawBoard()
        {   
        string[][] grid = CreateGrid();

         Console.WriteLine("");
            // Loops 9 times - once for each 
            for (int row = 0; row < 9; row ++)
            {
                // Prints a row row on one line with a space " " seperator betwen each
                Console.WriteLine(String.Join(" ", grid[row]));
            }
            Console.WriteLine("");
        }
        
        // Creating all the Checker instances at the beginning of the game
        public void GenerateCheckers()
        {     
            string[,] WhitePos;
            WhitePos = new string[9,9];

            for (int j = 1; j < 4; j++)
            {
                for (int i = 2; i < 9; i+=2)
                {
                    if (j % 2 == 0 && i == 2) // offset column (c) by one on even rows
                    {
                        i -= 1;
                    }
                    WhitePos[j,i] = "White";

                    // Creates a Checker "WhiteChecker based on Checker(string color, int r, int c)
                    // with the row and column initial positions
                    Checker WhiteChecker = new Checker ("White", j, i);

                    // Adds each WhiteChecker to a List called Checkers of 12 checkers
                    Console.WriteLine("add white checker for checker at {0}, {1}", WhiteChecker.row, WhiteChecker.column);
                    this.Checkers.Add(WhiteChecker);
                }              
            }

            string[,] BlackPos;
            BlackPos = new string[9,9];
            Console.WriteLine();
            for (int j = 6; j < 9; j++)
            {
                for (int i = 1; i < 9; i+=2)
                {
                    if (j % 2 != 0 && i == 1) // offset column (c) by one on odd rows
                    {
                        i += 1;
                    }
                    BlackPos[j,i] = "Black";
                    
                    // Creates a Checker "BlackChecker based on Checker(string color, int r, int c)
                    // with the row and column initial positions
                    Checker BlackChecker = new Checker ("Black", j, i);

                   // Adds each BlackChecker to a List called Checkers of 12 checkers
                    Console.WriteLine("add blacj checker for checker at {0}, {1}", BlackChecker.row, BlackChecker.column);
                    this.Checkers.Add(BlackChecker);
                }         
            }
        }
        
        public void PlaceCheckers(int row, int column)
        {

                // Places White and Black Checkers onto the Grid (Board) in their initial positions
            // if (row < 5)  
            // { 
            //     foreach(Checker check in this.Checkers)
            //     {
            //         // if check.row (row coordinate) = input row from Grid
            //         if (check.row == row && check.column == column)
            //         {
            //             Grid[check.row][check.column] = closedCircle;   
            //         }
            //     } 
            // }

            // if (row > 4)  
            // { 
            //     foreach(Checker check in this.Checkers)
            //     {
            //         // if check.row (row coordinate) = input row from Grid
            //         if (check.row == row && check.column == column)
            //         {
            //             Grid[check.row][check.column] = openCircle;   
            //         }
            //     } 
            // }       
        }

        // Selecting a particular checker        
        public Checker SelectChecker(int row, int column)
        {
            foreach(Checker check in Checkers)
            {
                if (check.row == row && check.column == column)
                {
                    return check;
                }
            }
            return null;
        }
        
        // Remove a defeated checker
        public void RemoveChecker(int row, int column)
        {
            foreach(Checker check in Checkers)
            {
                if (check.row == row && check.column == column)
                {
                    this.Checkers.Remove(check);
                    return;
                }
            }
        }
        
        // Check if all checkers of one color have been removed
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {

        }
         public void Start()
        {

            return;
        }
    }
}
