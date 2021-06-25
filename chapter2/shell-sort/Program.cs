using System;
using System.Text;

namespace shell_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Shell Sort!");
            Console.WriteLine();

            Test(nameof(Empty), Empty);
            Test(nameof(Standard), Standard);

            Console.ReadLine();
        }

        static void Test(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{name}: {result}");
        }

        static bool Empty()
        {
            var input = new int[] { };
            var sort = new ShellSort<int>();

            sort.Sort(input);
            return sort.IsSorted(input);
        }

        static bool Standard()
        {
            var input = new int[] { 1, 6, 3, 8, 9, 2, 4, 8, 9, 2, 1, 4, 7, 3, 8, 9, 0, 1, 4, 8, 2, 3, 4, 7, 5, 3, 2, 7, 3, 4, 1 };
            var sort = new ShellSort<int>();

            sort.Sort(input);
            return sort.IsSorted(input);
        }
    }

    public class ShellSort<T> where T : IComparable
    {
        public void Sort(T[] array)
        {
            int length = array.Length;
            int h = 1;

            while (h < length / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < length; i++)
                {
                    for (int j = i; j >= h && IsLess(array[j], array[j - h]); j -= h)
                    {
                        Swap(array, j, j - h);
                    }
                }

                h = h / 3;
            }
        }

        private void Swap(T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = array[index1];
        }

        public string Output(T[] array)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
            }

            return builder.ToString().Trim();
        }

        private bool IsLess(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
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
    }
}
