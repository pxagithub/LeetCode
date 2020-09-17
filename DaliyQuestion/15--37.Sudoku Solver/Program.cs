using System;
using System.Collections.Generic;
using System.Linq;

namespace _15__37.Sudoku_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            /*37. 解数独
               编写一个程序，通过已填充的空格来解决数独问题。
               一个数独的解法需遵循如下规则：
               
               数字 1-9 在每一行只能出现一次。
               数字 1-9 在每一列只能出现一次。
               数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。
               空白格用 '.' 表示。
               一个数独。
               答案被标成红色。

               Note:
               给定的数独序列只包含数字 1-9 和字符 '.' 。
               你可以假设给定的数独只有唯一解。
               给定数独永远是 9x9 形式的。*/

            char[][] sudoku =
            {
                new[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                new[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            

            char[][] test =
            {
                new[] {'.', '.', '9', '7', '4', '8', '.', '.', '.'},
                new[] {'7', '.', '.', '.', '.', '.', '.', '.', '.'},
                new[] {'.', '2', '.', '1', '.', '9', '.', '.', '.'},
                new[] {'.', '.', '7', '.', '.', '.', '2', '4', '.'},
                new[] {'.', '6', '4', '.', '1', '.', '5', '9', '.'},
                new[] {'.', '9', '8', '.', '.', '.', '3', '.', '.'},
                new[] {'.', '.', '.', '8', '.', '3', '.', '2', '.'},
                new[] {'.', '.', '.', '.', '.', '.', '.', '.', '6'},
                new[] {'.', '.', '.', '2', '7', '5', '9', '.', '.'}
            };
            SolveSudoku(test);
            for (int i = 0; i < sudoku.Length; i++)
            {
                Console.WriteLine(string.Join(',',test[i]));
            }
        }

        //九列
        List<Dictionary<int, bool>> liCol = new List<Dictionary<int, bool>>();
        //九行
        List<Dictionary<int, bool>> liRow = new List<Dictionary<int, bool>>();
        //3*3格子 九个
        List<Dictionary<int, bool>> liBox = new List<Dictionary<int, bool>>();
        char[][] boardAllres = null;
        public void SolveSudoku(char[][] board)
        {
            //判断一共有多少个数字
            int hasNumCount = 0;
            Dictionary<int, bool> dicAllTemp = new Dictionary<int, bool>();
            //创建一个键值对集合存储数字是否出现过 
            for (int i = 1; i <= 9; i++)
            {
                dicAllTemp.Add(i, false);
            }
            for (int i = 0; i < 9; i++)
            {
                //存储对应的九列
                liCol.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九行
                liRow.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九个3*3格子
                liBox.Add(new Dictionary<int, bool>(dicAllTemp));
            }
            //遍历整个集合 将已出现的数字赋值为true 
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int temp = board[i][j] - 48;
                        liRow[i][temp] = true;
                        liCol[j][temp] = true;
                        int count = (i / 3) * 3 + j / 3;
                        liBox[count][temp] = true;
                        hasNumCount++;
                    }
                }
            }
            Recursive(board, hasNumCount, 0, 0);
            board = boardAllres;
        }

        public bool Recursive(char[][] board, int hasNumCount, int i, int j)
        {
            //81个数字代表已经填满了 直接返回结果
            if (hasNumCount == 81)
            {
                boardAllres = board;
                return true;
            }
            for (; i < board.Length; i++)
            {
                for (j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        //查出该行对应的所有未使用的数字 一次遍历填入
                        List<int> liRes = liRow[i].Where(e => e.Value == false).Select(e => e.Key).ToList();
                        foreach (var item in liRes)
                        {
                            //判读位于那个格子 
                            int count = (i / 3) * 3 + j / 3;
                            if (liCol[j][item] == false && liBox[count][item] == false && liRow[i][item] == false)
                            {
                                //总数+1 对应的位置赋值为true
                                hasNumCount++;
                                liRow[i][item] = true;
                                liCol[j][item] = true;
                                liBox[count][item] = true;
                                //之所以加48为了将数字转为char类型存进去
                                board[i][j] = (char)(item + 48);
                                //递归 存在不符合就返回 结果为true只有一种情况 那就是已经完成了
                                if (Recursive(board, hasNumCount, i, 0))
                                {
                                    return true;
                                }
                                //不符合 将操作撤回到之前 
                                hasNumCount--;
                                board[i][j] = '.';
                                liRow[i][item] = false;
                                liCol[j][item] = false;
                                liBox[count][item] = false;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
