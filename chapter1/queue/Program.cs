using System;
using System.Text;

namespace queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            Console.WriteLine("Welcome to My Queue!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("enqueue or dequeue?");
                var action = Console.ReadLine();

                if (action == "enqueue")
                {
                    Console.WriteLine();
                    Console.WriteLine("enter an integer value");
                    var value = Convert.ToInt32(Console.ReadLine());

                    queue.Enqueue(value);
                }

                if (action == "dequeue")
                {
                    queue.Dequeue();
                }

                Console.WriteLine();
                Console.WriteLine("Current State");
                Console.WriteLine($"{queue.Output()}");
            }
        }
    }


    public class Queue<T>
    {
        private Node _first;
        private Node _last;
        private int _size;

        public void Enqueue(T value)
        {
            var node = BuildNode(value);

            if (_first is null)
            {
                _first = node;
                _last = node;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }

            _size++;
        }

        public T Dequeue()
        {
            if (_first is null)
            {
                return default(T);
            }

            var node = _first;
            if (_last == _first)
            {
                // There is only one item in the list.
                _last = null;
            }
            _first = node.Next;

            _size--;

            return node.Value;
        }

        private Node BuildNode(T value)
        {
            return new Node
            {
                Value = value
            };
        }

        public string Output()
        {
            var builder = new StringBuilder();
            var node = _first;

            while (node is not null)
            {
                builder.Append(node.Value + " ");
                node = node.Next;
            }

            return builder.ToString();
        }

        private class Node
        {
            public T Value;
            public Node Next;
        }
    }
}
