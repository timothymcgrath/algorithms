using System;
using System.Collections.Generic;

namespace exercise134
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            bool closed = true;

            foreach (var character in input.ToCharArray())
            {
                if (character == '['
                    || character == '{'
                    || character == '(')
                {
                    stack.Push(character);
                }

                if (character == '}'
                    || character == ']'
                    || character == ')')
                {
                    var popped = stack.Pop();

                    if ((popped == '(' && character != ')') 
                        || (popped == '[' && character != ']')
                        || (popped == '{' && character != '}'))
                    {
                        closed = false;
                    }
                }

                if (!closed)
                {
                    break;
                }
            }

            if (stack.Count != 0)
            {
                closed = false;
            }

            if (!closed)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }

            Console.ReadLine();
        }
    }

    public interface IEnumerable
    {
    }
}
