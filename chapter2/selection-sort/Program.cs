using System;

namespace selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Selection Sort!!");

            Test(nameof(StandardSortTest), () => StandardSortTest());
            Test(nameof(PresortedTest), () => PresortedTest());
            Test(nameof(SingleElementTest), () => SingleElementTest());

            Console.ReadLine();
        }

        static void Test(string testName, Func<bool> test)
        {
            Console.WriteLine();

            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{testName}: {result}");
        }

        static bool StandardSortTest()
        {
            var input = new int[] { 1, 3, 2, 6, 4 };

            var sort = new SelectionSort<int>();
            sort.Sort(input);

            return sort.IsSorted(input);
        }

        static bool PresortedTest()
        {
            var input = new int[] { 1, 2, 3, 4, 5, 6 };

            var sort = new SelectionSort<int>();
            sort.Sort(input);

            return sort.IsSorted(input);
        }
        
        static bool SingleElementTest()
        {
            var input = new int[] { 1 };

            var sort = new SelectionSort<int>();
            sort.Sort(input);

            return sort.IsSorted(input);
        }
    }



    public class SelectionSort<T> where T : IComparable
    {
        public void Sort(T[] array)
        {
            if (array.Length == 1)
            {
                return;
            }

            for (var i = 0; i < array.Length; i++)
            {
                var min = i;

                for (var j = i + 1; j < array.Length; j++)
                {
                    if (IsLess(array[j], array[min]))
                    {
                        min = j;
                    }
                }

                Swap(array, i, min);
            }
        }

        public string Output(T[] array)
        {
            var builder = new System.Text.StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
            }

            return builder.ToString();
        }

        public bool IsSorted(T[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                if (!IsLess(array[i - 1], array[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsLess(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }

        private void Swap(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
