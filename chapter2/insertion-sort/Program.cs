using System;
using System.Text;

namespace insertion_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Insertion Sort!");
            Console.WriteLine();

            Test(nameof(Empty), Empty);
            Test(nameof(OneItem), OneItem);
            Test(nameof(Unsorted), Unsorted);
            Test(nameof(UnsortedLong), UnsortedLong);

            Console.ReadLine();
        }

        private static void Test(string testName, Func<bool> test)
        {
            var status = test() ? "OK" : "FAIL";
            Console.WriteLine($"{testName}: {status}");
        }

        private static bool Empty()
        {
            var sort = new InsertionSort<int>();
            var input = new int[] { };

            sort.Sort(input);
            return sort.IsSorted(input);
        }

        private static bool OneItem()
        {
            var sort = new InsertionSort<int>();
            var input = new int[] { 1 };

            sort.Sort(input);
            return sort.IsSorted(input);
        }

        private static bool Unsorted()
        {
            var sort = new InsertionSort<int>();
            var input = new int[] { 1, 3, 2 };

            sort.Sort(input);
            Console.WriteLine(sort.Output(input));
            return sort.IsSorted(input);
        }

        private static bool UnsortedLong()
        {
            var sort = new InsertionSort<int>();
            var input = new int[] { 1, 3, 2, 5, 10, 2, 18, 7, 3, 21, 100, 1 };

            sort.Sort(input);
            Console.WriteLine(sort.Output(input));
            return sort.IsSorted(input);
        }
    }

    public class InsertionSort<T> where T : IComparable
    {
        public void Sort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var currentValue = array[i];
                var j = i;

                for (; j > 0 && IsLess(currentValue, array[j - 1]); j--)
                {
                    array[j] = array[j - 1];
                }

                array[j] = currentValue;
            }
        }

        private bool IsLess(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }

        private void Swap(T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public bool IsSorted(T[] array)
        {
            if (array.Length <= 1)
            {
                return true;
            }

            for (int i = 1; i < array.Length; i++)
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

            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i] + " ");
            }

            return builder.ToString().Trim();
        }

    }
}
