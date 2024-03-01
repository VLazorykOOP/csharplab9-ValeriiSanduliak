using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    public class Task1
    {
        public static void Task1_()
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
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '#')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            char[] resultArray = stack.ToArray();
            Array.Reverse(resultArray);
            string result = new string(resultArray);

            return result;
        }
    }
}
