using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.LinkList.Double
{
    public class DoubleLinkList<T>
    {
        Node<T> head = null;
        Node<T> tail = null;

        public void AddLast(T data)
        {
            Node<T> newItem = new Node<T>();
            newItem.data = data;
            if (head == null)
            {
                head = newItem;
            }
            else
            {
                tail.next = newItem;
                newItem.prev = tail;
            }
            tail = newItem;
        }
       
        public void ReadAll()
        {
            Node<T> current = head;
            while (current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;

            }
            Console.WriteLine(current.data);
        }
        public void ReadReverse()
        {
            Node<T> current = tail;
            while (current.prev != null)
            {
                Console.WriteLine(current.data);
                current = current.prev;

            }
            Console.WriteLine(current.data);
        }
    }
    public class Node<T>
    {
        public T data;
        public Node<T> next = null;
        public Node<T> prev = null;

    }
}
