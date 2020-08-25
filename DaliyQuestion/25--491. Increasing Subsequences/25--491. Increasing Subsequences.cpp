// 25--491. Increasing Subsequences.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
#include <unordered_set>
using namespace std;

/*491. 递增子序列
给定一个整型数组, 你的任务是找到所有该数组的递增子序列，递增子序列的长度至少是2。

示例:

输入: [4, 6, 7, 7]
输出: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7], [4,7,7]]
说明:

给定数组的长度不会超过15。
数组中的整数范围是 [-100,100]。
给定数组中可能包含重复数字，相等的数字应该被视为递增的一种情况。*/
int main()
{
	vector<int> x = { 4,6,7,7 };

	Solution s;

	for (auto sub : s.findSubsequences(x))
	{
		cout << "[";
		for (int val : sub)
		{
			cout << val << ",";
		}
		cout << "]" << endl;
	}
}

class Solution
{
public:
    vector<vector<int>> res;
    vector<int> temp;
	
	void dfs(int cur,int last, vector<int>& nums)
	{
		if (cur==nums.size())
		{
			//判断是否合法，如果合法判断是否重复，将满足条件的加入答案
			if (temp.size()>=2)
			{
                res.push_back(temp);
			}
			return;
		}

		if (nums[cur]>=last)
		{
            temp.push_back(nums[cur]);
            dfs(cur + 1, nums[cur], nums);
            temp.pop_back();
		}

		if (nums[cur]!=last)
		{
            dfs(cur + 1, last, nums);
		}
	}
    
	
    vector<vector<int>> findSubsequences(vector<int>& nums) {

		dfs(0, INT_MIN, nums);

		return res;
    }
};




// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
