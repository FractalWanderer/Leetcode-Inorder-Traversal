using System;
using System.Collections.Generic;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree(1);
            binaryTree.AddNode(2);
            binaryTree.AddNode(3);
            binaryTree.AddNode(4);
            binaryTree.AddNode(5);
            binaryTree.AddNode(6);
            binaryTree.AddNode(7);
            binaryTree.AddNode(8);

            Solution.InorderTraversal(binaryTree.rootNode);
        }

        public class Solution
        {
            public static List<int> InorderTraversal(Node root)
            {
                List<int> rawValues = TraverseNodes(root);

                foreach(int item in rawValues)
                {
                    Console.WriteLine(item);
                }

                return rawValues;
            }

            public static List<int> TraverseNodes(Node node)
            {
                Node currentNode = node;
                Node nodeToReturnTo;
                List<int> rawValues = new List<int>();

                while (currentNode.left != null)
                {
                    rawValues.Add(currentNode.val);
                    nodeToReturnTo = currentNode;
                    currentNode = currentNode.left;

                    TraverseNodes(nodeToReturnTo.right);
                }

                return rawValues;
            }
        }
        public class BinaryTree
        {
            public Node rootNode { get; set; }
            Node currentNode { get; set; }
            int totalDepth = 0;

            public BinaryTree(int rootData)
            {
                rootNode = new Node(rootData);
                currentNode = rootNode;
            }

            public void AddNode(int data)
            {
                Node nodeToInsert = new Node(data);
                nodeToInsert.left = null;
                nodeToInsert.right = null;

                if (currentNode.left == null)
                {
                    currentNode.left = nodeToInsert;
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = nodeToInsert;
                    }
                }

                if (currentNode.right != null && currentNode.left != null)
                {
                    currentNode = currentNode.left;
                }
            }

            public int GetSumOfDepths()
            {
                int nodeDepth = 0;
                currentNode = rootNode;

                while (currentNode.left != null && currentNode.right != null)
                {
                    if (currentNode.left != null)
                    {
                        nodeDepth++;
                    }
                    if (currentNode.right != null)
                    {
                        nodeDepth++;
                        GetNodeDepth(currentNode.right);
                    }

                    currentNode = currentNode.left;
                }

                totalDepth += nodeDepth;

                return totalDepth;
            }

            private int GetNodeDepth(Node node)
            {
                int nodeDepth = 0;
                while (node.left != null && node.right != null)
                {
                    if (node.left != null)
                    {
                        nodeDepth++;
                        node = node.left;
                    }
                }

                return nodeDepth;
            }

            public void DisplayAllChildren(Node node)
            {
                Node nodeToDisplay = node;
                Console.WriteLine(nodeToDisplay.val);

                while (nodeToDisplay.left != null && nodeToDisplay.right != null)
                {
                    if (nodeToDisplay.left != null)
                    {
                        Console.WriteLine(nodeToDisplay.left.val);
                    }
                    if (nodeToDisplay.right != null)
                    {
                        DisplayAllChildren(nodeToDisplay.right);
                    }
                    nodeToDisplay = nodeToDisplay.left;
                }
            }
        }

        public class Node
        {
            public int val;
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int Data)
            {
                val = Data;
            }
            public void SetData(int Data)
            {
                val = Data;
            }
            public int GetData()
            {
                return val;
            }
        }
    }
}
