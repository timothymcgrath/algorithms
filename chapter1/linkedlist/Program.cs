using System;
using System.Text;

namespace linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my linked list!");

            var linkedList = new LinkedList<int>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter the operation (add | remove) followed by the integer value for adds, no value for remove (ex: add 5, remove)");
                var input = Console.ReadLine();

                var split = input.Split(" ");
                var operation = split[0];

                if (operation == "add")
                {
                    var value = Convert.ToInt32(split[1]);
                    linkedList.Add(value);
                }
                else if (operation == "remove")
                {
                    linkedList.Remove();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Current State:");
                Console.WriteLine(linkedList.Output());
                Console.WriteLine($"Max: {linkedList.Max()}");
            }
        }
    }

    public class LinkedList<T>
    {
        private Node _first;
        private Node _last;

        private int _size;

        public void Add(T value)
        {
            if (_first == null)
            {
                // List is empty, add the first item.
                _first = BuildNode(value);
                _last = _first;
            }
            else
            {
                var node = BuildNode(value);

                node.Previous = _last;
                _last.Next = node;
                _last = node;
            }

            _size++;
        }

        public void Remove()
        {
            if (_first == null)
            {
                // List is empty, exit out.
                return;
            }

            if (_first == _last)
            {
                // Removing the final itme in the list.
                _first = null;
                _last = null;
            }
            else
            {
                var node = _last;
                _last = node.Previous;
                _last.Next = null;
            }

            _size--;
        }

        public T Max()
        {
            if (_first == null)
            {
                return default(T);
            }

            return MaxRecursive(_first);
        }

        private T MaxRecursive(Node node)
        {
            if (node.Next != null)
            {
                return MaxRecursive(node.Next);
            }

            return node.Value;
        }

        public string Output()
        {
            if (_first == null)
            {
                return "Empty";
            }

            var output = new StringBuilder();
            var node = _first;

            while (node != null)
            {
                output.Append(node.Value);
                output.Append(" ");
                node = node.Next;
            }
            return output.ToString();
        }

        private Node BuildNode(T value)
        {
            return new Node { Value = value };
        }

        private class Node
        {
            public T Value;

            public Node Previous;
            public Node Next;
        }
    }
}
