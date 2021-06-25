using System;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Quick Sort!");

            Test.Run(nameof(Empty), Empty);
            Test.Run(nameof(Standard), Standard);

            Console.ReadLine();
        }

        static bool Empty()
        {
            var input = new int[] { };

            var sort = new QuickSort();
            sort.Sort(input);

            return sort.IsSorted(input);
        }


        static bool Standard()
        {
            var input = new int[] { 1, 3, 7, 2, 3, 1, 7, 3, 2, 7, 8, 4, 3, 4, 9, 0, 10, 1, 2, 3 };

            var sort = new QuickSort();
            sort.Sort(input);

            sort.Output(input);

            return sort.IsSorted(input);
        }
    }

    static class Test
    {
        public static void Run(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "Fail";
            Console.WriteLine($"{name}: {result}");
        }
    }

    public class QuickSort
    {
        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int partition = Partition(array, low, high);
            Sort(array, low, partition - 1);
            Sort(array, partition + 1, high);
        }

        private int Partition(int[] array, int low, int high)
        {
            int i = low;
            int j = high + 1;

            int value = array[low];

            while (true)
            {
                while (++i <= high && IsLess(array[i], value))
                { }

                while (--j >= low && IsLess(value, array[j]))
                { }

                if (i >= j)
                {
                    break;
                }

                Swap(array, i, j);
            }

            Swap(array, low, j);
            return j;
        }

        public bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (IsLess(array[i], array[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        public void Output(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        private void Swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private bool IsLess(int value1, int value2)
        {
            return value1.CompareTo(value2) < 0;
        }
    }
}
