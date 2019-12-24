using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib.Algorithm
{
    public class Node<T>
    {
        private T content;
        private Node<T> nextNode;
        private Node<T> prevNode;

        public Node(T value,Node<T> next,Node<T> prev )
        {
            content = value;
            nextNode = next;
            prevNode = prev;
        }
    }

    public class LRUAlgorithm<T>
    {
        //private int[] array = new[] {4, 5, 6, 7, 8, 4, 5, 8, 9};

        private Node<T> top = null;
        private Node<T> bottom = null;

        public void InsertElement(T item)
        {
            if (bottom == null)
                bottom = new Node<T>(item, null, null);


        }
    }
}
