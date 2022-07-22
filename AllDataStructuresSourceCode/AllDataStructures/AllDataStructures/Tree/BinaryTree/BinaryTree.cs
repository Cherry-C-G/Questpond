using System;
using System.Collections.Generic;
using System.Text;

namespace AllDataStructures.Tree.BinaryTree
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

    }

    public class BinaryTree
    {
        Node root = null;
        public void Insert(int data)
        {
            Node current = new Node();
            current.Data = data;

            if (root == null)
            {
                root = current;
                return;
            }






            Insert(root, current);

        }
        public void Insert(Node _root,Node newNode)
        {
            if (_root == null) return;

            if (newNode.Data < _root.Data)
            {
                if (_root.Left == null)
                {
                    _root.Left = newNode;
                }
                else
                {
                    Insert(_root.Left, newNode);
                }
            }
            else
            {
                if (_root.Right == null)
                {
                    _root.Right = newNode;
                }
                else
                {
                    Insert(_root.Right, newNode);
                }
            }
        }
        public  Node Contains(Node root, int data)
        {
            if (root == null) return null;

            if (root.Data == data) return root;

            if (root.Data >= data)
            {
              
               return  Contains(root.Left, data);
            }
            else
            {
              
               return  Contains(root.Right, data);
            }
        }
        public Node Contains(int data)
        {
            return Contains(root, data);
        }
          private void DisplayTree(Node root)
        {
            if (root == null) return;

            DisplayTree(root.Left);
            System.Console.Write(root.Data + " ");
            DisplayTree(root.Right);
        }
        public void DisplayTree()
        {
            this.DisplayTree(root);
        }
    }
}