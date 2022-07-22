using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.LinkList.QueueStackCustom
{
    // Queue - FIFO
    // Stack - LIFO
    public class Node
    {
        public int data;
        public Node next; // next node

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }
    public class LinkListStack
    {
        Node top; // top node

        public LinkListStack()
        {
            this.top = null;
        }
        public void Push(int value)
        {
            Node newNode = new Node(value);
            if (top == null)
            {
                top = newNode;
                newNode.next = null; 
            }
            else
            {
                newNode.next = top;
                top = newNode;
                
            }
            
            Console.WriteLine("{0} pushed to stack", value);
        }

        public void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow. Deletion not possible");
                return;
            }

            Console.WriteLine("Item popped is {0}", top.data);
            top = top.next; // next of the top becomes top
        }
        public void Peek()
        {
            if (top == null)
            {
                Console.WriteLine("Stack Underflow.");
                return;
            }

            Console.WriteLine("{0} is on the top of Stack", this.top.data);
        }
    }
    internal class LinkListQueue
    {
        Node head;

        public LinkListQueue()
        {
            this.head  = null;
        }
        public void Enqueue(int item)
        {
            Node newNode = new Node(item);

            // If queue is empty, then new node is front and rear both  
            if (this.head == null)
            {
                this.head  = newNode;
            }
            else
            {
                // Add the new node at the end of queue and change rear  
                this.head.next = newNode;
            }
            Console.WriteLine("{0} inserted into Queue", item);
        }

        public void Dequeue()
        {
            // If queue is empty, return NULL.  
            if (this.head == null)
            {
                Console.WriteLine("The Queue is empty");
                return;
            }

            // Store previous front and move front one node ahead  
            Node temp = this.head;
            this.head = this.head.next;

           

            Console.WriteLine("Item deleted is {0}", temp.data);
        }
    }


}
