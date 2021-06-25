using System;
using System.Text;

namespace odds_evens
{
    class Program
    {
        // 1, 12, 5, 6, 3, 10, 9
        // 1, 6, 3, 10, 5, 12, 9

        // Loop through the array. 
        // Keep separate variables for position odd and even.
        // On each pass, find the smallest value, and put it into the correct location of odd or even.
        // Make sure to skip anything odd -2 or even -2.

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Odd Even Sort!");

            Test.Run(nameof(Empty), Empty);
            Test.Run(nameof(Standard), Standard);

            Console.ReadLine();
        }

        static bool Empty()
        {
            var input = new int[] { };
            var sort = new OddEvenSort();

            sort.Sort(input);

            var expected = new int[] { };
            return sort.AreEqual(input, expected);
        }

        static bool Standard()
        {
            var input = new int[] { 1, 12, 5, 6, 3, 10, 9 };
            var sort = new OddEvenSort();

            sort.Sort(input);
            var expected = new int[] { 1, 6, 3, 10, 5, 12, 9 };
            return sort.AreEqual(input, expected);
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

    public class OddEvenSort
    {
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var minIndex = i;

                for (int j = 0; j < array.Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (array[minIndex] % 2 != 0 || (array[j] < array[minIndex]))
                        {
                            minIndex = j;
                        }
                    }
                    else
                    {
                        if (array[minIndex] % 2 == 0 || (array[j] < array[minIndex]))
                        {
                            minIndex = j;
                        }
                    }

                    if (i != minIndex)
                    {
                        Swap(array, i, minIndex);
                    }
                }
            }
        }

        public bool AreEqual(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i].Equals(array2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public void Output(int[] array)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                builder.Append(array[i]);
            }

            Console.WriteLine(builder.ToString());
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
