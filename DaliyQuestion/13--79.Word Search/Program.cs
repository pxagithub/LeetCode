using System;

namespace _13__79.Word_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            /*79. 单词搜索
               给定一个二维网格和一个单词，找出该单词是否存在于网格中。
               单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
               
               示例:
               board =
               [
               ['A','B','C','E'],
               ['S','F','C','S'],
               ['A','D','E','E']
               ]
               给定 word = "ABCCED", 返回 true
               给定 word = "SEE", 返回 true
               给定 word = "ABCB", 返回 false
               
               提示：
               board 和 word 中只包含大写和小写英文字母。
               1 <= board.length <= 200
               1 <= board[i].length <= 200
               1 <= word.length <= 10^3*/

            char[][] board =
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'E', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            Console.WriteLine(Exist(board,"ABCESEEEFS"));//T
            Console.WriteLine(Exist(board,"SEE"));//T
            Console.WriteLine(Exist(board,"ABCB"));//F
        }

        public static bool Exist(char[][] board, string word)
        {
            bool[][] visited=new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[i].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j]==word[0])
                    {
                        if (Dfs(board, visited, i, j, word, 0))
                        {
                            return true;
                        }
                        else
                        {
                            for (int k = 0; k < visited.Length; k++)
                            {
                                Array.Fill(visited[i], false);
                            }
                        }
                    }
                }
            }

            return false;

        }

        public static bool Dfs(char[][] board,bool[][] visited, int x, int y, string word, int i)
        {
            if (x >= 0 && x < board.Length && y >= 0 && y < board[x].Length && i< word.Length && visited[x][y] == false)
            {
                if (i == word.Length - 1 && board[x][y] == word[i])
                {
                    return true;
                }

                 if (board[x][y]==word[i])
                {
                    visited[x][y] = true;
                    bool exist=
                        Dfs(board, visited, x + 1, y, word, i + 1) ||
                        Dfs(board, visited, x - 1, y, word, i + 1) ||
                        Dfs(board, visited, x, y + 1, word, i + 1) ||
                        Dfs(board, visited, x, y - 1, word, i + 1);
                    visited[x][y] = false;
                    return exist;
                }
                else
                 { 
                     visited[x][y] = false;
                     return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
