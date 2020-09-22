using System;
using DataStructLibrary;

namespace _22__968._Binary_Tree_Cameras
{
    class Program
    {
        static void Main(string[] args)
        {
            /*968. 监控二叉树
               给定一个二叉树，我们在树的节点上安装摄像头。
               节点上的每个摄影头都可以监视其父对象、自身及其直接子对象。
               计算监控树的所有节点所需的最小摄像头数量。
               示例 1：
               输入：[0,0,null,0,0]
               输出：1
               解释：如图所示，一台摄像头足以监控所有节点。
               示例 2：
               输入：[0,0,null,0,null,0,null,null,0]
               输出：2
               解释：需要至少两个摄像头来监视树的所有节点。 上图显示了摄像头放置的有效位置之一。
               提示：
               给定树的节点数的范围是 [1, 1000]。
               每个节点的值都是 0。*/

            TreeNode x = new TreeNode(0)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(0)
                }
            };

            TreeNode y=new TreeNode(0)
            {
                left = new TreeNode(0)
                {
                    left = new TreeNode(0)
                    {
                        left = new TreeNode(0)
                        {
                            right = new TreeNode(0)
                        }
                    }
                }
            };

            Console.WriteLine(MinCameraCover(x));
            Console.WriteLine(MinCameraCover(y));
        }

        public static int MinCameraCover(TreeNode root)
        {
            int[] array = Dfs(root);
            return array[1];
        }

        public static int[] Dfs(TreeNode root)
        {
            if (root==null)
            {
                return new int[] {int.MaxValue / 2, 0, 0};
            }

            int[] leftArray = Dfs(root.left);
            int[] rightArray = Dfs(root.right);
            int[] array = new int[3];
            array[0] = leftArray[2] + rightArray[2] + 1;
            array[1] = Math.Min(array[0], Math.Min(leftArray[0] + rightArray[1], leftArray[1] + rightArray[0]));
            array[2] = Math.Min(array[0], leftArray[1] + rightArray[1]);
            return array;
        }
    }
}
