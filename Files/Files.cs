using System;
using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
         string[] lines = System.IO.File.ReadAllLines("/Users/afogarasi/Desktop/words_alpha.txt");

        System.IO.File.WriteAllLines("/Users/afogarasi/Desktop/words.2_alpha.txt", lines);   

        StreamReader stream = File.OpenText("/Users/afogarasi/Desktop/words_alpha.txt");

        FileStream outStream = File.OpenWrite("/Users/afogarasi/Desktop/words3_alpha.txt");

        StreamWriter s = new StreamWriter (outStream);


        string line = stream.ReadLine();
        while (line != null)
            {
            Console.WriteLine(line);
            line = stream.ReadLine();
            }
     
        s.Close();
        stream.Close();
        }
    }
}
