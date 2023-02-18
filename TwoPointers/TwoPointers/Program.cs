using System;
using System.Collections.Generic;

namespace TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = IsPalindrome("A man, a plan, a canal: Panama");
            var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            
            var result = OptimalTrap(arr);
            Console.WriteLine("");
        }

        public static int OptimalTrap(int[] height) 
        {
            var left = 0;
            var right = height.Length - 1;
            var leftMax = height[left];
            var rightMax = height[right];
            var res = 0;
            while(left < right) 
            {
                if(leftMax < rightMax) 
                {
                    left++;
                    leftMax = Math.Max(leftMax, height[left]);
                    res += leftMax - height[left];
                }
                else 
                {
                    right--;
                    rightMax = Math.Max(rightMax, height[right]);
                    res += rightMax - height[rightMax];
                }
            }
            return res;
        }

        public static int Trap(int[] height)
        {
            var maxRight = new int[height.Length];
            var maxLeft = new int[height.Length];
            int result = 0;
            var max = int.MinValue;
            for(int i = 1; i < height.Length; i++) 
            {
                max = Math.Max(max, height[i - 1]);
                maxRight[i] = max;
            }

            max = int.MinValue;

            for(int i = height.Length-2; i >=0; i--) 
            {
                max = Math.Max(max, height[i + 1]);
                maxLeft[i] = max;
            }

            for(int i = 0; i < height.Length; i++) 
            {
                int val = Math.Min(maxRight[i], maxLeft[i]) - height[i];
                if (val < 0) continue;
                result += val;
            }
            
            
            return result;
        }

        public static int MaxArea(int[] height) 
        {
            int first = 0;
            int second = height.Length - 1;
            int max = 0;

            while(first < second) 
            {
                if(height[first] < height[second]) 
                {
                    max = Math.Max(max, height[first] * (second - first));
                    first++;
                }
                else 
                {
                    max = Math.Max(max, height[second] * (second - first));
                    second--;
                }
            }
            return max;
        }

        public static int BruteMaxArea(int[] height) 
        {
            int res = 0;
            for(int i = 0; i < height.Length; i++) 
            {
                for(int r = i+1; r <
                    height.Length; r++) 
                {
                    Console.WriteLine($"i: {i}, height[i]: {height[i]}");
                    Console.WriteLine($"r: {r}, height[r]: {height[r]}");
                    int area = (r - i) * Math.Min(height[i], height[r]);
                    res = Math.Max(res, area);
                    Console.WriteLine($"res: {res}");
                    Console.WriteLine();
                }
            }
            return res;
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums.Length < 4) return result;
            Array.Sort(nums);
            long val = (long)(int)target;
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                    int low = j + 1;
                    int high = nums.Length - 1;
                    long newTarget = val - nums[i] - nums[j];
                    while (low < high)
                    {
                        if (nums[low] + nums[high] == newTarget)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1]) low++;
                            while (low < high && nums[high] == nums[high - 1]) high--;
                            low++;
                            high--;

                        }
                        else if (nums[low] + nums[high] < newTarget)
                        {
                            low++;
                            while (low < high && nums[low] == nums[low - 1]) low++;
                        }
                        else
                        {
                            high--;
                            while (low < high && nums[high] == nums[high + 1]) high--;
                        }
                    }
                }
            }
            return result;
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length == 0) return true;

            s = s.ToLower();
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                    i++;
                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (s[i] != s[j]) return false;
            }

            return true;
        }

        /// <summary>
        /// Time: O(n)
        /// Space: O(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                if (numbers[left] + numbers[right] > target)
                    right--;
                else if (numbers[left] + numbers[right] < target)
                    left++;
                else if (numbers[left] + numbers[right] == target)
                    return new int[] { left + 1, right + 1 };
            }
            return Array.Empty<int>();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int left = i + 1;
                    int right = nums.Length - 1;
                    int sum = 0 - nums[i];

                    while (left < right)
                    {
                        if (nums[left] + nums[right] == sum)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }

                            left++;
                            right--;
                        }
                        else if (nums[left] + nums[right] > sum)
                        {
                            right--;
                        }
                        else if (nums[left] + nums[right] < sum)
                        {
                            left++;
                        }
                    }
                }
            }
            return result;
        }

    }
}
