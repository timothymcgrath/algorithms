using System;
using System.Text;

namespace generalized_queue
{

    /*
    The GeneralizedQueue allows you to get and remove an item from any position in the queue.
    The array version pays the performance cost of needing to shift every element after the position on each removal.
    The linked list version has to walk the array to the position-th element on each removal.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Generalized Queue!");

            Test.Run(nameof(ArrayTest), ArrayTest);
            Test.Run(nameof(LinkedListTest), LinkedListTest);
            Test.Run(nameof(LinkedListDeleteHeadTest), LinkedListDeleteHeadTest);

            Console.ReadLine();
        }

        public static bool ArrayTest()
        {
            var queue = new GeneralizedQueueArray(100);
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(3);
            queue.Insert(4);

            queue.Delete(3);
            queue.Delete(0);

            var actual = queue.Output();
            var expected = "2 3";

            return actual == expected;
        }

        public static bool LinkedListTest()
        {
            var queue = new GeneralizedQueueLinkedList();
            queue.Insert(1);
            queue.Insert(2);
            queue.Insert(3);
            queue.Insert(4);

            queue.Delete(3);
            queue.Delete(0);

            var actual = queue.Output();
            var expected = "2 3";

            return actual == expected;
        }

        
        public static bool LinkedListDeleteHeadTest()
        {
            var queue = new GeneralizedQueueLinkedList();
            queue.Insert(1);
            queue.Insert(2);

            queue.Delete(0);
            queue.Delete(0);

            var actual = queue.Output();
            var expected = "";

            return actual == expected;
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

    public class GeneralizedQueueArray
    {
        private int _size;

        private int[] _array;

        public GeneralizedQueueArray(int size)
        {
            _array = new int[size];
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Insert(int value)
        {
            _array[_size] = value;
            _size++;
        }

        public int Delete(int position)
        {
            var value = _array[position];

            for (int i = position; i < _size; i++)
            {
                _array[i] = _array[i + 1];
            }

            _size--;
            return value;
        }

        public string Output()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < _size; i++)
            {
                builder.Append(_array[i]);
                builder.Append(" ");
            }

            return builder.ToString().Trim();
        }
    }

    public class GeneralizedQueueLinkedList
    {
        private int _size;

        private Node _head;
        private Node _tail;

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Insert(int value)
        {
            if (_size == 0)
            {
                _head = new Node(value, null);
                _tail = _head;
                _size++;
                return;
            }

            _tail.Next = new Node(value, null);
            _tail = _tail.Next;
            _size++;
        }

        public int Delete(int position)
        {
            if (position == 0)
            {
                var node = _head;
                _head = node.Next;
                _size--;

                if (_size == 0)
                {
                    _tail = null;
                }

                return node.Value;
            }
            else
            {
                var previousNode = _head;

                for (int i = 0; i < position - 1; i++)
                {
                    if (previousNode is null)
                    {
                        throw new InvalidOperationException();
                    }

                    previousNode = previousNode.Next;
                }

                var node = previousNode.Next;
                previousNode.Next = node.Next;
                _size--;

                return node.Value;
            }
        }

        public string Output()
        {
            var builder = new StringBuilder();

            var node = _head;

            while (node != null)
            {
                builder.Append(node.Value);
                builder.Append(" ");

                node = node.Next;
            }

            return builder.ToString().Trim();
        }

        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
