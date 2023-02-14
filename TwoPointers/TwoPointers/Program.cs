using System;
using System.Collections.Generic;

namespace TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = IsPalindrome("A man, a plan, a canal: Panama");
            var arr = new int[] { -1, 0, 1, 2, -1, -4 };
            Console.WriteLine(arr[arr.Length-1]);
            var result = ThreeSum(arr);
            Console.WriteLine("");
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
            for(int i = 0; i < nums.Length-2; i++) 
            {
                if(i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int left = i + 1;
                    int right = nums.Length-1;
                    int sum = 0 - nums[i];

                    while(left < right) 
                    {
                        if(nums[left] + nums[right] == sum) 
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while(left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            while(left < right && nums[right] == nums[right - 1]) 
                            {
                                right--;
                            }

                            left++;
                            right--;
                        }
                        else if(nums[left] + nums[right] > sum) 
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
