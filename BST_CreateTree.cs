using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISD
{
    class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value;
        public Node Right;
        public Node Left;
        public int LeftCounter;
        public int RightCounter;
    }

    class BST
    {
        public Node Head;

        public static void Add(int value, ref Node currentNode)
        {
            if (currentNode == null)
            {
                currentNode = new Node(value);
                return;
            }

            if (currentNode.Value == value)
            {
                return;
            }
            else if (currentNode.Value > value)
            {
                Add(value, ref currentNode.Left);
            }
            else
            {
                Add(value, ref currentNode.Right);
            }
        }

        public static void RightRemove(int value, ref Node currentNode)
        {
            if (currentNode == null)
            {
                return;
            }

            if (value < currentNode.Value)
            {
                RightRemove(value, ref currentNode.Left);
            }
            else if (value > currentNode.Value)
            {
                RightRemove(value, ref currentNode.Right);
            }
            else
            {
                if (currentNode.Left == null && currentNode.Right == null)
                {
                    currentNode = null;
                }
                else if (currentNode.Left == null)
                {
                    currentNode = currentNode.Right;
                }
                else if (currentNode.Right == null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    Node minNode = FindMin(currentNode.Right);
                    currentNode.Value = minNode.Value;
                    RightRemove(minNode.Value, ref currentNode.Right);
                }
            }
        }

        private static Node FindMin(Node currentNode)
        {
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        public static List<int> PreOrderTraversal(Node currentNode, ref List<int> result)
        {
            if (currentNode == null)
            {
                return result;
            }

            result.Add(currentNode.Value);
            PreOrderTraversal(currentNode.Left, ref result);
            PreOrderTraversal(currentNode.Right, ref result);
            return result;
        }

        public static void CountChildNodes(Node node, ref int maxDiff, List<Node> nodesWithMaxDiff)
        {
            if (node == null)
            {
                return;
            }

            node.LeftCounter = CountNodes(node.Left);
            node.RightCounter = CountNodes(node.Right);

            int diff = Math.Abs(node.LeftCounter - node.RightCounter);
            if (diff > maxDiff)
            {
                maxDiff = diff;
                nodesWithMaxDiff.Clear();
                nodesWithMaxDiff.Add(node);
            }
            else if (diff == maxDiff)
            {
                nodesWithMaxDiff.Add(node);
            }

            CountChildNodes(node.Left, ref maxDiff, nodesWithMaxDiff);
            CountChildNodes(node.Right, ref maxDiff, nodesWithMaxDiff);
        }

        private static int CountNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
    }

    public class Program
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader("tst.in"))
            {
                string[] lines = reader.ReadToEnd().Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var items = lines.Select(int.Parse).ToArray();

                BST bst = new BST();
                for (int i = 0; i < items.Length; i++)
                {
                    BST.Add(items[i], ref bst.Head);
                }

                int maxDiff = -1;
                List<Node> nodesMaxDifference = new List<Node>();
                BST.CountChildNodes(bst.Head, ref maxDiff, nodesMaxDifference);

                if (nodesMaxDifference.Count > 0 && nodesMaxDifference.Count % 2 != 0)
                {
                    int mediana = FindMediana(nodesMaxDifference);
                    BST.RightRemove(mediana, ref bst.Head);
                }

                List<int> result = new List<int>();
                BST.PreOrderTraversal(bst.Head, ref result);

                using (StreamWriter writer = new StreamWriter("tst.out"))
                {
                    foreach (int item in result)
                    {
                        writer.WriteLine(item);
                        Console.WriteLine(item);
                    }
                }
            }
        }

        private static int FindMediana(List<Node> nodes)
        {
            var sortedNodeValues = nodes.Select(n => n.Value).OrderBy(k => k).ToList();
            int n = sortedNodeValues.Count;
            int medianIndex = (n - 1) / 2;
            return sortedNodeValues[medianIndex];
        }
    }
}