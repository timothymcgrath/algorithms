using System;
using System.Text;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Quick Sort!");

            Test.Run(nameof(Simple), Simple);

            Test.Run(nameof(Advanced), Advanced);
        }

        static bool Simple()
        {
            var array = new int[] { 1, 5, 3, 2 };

            var sort = new QuickSort();
            sort.Sort(array);

            var expected = "1 2 3 5";
            var actual = Output(array);

            return expected.Equals(actual);
        }

        static bool Advanced()
        {
            var array = new int[] { 1, 5, 3, 2, 2, 6, 10, 8, 3, 2, 1, 78, 3, 4, 7, 1, 2, 0, 83, 2, 6, 8, 2, 3, 0, 9 };

            var sort = new QuickSort();
            sort.Sort(array);

            var expected = "0 0 1 1 1 2 2 2 2 2 2 3 3 3 3 4 5 6 6 7 8 8 9 10 78 83";
            var actual = Output(array);

            return expected.Equals(actual);
        }

        static string Output(int[] array)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
                builder.Append(" ");
            }

            return builder.ToString().Trim();
        }
    }

    public static class Test
    {
        public static void Run(string name, Func<bool> test)
        {
            var result = test() ? "OK" : "FAIL";
            Console.WriteLine($"{name}: {result}");
        }
    }

    public class QuickSort
    {

        /*
        QuickSort is another divide and conquer algorithm.

        QuickSort will sort by choosing a value, then sorting each number to the correct side 
        of that value, which in effect puts that value into its correct position.

        So, pick the first value, then walk both directions of the array and if we find an element
        on the right that is < and one on the left that is >, swap them.

        Keep swapping till the left pointer crosses the right pointer. That is the position that the
        value should be placed in.

        This will be recursive, so after splitting the array, do the same sort for each subarray until
        we get down to a single element array.
        */


        public QuickSort()
        {
        }

        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var index = array[start];

            int i = start;
            int j = end;

            while (i <= j)
            {
                if (array[i] > index && array[j] <= index)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }

                if (array[i] <= index)
                {
                    i++;
                }

                if (array[j] > index)
                {
                    j--;
                }
            }

            var tempStart = array[j];
            array[j] = index;
            array[start] = tempStart;

            Sort(array, start, j - 1);
            Sort(array, j + 1, end);
        }
    }
}
