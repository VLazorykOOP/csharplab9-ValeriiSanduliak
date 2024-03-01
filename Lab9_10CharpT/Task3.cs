using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    public class Task3
    {
        static void Task1_ArrayList()
        {
            string input = "abc#d##c   a#bc#d#c    abc##d";
            Console.WriteLine("Input string : ");
            Console.WriteLine(input);
            Console.WriteLine("Result : ");
            string result = ProcessInput(input);
            Console.WriteLine(result);
        }

        static string ProcessInput(string input)
        {
            ArrayList list = new ArrayList();

            foreach (char c in input)
            {
                if (c == '#')
                {
                    if (list.Count > 0)
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                }
                else
                {
                    list.Add(c);
                }
            }

            string result = string.Join("", list.ToArray());

            return result;
        }

        public static void Task3_()
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Task1 using ArrayList : ");
            Console.WriteLine("=========================================================");
            Task1_ArrayList();
            Console.WriteLine("=========================================================");
            Console.WriteLine("Task2 using ArrayList : ");
            Console.WriteLine("=========================================================");
            Task2ArrayList.Task2_ArrayList();
        }
    }

    public class Task2ArrayList
    {
        public static void Task2_ArrayList()
        {
            string filePath = "students.txt";
            ArrayList successfulStudents = new ArrayList();
            ArrayList otherStudents = new ArrayList();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(' ');

                    string lastName = data[0];
                    string firstName = data[1];
                    string patronymic = data[2];
                    string groupNumber = data[3];
                    List<int> grades = new List<int>
                    {
                        int.Parse(data[4]),
                        int.Parse(data[5]),
                        int.Parse(data[6])
                    };

                    Student student = new Student(
                        lastName,
                        firstName,
                        patronymic,
                        groupNumber,
                        grades
                    );

                    if (IsSuccessful(student))
                    {
                        successfulStudents.Add(student);
                    }
                    else
                    {
                        otherStudents.Add(student);
                    }
                }
            }

            if (successfulStudents.Count > 0)
            {
                Console.WriteLine("Students who have grades 4 and 5 :");
                PrintStudentsList(successfulStudents);
            }
            else
            {
                Console.WriteLine("No students who have grades 4 and 5 !");
            }
            Console.WriteLine();
            Console.WriteLine("Other students :");
            PrintStudentsList(otherStudents);
        }

        static bool IsSuccessful(Student student)
        {
            return student.Grades.TrueForAll(grade => grade >= 4);
        }

        static void PrintStudentsList(ArrayList students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(
                    $"{student.LastName} {student.FirstName} {student.Patronymic} \t  {student.GroupNumber} \t Grades: {string.Join(", ", student.Grades)}"
                );
            }
        }
    }
}
