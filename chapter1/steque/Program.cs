using System;
using System.Text;

namespace steque
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Steque!");


            Test.Run(nameof(AddStuff), AddStuff);
            Test.Run(nameof(RemoveStuff), RemoveStuff);
            Test.Run(nameof(RemoveAll), RemoveAll);
        }

        static bool AddStuff()
        {
            var steque = new Steque();

            steque.Push(1);
            steque.Push(2);
            steque.Push(3);
            steque.Push(4);
            steque.Enqueue(5);
            steque.Push(6);

            var expected = "6 4 3 2 1 5";
            var actual = steque.Output();

            return expected.Equals(actual);
        }

        static bool RemoveStuff()
        {
            var steque = new Steque();

            steque.Push(1);
            steque.Push(2);
            steque.Push(3);
            steque.Push(4);
            steque.Enqueue(5);
            steque.Push(6);

            steque.Pop();
            steque.Pop();
            steque.Pop();

            var expected = "2 1 5";
            var actual = steque.Output();

            return expected.Equals(actual);
        }
        
        static bool RemoveAll()
        {
            var steque = new Steque();

            steque.Push(1);
            steque.Push(2);
            steque.Push(3);
            steque.Push(4);
            steque.Enqueue(5);
            steque.Push(6);

            steque.Pop();
            steque.Pop();
            steque.Pop();
            steque.Pop();
            steque.Pop();
            steque.Pop();

            var expected = "";
            var actual = steque.Output();

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

    public class Steque
    {
        /*
            A Steque is a stack with push/pop but also enqueue.
            So, you always read from the top, but you can push to the top or enqueue to the back.


            To build this with a linked-list, implement the traditional stack. But maintain a pointer
            on the end of the stack. The enqueue will allow a value to be added at the end instead of the front.
        */

        private Node _head;
        private Node _tail;

        private int _size;

        public void Push(int value)
        {
            if (_head is null)
            {
                _head = new Node(value, null);
                _tail = _head;

                _size++;
                return;
            }

            var newNode = new Node(value, _head);
            _head = newNode;
        }

        public int? Pop()
        {
            if (_head is not null)
            {
                var node = _head;
                _head = node.Next;

                _size--;
                return node.Value;
            }

            return null;
        }

        public void Enqueue(int value)
        {
            if (_head is null)
            {
                _head = new Node(value, null);
                _tail = _head;

                _size++;
                return;
            }

            var newNode = new Node(value, null);
            _tail.Next = newNode;
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

            public Node(int value, Node next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
