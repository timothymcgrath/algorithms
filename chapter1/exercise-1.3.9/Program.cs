using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_1._3._9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Exercise!");
            Console.WriteLine();

            var input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
            var result = Convert(input);

            var expected = "( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )";

            Console.WriteLine(result);
            Console.WriteLine(expected == result);

            Console.ReadLine();
        }


        static string Convert(string input)
        {
            /*
                Each operand always has two single-digit numbers on each side. 
                Each right-parens always wraps one operand two single-digit numbers.

                The trick to this is that there are always 3 pieces, the two operands and the operator.
                Everytime we hit a right paren, we can pop off the last 3 symbols, wrap them in (), and repush.
                And then it will unwind itself when it hits the final )'s.
            */

            var stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var value = input[i].ToString();

                if (value == ")")
                {
                    var rightOperand = stack.Pop();
                    var middleoperator = stack.Pop();
                    var leftOperand = stack.Pop();

                    var expression = "( ";
    
                    expression += leftOperand;
                    expression += " ";
                    expression += middleoperator;
                    expression += " ";
                    expression += rightOperand;
                    expression += " )";
                    
                    stack.Push(expression);
                }
                else if(value != " ")
                {
                    stack.Push(value);
                }
            }

            var builder = new StringBuilder();                

            while (stack.Count > 0)
            {
                builder.Append(" ");
                builder.Append(stack.Pop());
                builder.Append(" ");
            }

            return builder.ToString().Trim();
        }
    }
}
