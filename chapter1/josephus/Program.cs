using System;

namespace josephus
{
    class Program
    {
        /*
        The Josephus problem can be solved by with a queue by using the queue as a placeholder while looping over it.
        As  you walk the queue, requeue the skipped values to the end of the queue, so they remain in the loop,
        and only remove the values that we land on. 

        This maintains the correct order and the correct size of the loop as it removes items.
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Josephus!");

            Console.WriteLine();
            Console.WriteLine("Enter Elimination Interval:");
            var interval = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter Number of People:");
            var people = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            var queue = new Queue();

            for (var i = 0; i <= people - 1; i++)
            {
                queue.Enqueue(i);
            }

            while (!queue.IsEmpty())
            {
                for (int i = 0; i < interval - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.Write(queue.Dequeue() + " ");
            }

            Console.ReadLine();
        }
    }

    public class Queue
    {
        private Node _head;
        private Node _tail;
        private int _size;

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Enqueue(int value)
        {
            if (_size == 0)
            {
                _head = new Node(value, null);
                _tail = _head;
                _size++;

                return;
            }

            var node = new Node(value, null);
            _tail.Next = node;
            _tail = node;
            _size++;
        }

        public int Dequeue()
        {
            if (_size == 0)
            {
                return 0;
            }

            var node = _head;
            _head = _head.Next;
            _size--;

            return node.Value;
        }
        private class Node
        {
            public int Value;
            public Node Next;

            public Node(int value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
