using System;
using System.Collections.Generic;
using System.Linq;

namespace random_bag
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Random Bag!");

            Test();
            Test();
            Test();
            Test();
            Test();

            Console.ReadLine();
        }

        static void Test()
        {
            var bag = new RandomBag();

            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);

            var output = bag.List();

            foreach(var item in output)
            {
                Console.Write(item);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }


    public class RandomBag
    {
        private int _size;
        private Node _first;

        private Random _random = new Random();

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public int Size()
        {
            return _size;
        }

        public void Add(int item)
        {
            _first = new Node(item, _first);
            _size++;
        }

        public IEnumerable<int> List()
        {
            var marked = new bool[_size];
            var array = new int[_size];
            var rand = new Random();

            var node = _first;
            while (node is not null)
            {
                var ndx = GetRandom();

                while (marked[ndx] == true)
                {
                    ndx = GetRandom();
                }

                array[ndx] = node.Value;
                marked[ndx] = true;

                node = node.Next;
            }

            return array.AsEnumerable();
        }

        private int GetRandom()
        {
            return _random.Next(_size);
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
