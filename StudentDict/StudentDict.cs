using System;
using System.Collections.Generic;

namespace StudentDict
{
    class Program
    {
        static void Main(string[] args)
        {
        // Enter Student and Grades
        // ask user for 5 student names 
        // for each student ask user for a list of +/- 4 grades
        // print out the min, max and average for each student
        // use a dictionary

            string studentName;
            string gradeString;
            string addAnother = "Y";
            Dictionary<String, String> studentDictionary = new Dictionary<String, String>();
            while (addAnother == "Y")
            {
                Console.WriteLine("Enter Student Name:");
                studentName = Console.ReadLine();
                Console.WriteLine("Enter Student Grades separated by commas:");
                gradeString = Console.ReadLine();
                studentDictionary.Add(studentName, gradeString);                
                Console.WriteLine("Add another student \"Y\" = yes, any other choice to exit: "); 
                addAnother = Console.ReadLine().ToUpper(); 
            }
        
        // Print Grades
        // loop through the keys of the student dictionary to get grades
        // Separate the string using the "," and save as a string array
            foreach(String student in studentDictionary.Keys) 
            {
                String grades = studentDictionary[student];
                string[] noComma = grades.Split(",");
                List<int> gradeList = new List<int>();
                int eachNum;
                int largest = 0;
                int smallest = 100;
                int gradeSum = 0;

            // Convert each grade string to an integer and add to an integer list
                foreach(string eachSect in noComma)
                {
                    if(Int32.TryParse(eachSect, out eachNum))
                        gradeList.Add(eachNum);
                }

            // Print the Min, Max and Avg grades for each student
                int count = gradeList.Count;
            
                foreach (int grade in gradeList)
                {
                    gradeSum = gradeSum + grade;
                        
                    if (grade > largest) 
                    {
                        largest = grade;
                    }
                        
                    if (grade < smallest) 
                    {
                        smallest = grade;
                    }
                }
                double average = (gradeSum / gradeList.Count);
                Console.WriteLine("Student grade summary : " +student +" Max: " +largest +" Min: " +smallest +" Average: " +average);
            }

        Console.ReadLine(); 
        }
    }
}
