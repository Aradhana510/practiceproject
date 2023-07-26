using System;
using System.IO;

namespace StudentDataConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Specify the file path where the student data is stored
                string filePath = "students.txt";

                // Read all lines from the text file
                string[] lines = File.ReadAllLines(filePath);

                // Display the data on the console
                Console.WriteLine("Student Data:");
            

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    string studentID = data[0];
                    string firstName = data[1];
                    string lastName = data[2];
                    string grade = data[3];

                    // Format the columns using fixed width
                    string formattedLine = string.Format("{0,-5}{1,-15}{2,-15}{3,-5}", studentID, firstName, lastName, grade);

                    Console.WriteLine(formattedLine);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
