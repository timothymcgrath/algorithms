using System;
using System.Text;

namespace resizing_array_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Resizing Array Queue!");

            var queue = new Queue(4);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);

            Console.WriteLine(queue.Output());

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Console.WriteLine(queue.Output());

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);

            queue.Enqueue(21);
            queue.Enqueue(22);
            queue.Enqueue(23);
            
            queue.Enqueue(31);
            queue.Enqueue(32);
            queue.Enqueue(33);
            
            queue.Enqueue(41);
            queue.Enqueue(42);
            queue.Enqueue(43);

            Console.WriteLine(queue.Output());

            Console.ReadLine();
        }
    }

    public class Queue
    {

        /*
            Because a queue removes from the front, this is trickier than a stack.
            Our data is going to rotate around the queue. 

            We'll need to have a pointer to the front of the queue.
            And a pointer to the tail fo the queue will be useful too.

            When we enqueue, we'll add to the tail.
            When we dequeue, we'll return from the head and bump the head forward.

            Everytime we hit the end of the array, we'll need to jump the head or tail to the front of the array.

            Store count separately for simplicity.
        */

        private int[] _array;

        private int _head;
        private int _tail;
        private int _size;

        public Queue(int capacity)
        {
            _array = new int[capacity];
        }

        public void Enqueue(int value)
        {
            if (_size != 0)
            {
                _tail = Increment(_tail);
            }

            _array[_tail] = value;
            _size++;

            CheckSize();
        }

        public int Dequeue()
        {
            var value = _array[_head];

            _head = Increment(_head);
            _size--;

            CheckSize();

            return value;
        }

        public string Output()
        {
            var builder = new StringBuilder();

            for (int i = 0, pointer = _head; i < _size; i++, pointer = Increment(pointer))
            {
                builder.Append(_array[pointer] + " ");
            }

            return builder.ToString().Trim();
        }

        private void CheckSize()
        {
            if ((double)_size / _array.Length > 0.80)
            {
                Resize(_array.Length * 2);
                return;
            }

            if ((double)_size / _array.Length < 0.25)
            {
                Resize(_array.Length / 2);
                return;
            }
        }

        private void Resize(int newSize)
        {
            // if (newSize <= 4)
            // {
            //     return;
            // }

            var newArray = new int[newSize];

            for (int i = 0, pointer = _head; i < _size; i++, pointer = Increment(pointer))
            {
                newArray[i] = _array[pointer];
            }

            _head = 0;
            _tail = _size - 1;

            _array = newArray;
        }

        private int Increment(int pointer)
        {
            if (pointer + 1 == _array.Length)
            {
                return 0;
            }

            return pointer + 1;
        }
    }
}
