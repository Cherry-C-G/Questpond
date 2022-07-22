using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.Others
{
    class FlyodLoopDetection
    {
        Node Head;

        public class Node
        {
            public int value;
            public Node NextNode;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public FlyodLoopDetection(Node head)
        {
            this.Head = head;
        }
        public FlyodLoopDetection()
        {
            
        }


        public Boolean hasLoop()
        {
            Node tempNode = Head;
            Node tempNode1 = Head.NextNode;
            while (tempNode != null && tempNode1 != null)
            {
                // if any time the nodes are equal
                if (tempNode.Equals(tempNode1))
                {
                    return true;
                }

                if ((tempNode1.NextNode != null) && (tempNode.NextNode != null))
                {
                    tempNode1 = tempNode1.NextNode.NextNode; // 2 steps
                    tempNode = tempNode.NextNode; // one step
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public  void Start()
        {
            Node head = new Node(1);
            FlyodLoopDetection ll = new FlyodLoopDetection(head);

            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            

            head.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;
            node4.NextNode = node3;
          

            Console.WriteLine(ll.hasLoop());
            Console.Read();
        }
    }
}
