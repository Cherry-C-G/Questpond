using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.LinkList.Simple
{
    // Step 2 :- Create Link List class
    public class SimpleLinkList
    {
        // Step 3 :- Create head object
        Node head = null;
        // Step 7 :- Tail
        Node tail = null;
        // Step 4 :- Create Add Last
        public void AddLast(object data)
        {
            Node newitem = new Node();
            newitem.data = data;
            // Step 5 :- Write logic to set the head
            // when its first time
            if (head == null)
            {
                head = newitem;
                tail = head;
            }
            else
            {
                // Step 6 :- Add if there is a head
                // Node current = head;
                //while (current.next != null)
                //{
                //    current = current.next;
                //}
                //current.next = newitem;
                //newitem.next = null;
                // Step 7 :- Converting performance 0(1)
                tail.next = newitem;
                tail = newitem;

            }
        }
       

        // Step 7 
        public void AddFirst(object data)
        {
            Node newitem = new Node();
            newitem.data = data;
            newitem.next = head;
            head = newitem;
        }
        // Step 8 
        public void ReadAll()
        {
            Node current = head;
            while (current.next != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
                
            }
            Console.WriteLine(current.data);
        }
    }
    // Step 1 :- Create the node class

    public class Node
    {
        public object data = null;
        public Node next = null;
    }

}
