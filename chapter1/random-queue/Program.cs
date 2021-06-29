using System;
using System.Collections.Generic;
using System.Text;

namespace random_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Random Queue!");


            for (int i = 0; i < 3; i++)
            {
                var queue = new RandomQueue(4);

                queue.Enqueue(1);
                queue.Enqueue(2);
                queue.Enqueue(3);
                queue.Enqueue(4);
                queue.Enqueue(5);
                queue.Enqueue(6);
                queue.Enqueue(7);
                queue.Enqueue(8);

                foreach (var item in queue.Iterate())
                {
                    Console.Write(item);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class RandomQueue
    {
        private int[] _array;

        private int _head;
        private int _tail;
        private int _size;

        private Random _random = new Random();

        public RandomQueue(int capacity)
        {
            _array = new int[capacity];
        }

        public bool IsEmpty()
        {
            return _size == 0;
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
            var position = GetRandom();

            var value = _array[position];
            _array[position] = _array[_tail];
            _array[_tail] = value;

            _tail = Decrement(_tail);
            _size--;

            CheckSize();

            return value;
        }

        public int Sample()
        {
            var position = GetRandom();

            return _array[position];
        }

        public IEnumerable<int> Iterate()
        {
            var items = new List<int>();

            while (_size != 0)
            {
                items.Add(Dequeue());
            }

            return items;
        }


        private int GetRandom()
        {
            var rand = _random.Next(_size - 1);

            var position = _head + rand;

            if (position < _tail)
            {
                return position;
            }
            else
            {
                return _head + (position - _tail);
            }
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

        private int Decrement(int pointer)
        {
            if (pointer - 1 == 0)
            {
                return _array.Length - 1;
            }

            return pointer - 1;
        }
    }
}
