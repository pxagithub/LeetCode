using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DataStructLibrary;

namespace _06__107._Binary_Tree_Level_Order_Traversal_II
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            IList<IList<int>> x = LevelOrderBottom(root);
            Console.WriteLine();
        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (root==null)
            {
                return res;
            }

            List<TreeNode> fatherNodes = new List<TreeNode>();
            

            fatherNodes.Add(root);
            res.Add(new List<int>(){root.val});

            while (fatherNodes.Count!=0)
            {
                List<TreeNode> children = new List<TreeNode>();
                List<int> temp = new List<int>();
                foreach (var father in fatherNodes)
                {
                    if (father.left!=null)
                    {
                        children.Add(father.left);
                        temp.Add(father.left.val);
                    }

                    if (father.right!=null)
                    {
                        children.Add(father.right);
                        temp.Add(father.right.val);
                    }
                }

                if (temp.Count!=0)
                {
                    res.Add(temp);
                }
                
                fatherNodes = children;
            }
            

            return res.Reverse().ToList();
        }
    }
}
