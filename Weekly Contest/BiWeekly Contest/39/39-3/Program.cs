using System;
using System.Collections.Generic;
using System.Linq;

namespace _39_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x=new int[]{162,118,178,152,167,100,40,74,199,186,26,73,200,
            127,30,124,193,84,184,36,103,149,153,9,54,154,133,95,45,198,79,157,
            64,122,59,71,48,177,82,35,14,176,16,108,111,6,168,31,134,164,136,72,98};
            System.Console.WriteLine(MinimumJumps(x,29,98,80));
        }

        public static int MinimumJumps(int[] forbidden, int a, int b, int x) {
        int res=0;
        int position=0;
        List<int> list=forbidden.ToList();
        bool goLeft=false;
        while(position!=x){
            int left=position-b,right=position+a;
            if((left<0||list.Contains(left))&&list.Contains(right)){
                return -1;
            }
            if(position<x){
                if(!list.Contains(right)){
                    position=right;
                    goLeft=false;
                    res++;
                }
            }
            else if(position>x){
                if(!list.Contains(left)){
                    position=left;
                    goLeft=true;
                    res++;
                }
                else{
                    if(a>b) return -1;
                }
            }
            else break;
        }
        return res;

    }
    }
}
