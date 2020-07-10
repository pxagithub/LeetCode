using System;

namespace IV12.Paths_in_the_matrix
{
    class Program
    {
        /*剑指 Offer 12. 矩阵中的路径
           请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有字符的路径。路径可以从矩阵中的任意一格开始，每一步可以在矩阵中向左、右、上、下移动一格。如果一条路径经过了矩阵的某一格，那么该路径不能再次进入该格子。例如，在下面的3×4的矩阵中包含一条字符串“bfce”的路径（路径中的字母用加粗标出）。
           [["a","b","c","e"],
           ["s","f","c","s"],
           ["a","d","e","e"]]
           但矩阵中不包含字符串“abfb”的路径，因为字符串的第一个字符b占据了矩阵中的第一行第二个格子之后，路径不能再次进入这个格子。
           示例 1：        
           输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
           输出：true
           示例 2：
           输入：board = [["a","b"],["c","d"]], word = "abcd"
           输出：false
           提示：
           1 <= board.length <= 200
           1 <= board[i].length <= 200*/
        static void Main(string[] args)
        {
            char[][] x =
            {
                new char[] {'A', 'B', 'C', 'E'},
                new char[] {'S', 'F', 'C', 'S'},
                new char[] {'A', 'D', 'E', 'E'},
            };
            string wordX = "ABCCED";
            char[][] y =
            {
                new char[] {'a', 'b'},
                new char[] {'c', 'd'}
            };
            string wordY = "abcd";
            Console.WriteLine(Exist(x,wordX));
            Console.WriteLine(Exist(y,wordY));
        }

        public static bool Exist(char[][] board, string word)
        {
            char[] words = word.ToCharArray();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Dfs(board, words, i, j, 0)) return true;
                }
            }

            return false;
        }

        public static bool Dfs(char[][] board, char[] word, int i, int j, int k)
        {
            if (i >= board.Length || i < 0 || j >= board[0].Length || j < 0 || board[i][j] != word[k]) 
                return false;
            if (k == word.Length - 1) return true;
            char tmp = board[i][j];
            board[i][j] = '/';
            bool res = Dfs(board, word, i + 1, j, k + 1) || Dfs(board, word, i - 1, j, k + 1) ||
                       Dfs(board, word, i, j + 1, k + 1) || Dfs(board, word, i, j - 1, k + 1);
            board[i][j] = tmp;
            return res;
        }
    }
}
