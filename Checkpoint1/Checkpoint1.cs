using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        public static bool end = false;

        static void Main(string[] args)
        {
        // Create 5 different Modules with the functionality below for a user to access via the console
        // Module 1 - counts numbers between 1 and 100 and display the numbers evenly divisible by three
        // Module 2 - ask user to enter a number, then again or "ok" to end the entry. Upon "ok" all numbers are summed and displayed
        // Module 3 - ask user to enter a number. return and display the factorial as "var! = var factorial"
        // Module 4 - computer generate a random number between 1 and 10. Ask user to guess the number. Correct guess = "You win/loose". User has 4 chances
        // Module 5 = ask user to enter a series of numbers separated by commas. Find the largest number and display it to the console.
   
        // Allow user to choose which Module to execute. Continue asking until user chooses any invalid option
        do {
            Console.WriteLine("Execute one of the following by entering the cooresponding number");
            Console.WriteLine("Enter 1 to display all numbers from 1-100 divisible by three");
            Console.WriteLine("Enter 2 to get the sum of a series of numbers you enter");
            Console.WriteLine("Enter 3 to get the factorial of a number you enter");
            Console.WriteLine("Enter 4 to try and guess the computer chosen number between 1 and 10");
            Console.WriteLine("Enter 5 to find the largest number in a series of numbers you enter");
            Console.WriteLine("Any other choice to exit");
            int choice = int.Parse(Console.ReadLine());
            
            if (choice == 1) {
                NumbersbyThree();
                }
                else if (choice == 2)  {
                SumofNumbers();
                } 
                else if (choice == 3)  {
                Factorial();
                } 
                else if (choice == 4)  {
                GuessaNumber();
                } 
                else if (choice == 5)  {
                MaxNumber();
                } 
                else {
                Console.WriteLine("Ending Exercise");
                end = true;
                }
        } while (!EndExercise() == true );
    // leave this command at the end so your program does not close automatically
        Console.ReadLine();
        }
   
    // Module 1 - counts numbers between 1 and 100 and display the numbers evenly divisible by three
        public static void NumbersbyThree()
        {
        Console.WriteLine("Numbers by Three");
       List<int> threeList = new List<int>();  
        for (int i = 1; i <= 100; i++)
            if ( (i - ((i / 3) * 3))  == 0) {
            Console.WriteLine(i);
            threeList.Add(i);
            }
        Console.WriteLine("Count of numbers divisible by 3: " +threeList.Count); 
        }

    // Module 2 - ask user to enter a number, then again or "ok" to end the entry. Upon "ok" all numbers are summed and displayed
        public static void SumofNumbers()
        {
        Console.WriteLine("Sum of Numbers");
        int sum1 = 0;
        bool endSum = false;
        do {
        // ask user to input a number or "ok" to end
            Console.WriteLine("Enter a number or type \"ok\" when finished");
            string userInput = (Console.ReadLine().ToLower());
        // check to see if user enters "ok" 
            if (userInput == "ok") {
                endSum = true;
                }
        // if user enters another number add it to the other numbers
                else sum1 = sum1 + int.Parse(userInput);
            } while (endSum != true);
        // if user has finished entering numbers print the sum of the numbers to the console
        Console.WriteLine("Sum of Numbers: " + sum1);
        }

    // Module 3 - ask user to enter a number. return and display the factorial as "var! = var factorial"
        public static void Factorial()
        {
        Console.WriteLine("Enter a number to find its factorial: ");
        int f1 = int.Parse(Console.ReadLine());
        int origNum = f1;
        for (int i = f1 - 1; i >= 1; i--){   
            f1 = f1 * i;
            }
        Console.WriteLine(origNum +"! = " +f1);
        } 

    // Module 4 - computer generate a random number between 1 and 10. Ask user to guess the number. Correct guess = "You win/loose". User has 4 chances
        public static void GuessaNumber()
        {
        // ask user to enter a number. save the number.
        Console.WriteLine("Can you guess the computers number in four tries? Enter a number between 1 and 10: ");
        int userGuess = int.Parse(Console.ReadLine());
        // computer generate a random number between 1 and 10. save the number.
        Random rnd = new Random();
        int compGuess = rnd.Next(1, 10);
        bool winCheck = false;
        bool countCheck = false;
        int count1 = 1;
        // check if user number matches computer number OR if user has used four tries
            while (winCheck == false && countCheck == false){
                    count1 = count1 + 1;
        // if user number matches computer number write "you win" to the console. exit exercise.
                if (userGuess == compGuess) {
                    winCheck = true;
                    Console.WriteLine("They Match. You WIN!");
                    }
        // if user number does not match computer number ask user for another number
                else {
                    Console.WriteLine("No Match. Enter a different number: ");
                    userGuess = int.Parse(Console.ReadLine()); 
        // if user has used all four tries without matching the computer, write "you loose" to the console. exit exercise.
                    if (count1 >=4) {
                        countCheck = true;
                        Console.WriteLine("Four tries. No Match. You Loose.");
                    }
                }
            }

        } 

    // Module 5 = ask user to enter a series of numbers separated by commas. Find the largest number and display it to the console. 
        public static void MaxNumber()
        {
        // Ask user for a series of integers separated by commas. save the input.
        Console.WriteLine("Enter a series of integers separated by commas. Cumputer will return the largest number: ");
        string all = Console.ReadLine();
        string[] Section = all.Split(",");
        List<int> numList = new List<int>();
        int eachNum;
        int largest = 0;  
        // Separate the string using the "," and save as a list of integers 
            foreach(string eachSect in Section){
                if(Int32.TryParse(eachSect, out eachNum))
                    numList.Add(eachNum);
            }
        // Find the largest integer in the list and save it 
            foreach (int num in numList){
                if (num > largest) {
                    largest = num;
                }
            }
        // Print largest number to screen        
        Console.WriteLine ("Max Number is: " +largest);  
        } 

    // Check for end of exercise 
        public static bool EndExercise()
        {
        return end;

        }       
    }
}
