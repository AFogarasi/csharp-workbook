using System;

namespace LoopQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int largest = 0;
            int [] myarray = {1, 9, 24, 8, 72, 99, 3};

            foreach (int num in myarray){
                if (num > largest) {
                largest = num;
                }
            }        
            Console.WriteLine ("Largest Number is: " +largest);  
        }
    }
}