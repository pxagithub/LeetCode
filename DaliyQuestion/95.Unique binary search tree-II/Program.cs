using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using DataStructLibrary;

namespace _95.Unique_binary_search_tree_II
{
    class Program
    {
        /*95. 不同的二叉搜索树 II
          给定一个整数 n，生成所有由 1 ... n 为节点所组成的 二叉搜索树 。
          示例：
          输入：3
          输出：
          [
            [1,null,3,2],
            [3,2,null,1],
            [3,1,null,null,2],
            [2,1,3],
            [1,null,2,null,3]
          ]
          解释：
          以上的输出对应以下 5 种不同结构的二叉搜索树：
             1         3     3      2      1
              \       /     /      / \      \
               3     2     1      1   3      2
              /     /       \                 \
             2     1         2                 3
          提示：
          0 <= n <= 8*/
        static void Main(string[] args)
        {
            IList<TreeNode> x = GenerateTrees(3);
            for (int i = 0; i < x.Count; i++)
            {
                Console.WriteLine(string.Join("\t",x[i].val));
            }
        }

        public static IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode>[] dp=new List<TreeNode>[n+1];
            dp[0]=new List<TreeNode>();
            if (n==0)
            {
                return dp[0];
            }
            dp[0].Add(null);
            //长度为1到n
            for (int len = 1; len <= n; len++)
            {
                dp[len]=new List<TreeNode>();
                //将不同的数字作为根节点，只需要考虑到len
                for (int root = 1; root <= len; root++)
                {
                    int left = root - 1;
                    int right = len - root;
                    foreach (var leftTree in dp[left])
                    {
                        foreach (var rightTree in dp[right])
                        {
                            TreeNode treeRoot=new TreeNode(root);
                            treeRoot.left = leftTree;
                            //克隆右子树并且加上偏差
                            treeRoot.right = Clone(rightTree, root);
                            dp[len].Add(treeRoot);
                        }
                    }
                }
            }

            return dp[n];
        }

        private static TreeNode Clone(TreeNode n, int offset)
        {
            if (n==null)
            {
                return null;
            }

            TreeNode node = new TreeNode(n.val + offset);
            node.left = Clone(n.left, offset);
            node.right = Clone(n.right, offset);
            return node;
        }
    }
}
