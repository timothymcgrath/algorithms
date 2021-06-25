using System;

namespace binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Binary Search Tree!");

            Test.Run(nameof(Standard), Standard);
            Test.Run(nameof(Dupe), Dupe);
            Test.Run(nameof(Missing), Missing);

            Console.ReadLine();
        }

        public static bool Standard()
        {
            var tree = new BinarySearchTree();
            tree.Put(1, 10);
            tree.Put(4, 210);
            tree.Put(2, 130);
            tree.Put(12, 510);
            tree.Put(9, 160);
            tree.Put(6, 170);
            tree.Put(2, 150);
            tree.Put(5, 180);


            var result = tree.Get(6);
            return result == 170;
        }

        public static bool Dupe()
        {
            var tree = new BinarySearchTree();
            tree.Put(1, 10);
            tree.Put(4, 210);
            tree.Put(2, 130);
            tree.Put(12, 510);
            tree.Put(9, 160);
            tree.Put(6, 170);
            tree.Put(2, 150);
            tree.Put(5, 180);


            var result = tree.Get(2);
            return result == 150;
        }

        public static bool Missing()
        {
            var tree = new BinarySearchTree();
            tree.Put(1, 10);
            tree.Put(4, 210);
            tree.Put(2, 130);
            tree.Put(12, 510);
            tree.Put(9, 160);
            tree.Put(6, 170);
            tree.Put(2, 150);
            tree.Put(5, 180);

            var result = tree.Get(21);
            return result == -1;
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

    public class BinarySearchTree
    {
        private Node _root;

        public int Get(int key)
        {
            return Get(_root, key);
        }

        private int Get(Node node, int key)
        {
            if (node is null)
            {
                return -1;
            }

            var compare = key.CompareTo(node.Key);

            if (compare < 0)
            {
                return Get(node.Left, key);
            }
            else if (compare > 0)
            {
                return Get(node.Right, key);
            }
            else
            {
                return node.Value;
            }
        }

        public void Put(int key, int value)
        {
            _root = Put(_root, key, value);
        }

        private Node Put(Node node, int key, int value)
        {
            if (node is null)
            {
                return new Node { Key = key, Value = value, Size = 1 };
            }

            var compare = key.CompareTo(node.Key);

            if (compare < 0)
            {
                node.Left = Put(node.Left, key, value);
            }
            else if (compare > 0)
            {
                node.Right = Put(node.Right, key, value);
            }
            else if (compare == 0)
            {
                node.Value = value;
            }

            node.Size = Size(node);
            return node;
        }

        private int Size(Node node)
        {
            var size = 1;

            if (node.Left is not null)
            {
                size += node.Left.Size;
            }
            
            if (node.Right is not null)
            {
                size += node.Right.Size;
            }

            return size;
        }



        private class Node
        {
            public Node Left;
            public Node Right;
            public int Key;
            public int Value;

            public int Size;
        }

    }
}
