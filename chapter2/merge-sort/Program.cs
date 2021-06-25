using System;
using System.Text;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Merge Sort!");

            Test(nameof(Empty), Empty);
            Test(nameof(Ordered), Ordered);
            Test(nameof(Unordered), Unordered);

            Console.ReadLine();
        }

        private static bool Empty()
        {
            var input = new int[] { };
            var sort = new MergeSort<int>();

            sort.Sort(input);

            return sort.IsSorted(input);
        }

        private static bool Ordered()
        {
            var input = new int[] { 1, 2, 3, 4 };
            var sort = new MergeSort<int>();

            sort.Sort(input);

            return sort.IsSorted(input);
        }

        
        private static bool Unordered()
        {
            var input = new int[] { 1, 5, 3, 7, 2, 4, 8, 2, 1, 6, 8, 2, 5, 8, 2, 3, 6, 9, 5, 2, 3, 5, 8, 7, 8, 4, 2, 4, 6, 8, 8, 5, 2, 1, 1, 5, 8, 8 };
            var sort = new MergeSort<int>();

            sort.Sort(input);

            return sort.IsSorted(input);
        }

        private static void Test(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{name}: {result}");
        }
    }

    public class MergeSort<T> where T : IComparable
    {
        private T[] _temp;

        public void Sort(T[] array)
        {
            _temp = new T[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int mid = low + (high - low) / 2;
            Sort(array, low, mid);
            Sort(array, mid + 1, high);
            Merge(array, low, mid, high);
        }

        private void Merge(T[] array, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                _temp[k] = array[k];
            }

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    array[k] = _temp[j++];
                }
                else if (j > high)
                {
                    array[k] = _temp[i++];
                }
                else if (IsLess(_temp[i], _temp[j]))
                {
                    array[k] = _temp[i];
                }
                else
                {
                    array[k] = _temp[j];
                }
            }
        }

        public bool IsSorted(T[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                if (IsLess(array[i], array[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        public string Output(T[] array)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                builder.Append($"{array[i]}" + " ");
            }

            return builder.ToString().Trim();
        }

        private bool IsLess(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }
    }
}
