using System;
using System.Text;

namespace reverse_sort_zeros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Challenge!");



            /*


            
                    Array of non-negative numbers. 
                    Reverse but put all the zeroes at the end.
                    O(n) in time. O(1) for space.

                    Reversing the array is easy...
                    One pointer at the front, one pointer at the tail. 

                    We can only iterate the array once.

                    We could have an extra set of pointers fo the placement on each end.
                    So, if we hit a zero, lock the pointer there for placement, but keep incrementing the other
                    pointer for swaps. So, the position we place it in is different than the one we compare.

                    However, it doesn't work on the right, it will still remain gapped.

                    We could shift everything left at the end? But that will grow as the size of the array grows.
                    We could minimize that by doing the above but only when i crosses j and just start shifting when we hit a zero.


                    Iterate over the array, with two pointers, one to track what we're looking at, and one for placing.
                    When we find a zero, move the tracking pointer forward. Increment the zero count by 1.
                    When we find a non-zero, move it to the placing pointer and increment that pointer.

                    Then reverse the array, with double pointers swapping positions.
                    When they are equal, stop the loop.

                    Then add the 0's to length - number of zeroes.

            */

            StandardTest();
            EmptyTest();
            AllZeroesTest();

            Console.ReadLine();
        }

        public static void StandardTest()
        {
            var input = new int[] { 0, 4, 2, 3, 0, 9, 10, 0, 34, 8, 0, 23, 56, 12 };

            var sort = new Reverse();
            sort.Run(input);

            var expected = new int[] { 12, 56, 23, 8, 34, 10, 9, 3, 2, 4, 0, 0, 0, 0 };

            var result = AreEqual(input, expected);

            var resultText = result ? "OK" : "FAIL";
            Console.WriteLine($"{nameof(StandardTest)}: {resultText}");
            Console.WriteLine();
            Console.WriteLine($"E: {Output(expected)}");
            Console.WriteLine($"A: {Output(input)}");

            Console.WriteLine();
            Console.WriteLine();
        }
        
        public static void EmptyTest()
        {
            var input = new int[] { };

            var sort = new Reverse();
            sort.Run(input);

            var expected = new int[] { };

            var result = AreEqual(input, expected);

            var resultText = result ? "OK" : "FAIL";
            Console.WriteLine($"{nameof(EmptyTest)}: {resultText}");
            Console.WriteLine();
            Console.WriteLine($"E: {Output(expected)}");
            Console.WriteLine($"A: {Output(input)}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void AllZeroesTest()
        {
            var input = new int[] { 0, 0, 0, 0 };

            var sort = new Reverse();
            sort.Run(input);

            var expected = new int[] { 0, 0, 0, 0 };

            var result = AreEqual(input, expected);

            var resultText = result ? "OK" : "FAIL";
            Console.WriteLine($"{nameof(AllZeroesTest)}: {resultText}");
            Console.WriteLine();
            Console.WriteLine($"E: {Output(expected)}");
            Console.WriteLine($"A: {Output(input)}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static bool AreEqual(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string Output(int[] array)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(array[i] + " ");
            }

            return builder.ToString();
        }
    }


    public class Reverse
    {
        private int _zeroes;

        public void Run(int[] array)
        {
            if (array.Length == 0)
            {
                return;
            }

            RemoveZeroes(array);

            if (_zeroes == array.Length)
            {
                return;
            }

            ReverseArray(array);
            AddZeroes(array);
        }

        private void RemoveZeroes(int[] array)
        {
            int put = 0;
            for (int seek = 0; seek < array.Length; seek++)
            {
                if (array[seek] != 0)
                {
                    array[put] = array[seek];
                    put++;
                }
                else
                {
                    _zeroes++;
                }
            }
        }

        private void ReverseArray(int[] array)
        {
            var end = array.Length - 1 - _zeroes;

            for (int i = 0; i <= end / 2; i++)
            {
                var tmp = array[i];
                array[i] = array[end - i];
                array[end - i] = tmp;
            }
        }

        private void AddZeroes(int[] array)
        {
            for (int i = array.Length - _zeroes; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
    }
}
