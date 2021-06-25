using System;
using System.Text;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Stack!");
            Console.WriteLine();

            Test(nameof(Empty), Empty);
            Test(nameof(Push2), Push2);
            Test(nameof(Push2Pop1), Push2Pop1);
            Test(nameof(PopResult), PopResult);

            Console.ReadLine();
        }

        static bool Empty()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Pop();
            stack.Pop();

            var expected = "";
            var actual = stack.Output();
            return actual == expected;
        }

        static bool Push2()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            var expected = "2 1";
            var actual = stack.Output();
            return actual == expected;
        }


        static bool Push2Pop1()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();

            var expected = "1";
            var actual = stack.Output();
            return actual == expected;
        }

        static bool PopResult()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            var result1 = stack.Pop();
            var result2 = stack.Pop();
            var result3 = stack.Pop();

            return result1 == 2 && result2 == 1 && result3 == 0;
        }

        static void Test(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{name}: {result}");
        }
    }


    public class Stack<T>
    {
        public int _size;

        private Node _head;
        private Node _tail;

        public void Push(T item)
        {
            if (_head is null)
            {
                _head = BuildNode(item);
                _tail = _head;
            }
            else
            {
                var node = BuildNode(item);
                node.Next = _head;
                _head = node;
            }

            _size++;
        }

        public T Pop()
        {
            if (_head is null)
            {
                return default(T);
            }

            var node = _head;
            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            _size--;

            return node.Value;
        }

        public string Output()
        {
            var builder = new StringBuilder();
            var node = _head;

            while (node is not null)
            {
                builder.Append(node.Value + " ");
                node = node.Next;
            }

            return builder.ToString().Trim();
        }

        private Node BuildNode(T value)
        {
            return new Node { Value = value };
        }

        private class Node
        {
            public Node Next;
            public T Value;
        }
    }
}
