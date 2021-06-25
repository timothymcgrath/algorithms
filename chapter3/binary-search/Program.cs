using System;

namespace binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Binary Search!");

            Test.Run(nameof(Empty), Empty);
            Test.Run(nameof(Standard), Standard);
            Test.Run(nameof(Missing), Missing);

            Console.ReadLine();
        }

        public static bool Empty()
        {
            var search = new BinarySearch();
            var result = search.Get(1);

            return result == -1;
        }


        public static bool Standard()
        {
            var search = new BinarySearch();
            search.Put(1, 5);
            search.Put(3, 2);
            search.Put(4, 4);
            search.Put(2, 3);
            search.Put(1, 7);
            search.Put(7, 22);
            search.Put(43, 34);
            search.Put(8, 43);
            search.Put(54, 87);
            search.Put(17, 212);
            search.Put(143, 134);
            search.Put(18, 143);
            search.Put(154, 187);

            var result = search.Get(43);

            return result == 34;
        }


        public static bool Missing()
        {
            var search = new BinarySearch();
            search.Put(1, 5);
            search.Put(3, 2);
            search.Put(4, 4);
            search.Put(2, 3);
            search.Put(1, 7);
            search.Put(7, 22);
            search.Put(43, 34);
            search.Put(8, 43);
            search.Put(54, 87);
            search.Put(17, 212);
            search.Put(143, 134);
            search.Put(18, 143);
            search.Put(154, 187);

            var result = search.Get(36);

            return result == -1;
        }
    }

    public static class Test
    {
        public static void Run(string testName, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{testName}: {result}");
        }
    }

    public class BinarySearch
    {
        private int[] _keys;
        private int[] _values;

        private int _size;

        public BinarySearch()
        {
            _keys = new int[100];
            _values = new int[100];
        }

        public int Get(int key)
        {
            if (_size == 0)
            {
                return -1;
            }

            var rank = Rank(key, 0, _size - 1);
            if (_keys[rank] == key)
            {
                return _values[rank];
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            var rank = Rank(key, 0, _size - 1);

            if (_keys[rank] == key)
            {
                _values[rank] = value;
                return;
            }

            for (int i = _size; i > rank; i--)
            {
                _keys[i] = _keys[i - 1];
                _values[i] = _values[i - 1];
            }

            _keys[rank] = key;
            _values[rank] = value;

            _size++;
        }

        public int Rank(int key, int low, int high)
        {
            if (high < low)
            {
                return low;
            }

            int mid = low + (high - low) / 2;

            int compare = key.CompareTo(_keys[mid]);

            if (compare < 0)
            {
                return Rank(key, low, mid - 1);
            }
            else if (compare > 0)
            {
                return Rank(key, mid + 1, high);
            }
            else
            {
                return mid;
            }
        }
    }
}
