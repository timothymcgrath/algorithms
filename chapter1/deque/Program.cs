using System;
using System.Text;

namespace deque
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Deque!");


            Test.Run(nameof(AddStuff), AddStuff);
            Test.Run(nameof(AddStuff2), AddStuff2);
            Test.Run(nameof(RemoveStuff), RemoveStuff);
            Test.Run(nameof(RemoveAll), RemoveAll);
            Test.Run(nameof(RemoveAll2), RemoveAll2);
            Test.Run(nameof(RemoveAll3), RemoveAll3);



            
            Test.Run(nameof(AddStuffResize), AddStuffResize);
            Test.Run(nameof(AddStuff2Resize), AddStuff2Resize);
            Test.Run(nameof(RemoveStuffResize), RemoveStuffResize);
            Test.Run(nameof(RemoveAllResize), RemoveAllResize);
            Test.Run(nameof(RemoveAll2Resize), RemoveAll2Resize);
            Test.Run(nameof(RemoveAll3Resize), RemoveAll3Resize);
        }

        static bool AddStuff()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushLeft(4);
            deque.PushLeft(5);
            deque.PushLeft(6);

            var expected = "6 5 4 3 2 1";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool AddStuff2()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            var expected = "6 3 2 1 4 5";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveStuff()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopRight();

            var expected = "3 2 1 4";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAll()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAll2()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAll3()
        {
            var deque = new Deque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopRight();
            deque.PopLeft();
            deque.PopRight();
            deque.PopLeft();
            deque.PopRight();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
        }





        
        static bool AddStuffResize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushLeft(4);
            deque.PushLeft(5);
            deque.PushLeft(6);

            var expected = "6 5 4 3 2 1";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool AddStuff2Resize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            var expected = "6 3 2 1 4 5";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveStuffResize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopRight();

            var expected = "3 2 1 4";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAllResize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();
            deque.PopLeft();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAll2Resize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();
            deque.PopRight();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveAll3Resize()
        {
            var deque = new ResizingArrayDeque();

            deque.PushLeft(1);
            deque.PushLeft(2);
            deque.PushLeft(3);
            deque.PushRight(4);
            deque.PushRight(5);
            deque.PushLeft(6);

            deque.PopLeft();
            deque.PopRight();
            deque.PopLeft();
            deque.PopRight();
            deque.PopLeft();
            deque.PopRight();

            var expected = "";
            var actual = deque.Output();

            return expected.Equals(actual);
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



    public class ResizingArrayDeque
    {
        private int[] _array = new int[4];

        private int _head;
        private int _tail;

        private int _size = 0;

        public void PushLeft(int value)
        {
            if (_size == 0)
            {
                AddInitial(value);
                return;
            }

            var previousIndex = GetPreviousIndex(_head);
            _array[previousIndex] = value;
            _head = previousIndex;

            _size++;
            CheckResize();
        }

        public void PushRight(int value)
        {
            if (_size == 0)
            {
                AddInitial(value);
                return;
            }

            var nextIndex = GetNextIndex(_tail);
            _array[nextIndex] = value;
            _tail = nextIndex;

            _size++;
            CheckResize();
        }

        private int GetPreviousIndex(int index)
        {
            if (index == 0)
            {
                return _array.Length - 1;
            }

            return index - 1;
        }

        private int GetNextIndex(int index)
        {
            if (index == _array.Length - 1)
            {
                return 0;
            }

            return index + 1;
        }

        private void AddInitial(int value)
        {
            _array[0] = value;
            _head = 0;
            _tail = 0;

            _size++;
        }

        public int? PopLeft()
        {
            if (_size == 0)
            {
                return null;
            }

            var value = _array[_head];
            _head = GetNextIndex(_head);

            _size--;
            CheckResize();

            return value;
        }

        public int? PopRight()
        {
            if (_size == 0)
            {
                return null;
            }

            var value = _array[_tail];
            _tail = GetPreviousIndex(_tail);

            _size--;
            CheckResize();

            return value;
        }

        public string Output()
        {
            var builder = new StringBuilder();

            for (int i = _head; i != GetNextIndex(_tail); i = GetNextIndex(i))
            {
                builder.Append(_array[i]);
                builder.Append(" ");
            }

            return builder.ToString().Trim();
        }

        private void CheckResize()
        {
            if (_size <= 2)
            {
                return;
            }

            if (_size > (_array.Length * 0.5))
            {
                Resize(_array.Length * 2);
                return;
            }

            if (_size < (_array.Length * 0.25))
            {
                Resize(_array.Length / 2);
                return;
            }
        }

        private void Resize(int size)
        {
            var newArray = new int[size];

            for (int i = _head, j = 0; i != _tail + 1; i = GetNextIndex(i), j++)
            {
                newArray[j] = _array[i];
            }

            _array = newArray;
            _head = 0;
            _tail = _size - 1;
        }
    }



    public class Deque
    {
        /*
            A Dequeue is a double-ended queue, where items can be pushed and popped on both sides of the deque.
        */

        private Node _head;
        private Node _tail;

        private int _size;

        public void PushLeft(int value)
        {
            if (_head is null)
            {
                AddInitial(value);
                return;
            }

            var node = new Node(value, _head, null);
            _head.Previous = node;
            _head = node;
        }

        public void PushRight(int value)
        {
            if (_tail is null)
            {
                AddInitial(value);
                return;
            }

            var node = new Node(value, null, _tail);
            _tail.Next = node;
            _tail = node;
        }

        private void AddInitial(int value)
        {
            var node = new Node(value, null, null);
            _head = node;
            _tail = node;
        }

        public int? PopLeft()
        {
            if (_head is null)
            {
                return null;
            }

            var node = _head;
            _head = node.Next;

            if (_head is not null)
            {
                _head.Previous = null;
            }
            else
            {
                _tail = null;
            }

            return node.Value;
        }

        public int? PopRight()
        {
            if (_tail is null)
            {
                return null;
            }

            var node = _tail;
            _tail = node.Previous;

            if (_tail is not null)
            {
                _tail.Next = null;
            }
            else
            {
                _head = null;
            }

            return node.Value;
        }

        public string Output()
        {
            var builder = new StringBuilder();

            for (var node = _head; node != null; node = node.Next)
            {
                builder.Append(node.Value);
                builder.Append(" ");
            }

            return builder.ToString().Trim();
        }

        public class Node
        {
            public int Value;
            public Node Next;
            public Node Previous;

            public Node(int value, Node next, Node previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }
    }
}
