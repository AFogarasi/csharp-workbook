using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        //  This is FizzBuzz
        // Count from 0 to 100
        // If the the count number is divisble by 5 and 3 (15) without a remainder print "FizzBuzz"
        // If the the count number is divisble by 5 without a remainder print "Buzz"
        // If the the count number is divisble by 3 without a remainder print "Fizz"
        // If none of the above apply, print out the number

            for (int i = 1; i <= 100; i++)
            {
                if ( (i - ((i / 15) * 15))  == 0) {
                Console.WriteLine("FizzBuzz");
                }
                else if ( (i - ((i / 5) * 5))  == 0) {
                Console.WriteLine("Buzz");
                } 
                else if ( (i - ((i / 3) * 3))  == 0) {
                Console.WriteLine("Fizz");
                }
                else {
                Console.WriteLine(i);
                }
            }     

        }
    }
}
