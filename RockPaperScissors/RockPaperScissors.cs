using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {

    // Rock Paper Scissors game of a user vs. the computer
            Console.WriteLine("Play Rock Paper Scissors");

        // User Input Method
        // Ask user to input 1 (Rock), 2 (Paper) or 3 (Scissors)
        // Write to screen the player's choice  
            string playGame = "Y";
            while (playGame == "Y"){
                string player1 = "NONE";
                Console.WriteLine("Enter your choice \"1\" = Rock, \"2\" = Paper, \"3\" = Scissors: "); 
            // Error handling using try if something other than integers 1, 2, or 3 are entered    
                try {
                    int play = int.Parse(Console.ReadLine());
                    if (play == 1)
                        {
                    player1 = "ROCK";     
                        }   
                    else if (play == 2)
                        {
                    player1 = "PAPER";     
                        } 
                    else if (play == 3)
                        {
                    player1 = "SCISSORS";     
                        }  
                    Console.WriteLine("YOUR choice: " + player1);

                // Computer Input Method
                // Computer generate a random number between 0 and 2 and assign to a variable
                // Assign Computer variable according to the following instructions:
                // 1) 0 = "R" (Rock)
                // 2) 1 = "P" (Paper)
                // 3) 2 = "S" (Scissors)
                // and write to screen Computer choice
                    string comp1 = "NONE";
                    Random rnd = new Random();
                    int compHand = rnd.Next(0, 3);
                    if (compHand < 1) {
                        comp1 = "ROCK";
                    }
                    else if (compHand > 1) {
                        comp1 = "PAPER";
                    }
                    else {
                        comp1 = "SCISSORS";
                    }
                    Console.WriteLine("COMPUTER choice: " + comp1);   
        
                // Compare and Identify Winner Method
                // Compare User variable to Computer variable and determine result according to instructions below:
                // 1) if User variable (userHand)= Computer variable (compHand) result is "Tie"
                // 2) R vs. S > R is winner
                // 3) S vs. P > S is winner
                // 4) P vs. R > P is winner
                // Write to screen User winner
                    if (player1 == comp1)
                        {
                            Console.WriteLine("You Tie. Try Again");
                    }
                    else if (player1 == "ROCK" && comp1 == "SCISSORS")
                        {
                            Console.WriteLine("You Win!");
                    }
                    else if (player1 == "SCISSORS" && comp1 == "PAPER")
                        {
                            Console.WriteLine("You Win!");
                    }
                    else if (player1 == "PAPER" && comp1 == "ROCK")
                        {
                            Console.WriteLine("You Win!");
                    }
                    else {
                            Console.WriteLine("Computer Wins!");
                    }
                }
            // catch point in case of a bad user entry
                catch (FormatException fex) { 
                    Console.WriteLine(fex.Message); 
                    }    
                Console.WriteLine("Play again \"Y\" = yes, any other choice to exit: "); 
                playGame = Console.ReadLine().ToUpper();
            }
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
 
        }
    }
}

