using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

//Hello Wrorld Assignment
    //Write a C# program that prints to screen "Hello my name is Andy" then
        Console.WriteLine("Hello my name is Andy!");
    //Ask user for name "user name"
        Console.WriteLine("What is your name?");
    //Get "user name"      
        string userName = Console.ReadLine();
    //Print to screen "Nice to meet you" "user name"            
        Console.WriteLine("Nice to meet you "+userName);      

//Day 1 Lesson
    //Write a C# program that takes two numbers as input, adds them together, and displays the result of that operation
        int number1 = 0;
        int number2 = 0;
        int total = 0;

    //note: the Parse method converts a string to a number - you define the number type (int, float, long, double, etc)
        Console.WriteLine("Please enter a whole number greater than 0: ");
        number1 = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Please enter another whole number greater than 0: ");
        number2 = int.Parse(Console.ReadLine());

        total = number1 + number2;
        Console.WriteLine("Sum of two whole numbers, result = "+ total);

    //Write a C# program that converts yards to inches.
        int yards = 0;
        int inches = 32;

        Console.WriteLine("Enter a whole number of yards to convert: ");
        yards = int.Parse(Console.ReadLine());

        inches = yards * inches;
        Console.WriteLine("Number of inches = "+ inches);

    //Create and define the variable people as true.
        bool people = true;

    // Create and define the variable f as false.
        bool f = false;

    // Create and define the variable num to be a decimal.
        double num = 0;  

    // Display the product of num multiplied by itself.
        Console.WriteLine("Enter a whole number to be squared: ");
        num = int.Parse(Console.ReadLine());

        num = Math.Pow(num,2);
        Console.WriteLine("Number squared = "+ num);

    // Create the following variables with your personal information:
    // firstName
        string firstName = "Andy";

    // lastName
        string lastName = "Fogarasi";

    // age
        int age = 55;

    // job
        string job = "entrepreneur";

    // favoriteBand
        string favoriteBand = "Zac Brown";

    // favoriteSportsTeam
        string favoriteSportsTeam = "Hoonigan Racing";

    // Experiment with Console.WriteLine(); to print out different pieces of your personal information.
        Console.WriteLine("My name is "+ firstName + ' '+lastName);
        Console.WriteLine("I am "+ age + " years old");
        Console.WriteLine("I am an "+ job);
        Console.WriteLine("My favorite band is "+ favoriteBand);
        Console.WriteLine("My favorite sports team is "+ favoriteSportsTeam);

    // Convert the variable num to an int.
        num = (double) 6.89;
        // Explicit cast double to int.
        num = (int) num;
        Console.WriteLine("Explict cast of double to int. Any decimals are truncated: "+ num);

    // Print to the console the sum, product, difference, and quotient of 100 and 10.
        int num1 = 100;
        int num2 = 10;
        int sum = num1 + num2;
        int prod = num1 * num2;
        int dif = num1 - num2;
        int quo = num1 / num2;
    
        Console.WriteLine("The sum, product, difference and quotient of 100 and 10 are:");
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Product: " + prod);
        Console.WriteLine("Difference: " + dif);
        Console.WriteLine("Quotient: " + quo);       
        }   
    }
}

