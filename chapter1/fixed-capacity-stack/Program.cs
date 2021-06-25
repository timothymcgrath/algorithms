using System;
using System.Text;

namespace Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new FixedCapacityStack(3);

            Test.Run(nameof(Empty), Empty);
            Test.Run(nameof(AddThenEmpty), AddThenEmpty);
            Test.Run(nameof(Add3), Add3);
            Test.Run(nameof(Add3Pop1), Add3Pop1);
            Test.Run(nameof(EmptyIsFull), Add3Pop1);
            Test.Run(nameof(ThreeIsFull), Add3Pop1);
            Test.Run(nameof(TwoIsNotFull), Add3Pop1);

            Console.ReadLine();
        }

        static bool Empty()
        {
            var stack = new FixedCapacityStack(0);

            var actual = stack.Output();
            var expected = "";

            return expected == actual;
        }

        static bool AddThenEmpty()
        {
            var stack = new FixedCapacityStack(3);

            stack.Push(10);
            stack.Pop();
            var actual = stack.Output();
            var expected = "";

            return expected == actual;
        }

        static bool Add3()
        {
            var stack = new FixedCapacityStack(3);

            stack.Push(10);
            stack.Push(1);
            stack.Push(2);
            var actual = stack.Output();
            var expected = "2 1 10";

            return expected == actual;
        }

        static bool Add3Pop1()
        {
            var stack = new FixedCapacityStack(3);

            stack.Push(10);
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            var actual = stack.Output();
            var expected = "1 10";

            return expected == actual;
        }
        
        static bool EmptyIsFull()
        {
            var stack = new FixedCapacityStack(0);

            var actual = stack.IsFull();
            var expected = true;

            return expected == actual;
        }
        
        static bool ThreeIsFull()
        {
            var stack = new FixedCapacityStack(3);
         
            stack.Push(10);
            stack.Push(1);
            stack.Push(2);

            var actual = stack.IsFull();
            var expected = true;

            return expected == actual;
        }

        
        static bool TwoIsNotFull()
        {
            var stack = new FixedCapacityStack(3);
         
            stack.Push(10);
            stack.Push(1);

            var actual = stack.IsFull();
            var expected = false;

            return expected == actual;
        }
    }

    static class Test
    {
        public static void Run(string name, Func<bool> test)
        {
            var status = test() ? "OK" : "FAIL";
            
            Console.WriteLine();
            Console.WriteLine($"{name}: {status}");
        }
    }

    public class FixedCapacityStack
    {
        private int[] _array;
        private int _size;

        public FixedCapacityStack(int capacity)
        {
            _array = new int[capacity];
        }

        public void Push(int value)
        {
            if (IsFull())
            {
                throw new Exception();
            }

            _array[_size++] = value;
        }

        public int? Pop()
        {
            if (_size == 0)
            {
                return null;
            }

            return _array[--_size];
        }

        public bool IsFull()
        {
            return _size == _array.Length;
        }

        public string Output()
        {    
            var builder = new StringBuilder();

            for (int i = _size - 1; i >= 0; i--)
            {
                builder.Append(_array[i] + " ");
            }

            return builder.ToString().Trim();
        }
    }
}