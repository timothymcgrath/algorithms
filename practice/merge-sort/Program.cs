using System;
using System.Text;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Merge Sort!");

            Test.Run(nameof(Simple), Simple);

            Test.Run(nameof(Advanced), Advanced);
        }

        static bool Simple()
        {
            var array = new int[] { 1, 5, 3, 2 };

            var sort = new MergeSort();
            sort.Sort(array);

            var expected = "1 2 3 5";
            var actual = Output(array);

            return expected.Equals(actual);
        }

        static bool Advanced()
        {
            var array = new int[] { 1, 5, 3, 2, 2, 6, 10, 8, 3, 2, 1, 78, 3, 4, 7, 1, 2, 0, 83, 2, 6, 8, 2, 3, 0, 9 };

            var sort = new MergeSort();
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

    public class MergeSort
    {
        private int[] _temp;

        /*
        Merge Sort works by divide and conquer strategy. 
        Take the array and keep breaking it in half until we're down to two elements. Then order those
        elements by choosing the lower of the two. Keep doing this until that array is in order.
        Then recursively it will merge together as it is undone.
        To do this we will need to track the start, the end, and the mid-point of each subarray.

        Start by recursively breaking it in half... once we are down to two elements, start the ordering
        process. 
        Copy the array to the temp array.
        Walk the two arrays and select the lowest and put it into position on the array.
        Stop when we have visited all elements of the array.
        */


        public MergeSort()
        {
            _temp = new int[100];
        }

        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int start, int end)
        {
            var mid = start + ((end - start) / 2);

            if (mid >= start + 1)
            {
                Sort(array, start, mid);
            }

            if (end >= mid + 2)
            {
                Sort(array, mid + 1, end);
            }

            for (int i = start; i <= end; i++)
            {
                _temp[i] = array[i];
            }

            var placeholder = start;
            int left = start;
            int right = mid + 1;

            while (true)
            {
                if (left == mid + 1 && right == end + 1)
                {
                    return;
                }

                if (right > end)
                {
                    array[placeholder] = _temp[left];
                    left++;
                    placeholder++;
                    continue;
                }

                if (left > mid)
                {
                    array[placeholder] = _temp[right];
                    right++;
                    placeholder++;
                    continue;
                }

                if (_temp[left] <= _temp[right])
                {
                    array[placeholder] = _temp[left];
                    left++;
                    placeholder++;
                    continue;
                }

                if (_temp[right] < _temp[left])
                {
                    array[placeholder] = _temp[right];
                    right++;
                    placeholder++;
                    continue;
                }
            }
        }
    }
}
