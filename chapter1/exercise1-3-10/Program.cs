using System;
using System.Collections.Generic;

namespace exercise1310
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Exercise!");

            var input = "((1+3)*4)";
            var expected = "13+4*";

            var actual = Convert(input);

            Console.WriteLine(actual);
            Console.WriteLine(actual == expected);

            Console.ReadLine();
        }

        public static string Convert(string input)
        {
            /*
                The difference between teh two is that the operator moves to the right instead of the middle. 
                So, if we iterate through the values, everytime we hit an operand, operator, operand, we have a set.
                We could have two queues, one for operators and one for operands.

                If we can trust that the ()'s are in the correct places, we can use the closing parens to signify that we need to pop the last operator.
                So, just output every thing but operators, but then when we hit a ), output the last operator.
            */

            var output = string.Empty;
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i];

                if (value == '+')
                {
                    stack.Push(value);
                    continue;
                }
                if (value == '-')
                {
                    stack.Push(value);
                    continue;
                }
                if (value == '*')
                {
                    stack.Push(value);
                    continue;
                }
                if (value == '/')
                {
                    stack.Push(value);
                    continue;
                }

                if (value == '(')
                {
                    continue;
                }
                
                if (value == ')')
                {
                    output += stack.Pop();
                    continue;
                }

                output += value;
            }

            return output;
        }
    }
}
