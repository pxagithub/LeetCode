﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace _12__133.Clone_Graph
{
    class Program
    {
        /*133. 克隆图
           给你无向 连通 图中一个节点的引用，请你返回该图的 深拷贝（克隆）。
           图中的每个节点都包含它的值 val（int） 和其邻居的列表（list[Node]）。
           class Node {
           public int val;
           public List<Node> neighbors;
           }
           测试用例格式：
           
           简单起见，每个节点的值都和它的索引相同。例如，第一个节点值为 1（val = 1），第二个节点值为 2（val = 2），以此类推。该图在测试用例中使用邻接列表表示。
           邻接列表 是用于表示有限图的无序列表的集合。每个列表都描述了图中节点的邻居集。           
           给定节点将始终是图中的第一个节点（值为 1）。你必须将 给定节点的拷贝 作为对克隆图的引用返回。
           
           示例 1：        
           输入：adjList = [[2,4],[1,3],[2,4],[1,3]]
           输出：[[2,4],[1,3],[2,4],[1,3]]
           解释：
           图中有 4 个节点。
           节点 1 的值是 1，它有两个邻居：节点 2 和 4 。
           节点 2 的值是 2，它有两个邻居：节点 1 和 3 。
           节点 3 的值是 3，它有两个邻居：节点 2 和 4 。
           节点 4 的值是 4，它有两个邻居：节点 1 和 3 。

           示例 2：
           输入：adjList = [[]]
           输出：[[]]
           解释：输入包含一个空列表。该图仅仅只有一个值为 1 的节点，它没有任何邻居。
           
           示例 3：
           输入：adjList = []
           输出：[]
           解释：这个图是空的，它不含任何节点。

           示例 4：
           输入：adjList = [[2],[1]]
           输出：[[2],[1]]
           提示：
           节点数不超过 100 。
           每个节点值 Node.val 都是唯一的，1 <= Node.val <= 100。
           无向图是一个简单图，这意味着图中没有重复的边，也没有自环。
           由于图是无向的，如果节点 p 是节点 q 的邻居，那么节点 q 也必须是节点 p 的邻居。
           图是连通图，你可以从给定节点访问到所有节点。*/
        static void Main(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(1);
            Node n3 = new Node(1);
            Node n4 = new Node(1);
            n1.neighbors.Add(n2);
            n1.neighbors.Add(n4);
            n2.neighbors.Add(n1);
            n2.neighbors.Add(n3);
            n3.neighbors.Add(n2);
            n3.neighbors.Add(n4);
            n4.neighbors.Add(n1);
            n4.neighbors.Add(n3);

            Node x=new Node(1);

            Node y;

            Node z1=new Node(1);
            Node z2=new Node(2);
            z1.neighbors.Add(z2);
            z2.neighbors.Add(z1);


            Node res = CloneGraph(n1);
            res = CloneGraph(x);
            res = CloneGraph(y);
            res = CloneGraph(z1);
            Console.WriteLine();
        }

        public static Dictionary<int, IList<Node>> origin;
        public static List<Node> nodeList;

        public static Node CloneGraph(Node node)
        {
            if (node==null)
            {
                return new Node();
            }

            if (node.neighbors==null)
            {
                return new Node(node.val);
            }

            origin = new Dictionary<int, IList<Node>>();

            nodeList = new List<Node>();

            Dfs(node);

            foreach (var n  in nodeList)
            {
                foreach (var neighbor in origin[n.val])
                {
                    n.neighbors.Add(nodeList.Find(node=>node.val==neighbor.val));
                }
            }

            return nodeList[0];

        }


        public static void Dfs(Node node)
        {
            if (node == null)
            {
                return;
            }

            

            if (!origin.ContainsKey(node.val))
            {
                origin.Add(node.val, node.neighbors);
                nodeList.Add(new Node(node.val));
                foreach (var neighbor in node.neighbors)
                {
                    Dfs(neighbor);
                }
            }
            else
            {
                return;
            }

            
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
