using System;
using System.Collections.Generic;

namespace Mastermind 
{
    class Program 
    {
        static void Main (string[] args) 
        {   
            // Set standard turns to 10, give option for player to select number of turns
            int turns = 10;
            Console.WriteLine("How many tries would you like? Enter a number between 1 and 10");
            int choice = int.Parse(Console.ReadLine());

            // Generate a random secret code for user to try and guess
            Generator nextcode = new Generator();  
            Game game = new Game (nextcode.GetCode());

            // USER HAS 10 TRIES OR USER SELECTION TO BREAK THE SECRET CODE
            // defines a loop to run 10 times counting down from 10 by -1 
            for (turns = choice; choice > 0; choice--) 
            {
                // Writes to console the number of turns (loops) left in the loop
                Console.WriteLine ($"You have {choice} tries left");

                // Asks user to input for letters to try and match "hidden code"
                Console.WriteLine ("Choose four letters: ");

                // assigns the user input letters to string variable called "letters"
                string letters = Console.ReadLine ();

                // Creates a new Ball array instance called "balls" (size 4) based on Ball class
                // User input letters will now be called "balls"
                Ball[] balls = new Ball[4];

                // defines a loop to run 4 times incrementing up by 1 
                for (int i = 0; i < 4; i++) 
                {
                    // Adds each "letter" in string "letters" to array "balls" as the "for" loops 4 times
                    balls[i] = new Ball (letters[i].ToString());
                }
                // Creates a new Row array instance called "row" based on Row class
                // Class Row creates an array "balls" of 4 balls = array "row"
                Row row = new Row (balls);

                // adds a new row "row" to the string array "game" 
                game.AddRow (row);

                // Win Check
                string z = "Win";
                if (game.Rows == z) 
                {
                    choice = 0;
                }
            }
            // When loop has decremented down to 0 this writes to console that the game has ended
            Console.WriteLine ("Game Over");
        }
    }

    public class Generator 
    {
        Random rnd = new Random();
        private string[] code;
        private string [] primer;
        
        public Generator () 
        {
            primer = (new string[] { "a", "b", "c", "d" });
            this.code = primer;
        }
        public String[] GetCode()
        {
            // SETS A NEW SECRET CODE 
            for (int i = 0; i < this.code.Length - 1; i++)
            {
                // Uses a swap-places method climbing through the index of the array
                string temp = this.code[i];
                int j = rnd.Next(i, this.code.Length);

                // takes index "value" at the current itteration and moves it to the randomly found index 
                this.code[i] = this.code[j];

                // does a swap, using the original saved value and moves it to the index of the randomly tagged value
                this.code[j] = temp;
            }
            // If you want to see the SECRET CODE uncomment the following two lines:
            // String toSee = String.Format("{0} {1} {2} {3}", this.code);
            // Console.WriteLine (toSee);
            
            return this.code;
        }
    }
    class Game 
    {
        // creates a List called "rows" for "Rows"to be input - no size is required for a List
        private List<Row> rows = new List<Row> ();

        // creates a blank string array named "answer" with a size of 4 positions
        private string[] answer = new string[4];

        // Game Constructor - creates an instance of a Game using string arrray "answer"
        public Game (string[] answer) 
        {
            // sets the current instance of array "answer" to this.answer = ["a", "b", "c", "d"]
            this.answer = answer;
        }
        // Method Score takes in two parameters "Row" and "row" 
        private string Score (Row row) 
        {
            // DETERMINES STATUS OF CURENT INSTANCE NUMBER RIGHT WIN/PARTIAL WIN
            // using method "Clone" creates a copy of the string array "this.answer" named "answerClone"
            // answerClone = this.answer ["a", "b", "c", "d"]
            string[] answerClone = (string[]) this.answer.Clone ();

            // red is correct letter and correct position
            // white is correct letters minus red
            // this.answer => ["a", "b", "c", "d"]
            // row.balls => [{ Letter: "c" }, { Letter: "b" }, { Letter: "d" }, { Letter: "a" }]
            int red = 0;

            // defines a loop to run 4 times
            for (int i = 0; i < 4; i++) 
            {
                // sets a bool, "true" if the index position in array answerClone = row.balls (same)index position
                // if true increment "red" by 1
                if (answerClone[i] == row.balls[i].Letter) 
                {
                    // red (index position) increments with each true itteration up to maximum of 4
                    red++;
                }
            }
            int white = 0;

            // defines a loop to run 4 times
            for (int i = 0; i < 4; i++) 
            {
                // using method Array.IndexOf(arrayName, value) returns the index postion of the value
                // foundIndex is set to the index position of the found value
                // if no match is found the method returns the lower bound less 1 (0-1=-1)
                int foundIndex = Array.IndexOf (answerClone, row.balls[i].Letter);

                // if statement to execute if foundIndex (position) is greater than -1 (0 or above)
                // the if statement executes if the value found in "row.balls[i].Letter is found in array answerClone
                if (foundIndex > -1) 
                {
                    // increment "white" by 1 if the value in any index position value matches value in array as it increments
                    white++;
                    
                    // reset answerClone of index position "foundIndex"
                    answerClone[foundIndex] = null;
                }
            }
            // win check if red = 4 = Win
            if (red == 4) 
            {
                return $"All {red} match. YOU WIN!";
            }

            // returns two numbers "exact matches" and "any matches - exact matches"
            else 
            { 
                return $"Right color right spot = {red}, Right color wrong spot = {white - red}";
            }
        }

        // Method AddRow using return from Class Row
        public void AddRow (Row row) 
        {
            // Adds variable "row" to the current instance of this.rows
            this.rows.Add (row);
        }

        // Method Rows writes to screen the STATUS OF CURENT INSTANCE NUMBER RIGHT WIN/PARTIAL WIN
        public string Rows 
        {
            get 
            {
                foreach (var row in this.rows) 
                {
                    Console.WriteLine (row.Balls);
                    Console.WriteLine ("Score: " +Score (row));
                    string x = "All 4 match. YOU WIN!";
                    if ( x == Score (row)){
                        return "Win";
                    }
                }
                return "";               
            }
        }
    }

    class Ball 
    {
        public string Letter 
        { 
            get; private set; 
        }

        // Game Constructor - creates an instance of a Ball, defines and uses the string variable "letter"
        public Ball (string letter) 
        {
            // sets the current instance of string variable "letter" to this.Letter 
            this.Letter = letter;
        }
    }

    class Row 
    {
        // Using the Ball class for the string varialbe it creates a blank string array named "balls" with a size of 4 positions
        public Ball[] balls = new Ball[4];

        // Game Constructor - creates an instance of a Row using the "balls" array with a size of 4 positions
        public Row (Ball[] balls) 
        {
            // sets the current instance of array "balls" to this.balls = current user entry/guess
            this.balls = balls;
        }

        public string Balls 
        {
            get 
            {
                Console.Write ("You entered the code: ");
                foreach (var ball in this.balls) 
                {
                    Console.Write (ball.Letter);
                }
                return "";
            }
        }
    }
}
