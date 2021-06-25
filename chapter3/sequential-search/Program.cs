using System;

namespace sequential_search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sequential Search!");

            Test.Run(nameof(Empty), Empty);
            Test.Run(nameof(Standard), Standard);
            Test.Run(nameof(Standard2), Standard2);

            Console.ReadLine();
        }

        static bool Empty()
        {
            var search = new SequentialSearch();
            var result = search.Get(1);

            return result == -1;
        }


        static bool Standard()
        {
            var search = new SequentialSearch();
            search.Put(1, 4);
            search.Put(2, 5);
            search.Put(1, 7);
            search.Put(3, 2);

            var result = search.Get(3);

            return result == 2;
        }
        

        static bool Standard2()
        {
            var search = new SequentialSearch();
            search.Put(1, 4);
            search.Put(2, 5);
            search.Put(1, 7);
            search.Put(3, 2);

            var result = search.Get(1);

            return result == 7;
        }
    }

    static class Test
    {
        public static void Run(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{name}: {result}");
        }
    }

    public class SequentialSearch
    {
        private Node _first;


        public int Get(int key)
        {
            for (var node = _first; node != null; node = node.Next)
            {
                if (key == node.Key)
                {
                    return node.Value;
                }
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (_first == null)
            {
                _first = new Node { Key = key, Value = value };
                return;
            }

            Node lastNode = _first;
            for (var node = _first; node != null; node = node.Next)
            {
                lastNode = node;

                if (node.Key == key)
                {
                    node.Value = value;
                    return;
                }
            }

            lastNode.Next = new Node { Key = key, Value = value };
        }

        private class Node
        {
            public Node Next;
            public int Key;
            public int Value;
        }

    }
}
