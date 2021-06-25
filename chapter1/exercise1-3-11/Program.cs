using System;
using System.Collections.Generic;

namespace exercise1311
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Exercise!");

            var input = "13+4*";
            var expected = 16;

            var actual = Evaluate(input);

            Console.WriteLine(actual);
            Console.WriteLine(actual == expected);

            Console.ReadLine();
        }

        public static int Evaluate(string input)
        {
            /*
                Once again, the iteration of the string is key.
                Everytime we hit an operator, calculate the last two operands and push the new operand onto the stack.
            */

            var stack = new Stack<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '+')
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    stack.Push(operand1 + operand2);

                    continue;
                }

                if (input[i] == '-')
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    stack.Push(operand1 - operand2);

                    continue;
                }

                if (input[i] == '*')
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    stack.Push(operand1 * operand2);
                    
                    continue;
                }

                if (input[i] == '/')
                {
                    var operand2 = stack.Pop();
                    var operand1 = stack.Pop();
                    stack.Push(operand1 / operand2);
                    
                    continue;
                }

                stack.Push(Convert.ToInt32(input[i].ToString()));
            }

            return stack.Pop();
        }
    }
}
