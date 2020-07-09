using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using DataStructLibrary;

namespace _449._Serialize_and_Deserialize_BST
{
    class Program
    {
        /*
         * 449. 序列化和反序列化二叉搜索树
           序列化是将数据结构或对象转换为一系列位的过程，以便它可以存储在文件或内存缓冲区中，或通过网络连接链路传输，以便稍后在同一个或另一个计算机环境中重建。
           
           设计一个算法来序列化和反序列化二叉搜索树。 对序列化/反序列化算法的工作方式没有限制。 您只需确保二叉搜索树可以序列化为字符串，并且可以将该字符串反序列化为最初的二叉搜索树。
           
           编码的字符串应尽可能紧凑。
           
           注意：不要使用类成员/全局/静态变量来存储状态。 你的序列化和反序列化算法应该是无状态的。
         */
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }
                
            };
            TreeNode root1=new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            Codec codec=new Codec();
            string res1 = codec.Serialize(root);
            TreeNode treeRoot = codec.Deserialize(res1);
            string res2 = codec.Serialize(root1);
            TreeNode treeRoot2 = codec.Deserialize(res2);

            Console.WriteLine();
        }
    }
    public class Codec
    {
        
        // Encodes a tree to a single string.
        //BST的前序遍历结果
        public string Serialize(TreeNode root)
        {
            if (root == null) return "";
            StringBuilder sb = new StringBuilder();
            Helper(root, sb);
            return sb.ToString().Substring(0, sb.Length - 1);
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            string[] arr = data.Split(",");
            return Builder(arr, 0, arr.Length - 1);
        }

        public void Helper(TreeNode root, StringBuilder sb)
        {
            if(root == null)return;
            //拼接当前节点
            sb.Append(root.val).Append(",");
            Helper(root.left,sb);
            Helper(root.right,sb);
        }

        public TreeNode Builder(string[] arr, int low, int high)
        {
            if (low > high) return null;
            TreeNode root=new TreeNode(int.Parse(arr[low]));
            //找到第一个比首元素大的元素位置
            int index = high + 1;
            for (int i = low+1  ; i <= high; i++)
            {
                if (int.Parse(arr[i])>root.val)
                {
                    index = i;
                    break;
                }
            }
            //递归构建字数
            root.left = Builder(arr, low + 1, index - 1);
            root.right = Builder(arr, index, high);
            return root;
        }

        
    }
}
