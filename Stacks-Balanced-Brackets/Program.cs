using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Balanced_Brackets
{
    class Program
    {
        //Create properties for opening and closing type brackets
        private static readonly List<char> OpeningType = new List<char> { '(', '{', '[' };
        private static readonly List<char> ClosingType = new List<char> { ')', '}', ']' };

        private static void Main(string[] args)
        {
            //Get input
            var t = Convert.ToInt32(Console.ReadLine());

            var expressions = new List<string>();

            for (var a0 = 0; a0 < t; a0++)
            {
                var expression = Console.ReadLine();
                expressions.Add(expression);
            }

            //Log result
            expressions.ForEach(x => Console.WriteLine(IsBalanced(x) ? "YES" : "NO"));
        }

        //Main logic
        private static bool IsBalanced(string e)
        {
            //Create a stack to store matching closing bracket for every opening one
            var stack = new Stack<char>();

            //Loop through each character in string
            for (var i = 0; i < e.Length; i++)
            {
                var current = e[i];

                //if opening type
                var isOpeningType = OpeningType.Contains(current);

                //add matching closing type to stack
                if (isOpeningType)
                    stack.Push(ClosingType[OpeningType.IndexOf(current)]);
                else //if closing type
                {
                    //if it is the first char in the string return false
                    if (i == 0)
                        return false;

                    //if it is the matching closing bracket then remove from stack and continue
                    if (stack.Count > 0 && stack.Peek() == current)
                        stack.Pop();
                    else
                        return false;
                }
            }

            //Only return true if the stack is empty 
            //(every bracket is successfully  closed) after finishing the loop
            return stack.Count <= 0;
        }
    }
}
