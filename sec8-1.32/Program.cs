using System;
using System.Collections.Generic;
using System.IO;

namespace StudentDataManagement
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = LoadStudentsFromFile("students.txt");

            if (students.Count == 0)
            {
                Console.WriteLine("No student data found.");
                return;
            }

            SortStudentsByName(students);

            Console.WriteLine("Sorted student data:");
            DisplayStudentData(students);

            Console.WriteLine("\nEnter student name to search:");
            string searchName = Console.ReadLine();
            Student foundStudent = SearchStudentByName(students, searchName);

            if (foundStudent != null)
            {
                Console.WriteLine($"Found student: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static List<Student> LoadStudentsFromFile(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 2)
                    {
                        Student student = new Student
                        {
                            Name = data[0].Trim(),
                            Class = data[1].Trim()
                        };
                        students.Add(student);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return students;
        }

        static void SortStudentsByName(List<Student> students)
        {
            students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
        }

        static void DisplayStudentData(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"\nName: {student.Name}\nClass: {student.Class}");
            }
        }

        static Student SearchStudentByName(List<Student> students, string searchName)
        {
            return students.Find(student => student.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
