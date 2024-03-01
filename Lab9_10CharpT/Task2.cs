using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string GroupNumber { get; set; }
        public List<int> Grades { get; set; }

        public Student(
            string lastName,
            string firstName,
            string patronymic,
            string groupNumber,
            List<int> grades
        )
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            GroupNumber = groupNumber;
            Grades = grades;
        }
    }

    public class Task2
    {
        public static void Task2_()
        {
            string filePath = "students.txt";
            Queue<Student> successfulStudents = new Queue<Student>();
            Queue<Student> otherStudents = new Queue<Student>();

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
                        successfulStudents.Enqueue(student);
                    }
                    else
                    {
                        otherStudents.Enqueue(student);
                    }
                }
            }

            if (successfulStudents.Count > 0)
            {
                Console.WriteLine("Students who have grades 4 and 5 :");
                PrintStudentsQueue(successfulStudents);
            }
            else
            {
                Console.WriteLine("No students who have grades 4 and 5 !");
            }
            Console.WriteLine();
            Console.WriteLine("Other student :");
            PrintStudentsQueue(otherStudents);
        }

        static bool IsSuccessful(Student student)
        {
            return student.Grades.TrueForAll(grade => grade >= 4);
        }

        static void PrintStudentsQueue(Queue<Student> students)
        {
            while (students.Count > 0)
            {
                Student student = students.Dequeue();
                Console.WriteLine(
                    $"{student.LastName} {student.FirstName} {student.Patronymic} \t  {student.GroupNumber} \t Grades: {string.Join(", ", student.Grades)}"
                );
            }
        }
    }
}
