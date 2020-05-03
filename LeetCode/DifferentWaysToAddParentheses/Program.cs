using System;
using System.Collections.Generic;

namespace DifferentWaysToAddParentheses
{
    class Program
    {
        /*
            241. 为运算表达式设计优先级
           给定一个含有数字和运算符的字符串，为表达式添加括号，改变其运算优先级以求出不同的结果。
           你需要给出所有可能的组合的结果。有效的运算符号包含 +, - 以及 * 。
           
           示例 1:
           
           输入: "2-1-1"
           输出: [0, 2]
           解释: 
           ((2-1)-1) = 0 
           (2-(1-1)) = 2
           示例 2:
           
           输入: "2*3-4*5"
           输出: [-34, -14, -10, -10, 10]
           解释: 
           (2*(3-(4*5))) = -34 
           ((2*3)-(4*5)) = -14 
           ((2*(3-4))*5) = -10 
           (2*((3-4)*5)) = -10 
           (((2*3)-4)*5) = 10
         */
        static void Main(string[] args)
        {
            string x = "2-1-1";
            string y = "2*3-4*5";
            IList<int> a = DiffWaysToCompute(x);
            IList<int> b = DiffWaysToCompute(y);
            foreach (var item in a)
            {
                Console.Write(item);
                Console.Write(",");
            }
            Console.WriteLine();
            foreach (var item in b)
            {
                Console.Write(item);
                Console.Write(",");
            }
        }

        public static IList<int> DiffWaysToCompute(string input)
        {
            if (input.Length==0)
            {
                return new List<int>();
            }
            List<int> result=new List<int>();
            int num = 0;

            //考虑全是数字的情况
            int index = 0;
            while (index<input.Length&&!isOperation(input[index]))
            {
                num = num * 10 + input[index] - '0';
                index++;
            }

            //将全数字的情况直接返回
            if (index==input.Length)
            {
                result.Add(num);
                return result;
            }

            for (int i = 0; i < input.Length; i++)
            {
                //通过运算符将字符串分成两部分
                if (isOperation(input[i]))
                {
                    IList<int> result1 = DiffWaysToCompute(input.Substring(0, i));
                    IList<int> result2 = DiffWaysToCompute(input.Substring(i+1));
                    //将两个结果依次运算
                    for (int j = 0; j < result1.Count; j++)
                    {
                        for (int k = 0; k < result2.Count; k++)
                        {
                            char op = input[i];
                            result.Add(Caculate(result1[j],op,result2[k]));
                        }
                    }
                }
            }

            return result;
        }

        public static int Caculate(int num1, char c, int num2)
        {
            switch (c)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
            }

            return -1;
        }
        public static bool isOperation(char c)
        {
            return c == '+' || c == '-' || c == '*';
        }
    }
}
