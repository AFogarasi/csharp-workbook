using System;

namespace ScopesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int sum = 1;
            sum = Sum(4,5);
            Console.WriteLine("The sum is; "+sum);

        }
    public static int Sum(int first, int second)
        {
        int sum = first+second;
        Console.WriteLine("First: "+first);
        Console.WriteLine("Second: "+second);
        return sum;
        }
        


    }
}
