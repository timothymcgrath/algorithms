using System;

namespace exercise137
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Stack<T>
    {
        private class Node
        {
            public T Item;
            public Node Next;
        }

        private Node _first;
        private int _count;

        public bool IsEmpty
        {
            get
            {
                return _count == 0;
            }
        }

        public int Size
        {
            get
            {
                return _count;
            }
        }

        public void Push(T item)
        {
            var oldFirst = _first;
            
            var newFirst = new Node();
            newFirst.Item = item;
            newFirst.Next = oldFirst;
            _count++;
            _first = newFirst;
        }

        public T Pop()
        {
            var oldFirst = _first;

            _first = oldFirst.Next;
            _count--;
            return oldFirst.Item;
        }

        public T Peek()
        {
            return _first.Item;
        }
    }
}