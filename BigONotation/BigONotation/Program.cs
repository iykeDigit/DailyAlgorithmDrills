using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigONotation
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] jArray = new char[9][];

            jArray[0] = new char[9] { '5', '3', '.', '.', '7', '.', '.', '.', '.', };
            jArray[1] = new char[9] { '6', '.', '.', '1', '9', '5', '.', '.', '.', };
            jArray[2] = new char[9] { '.', '9', '8', '.', '.', '.', '.', '6', '.', };
            jArray[3] = new char[9] { '8', '.', '.', '.', '6', '.', '.', '.', '3', };
            jArray[4] = new char[9] { '4', '.', '.', '8', '.', '3', '.', '.', '1', };
            jArray[5] = new char[9] { '7', '.', '.', '.', '2', '.', '.', '.', '6', };
            jArray[6] = new char[9] { '.', '6', '.', '.', '.', '.', '2', '8', '.', };
            jArray[7] = new char[9] { '.', '.', '.', '4', '1', '9', '.', '.', '5', };
            jArray[8] = new char[9] { '.', '.', '.', '.', '7', '.', '.', '7', '9', };

            var arr = new int[] { 100, 4, 200, 1, 3, 2 };
            var str = new List<string> { "Hello", "World" };
            var codec = new Codec();
            //var result = codec.Decode(codec.Encode(str));
            var result = IsPalindrome("A man, a plan, a canal: Panama");
            Console.WriteLine("Hello World!");
        }

        public static bool IsPalindrome(string s) 
        {
            if (s.Length == 0) return true;
            s = s.ToLower();

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }

                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (s[i] != s[j])
                {
                    return false;
                }
            }

            return true;
        }

        public static int LongestConsecutive(int[] nums)
        {
            int maxSize = 0;
            var set = new HashSet<int>(nums);
            foreach(var item in set) 
            {
                if (!set.Contains(item - 1)) 
                {
                    int count = 1;
                    int current = item;
                    while (set.Contains(current + count)) 
                    {
                        count++;
                        
                    }
                        
                    maxSize = Math.Max(maxSize, count);
                }
            }
            return maxSize;
        }
        public class Codec
        {
            public string Encode(IList<string> strs) 
            {
                if (strs.Count == 0) return strs.ToString();
                var delimiter = char.ToString((char)257);
                var sb = new StringBuilder();
                foreach(var element in strs) 
                {
                    sb.Append(element);
                    sb.Append(delimiter);
                }

                return sb.Remove(sb.Length - 1, 1).ToString();
            }

            public IList<string> Decode(string s) 
            {
                var list = s.Split((char)257);
                return list.ToList();
            }

        }


        /// <summary>
        /// Time: O(9 square)
        /// Space: O(9 square)
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValidSudoku(char[][] board)
        {
            var size = 9;
            var row = new HashSet<int>[size];
            var col = new HashSet<int>[size];
            var box = new HashSet<int>[size];

            for(int i = 0; i < size; i++) 
            {
                row[i] = new HashSet<int>();
                col[i] = new HashSet<int>();
                box[i] = new HashSet<int>();
            }

            for(int r = 0; r < size; r++) 
            {
                for(int c = 0; c < size; c++) 
                {
                    if (board[r][c] == '.') continue;
                    
                    if (row[r].Contains(board[r][c])) return false;
                    row[r].Add(board[r][c]);

                    if (col[c].Contains(board[r][c])) return false;
                    col[c].Add(board[r][c]);

                    int index = (r / 3 * 3) + (c / 3);
                    if (box[index].Contains(board[r][c])) return false;
                    box[index].Add(board[r][c]);
                }
            }
            return true;
        }

        /// <summary>
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] ProductExceptSelf(int[] nums) 
        {
            var result = new int[nums.Length];
            var temp = 1;
            for(int i = 0; i < nums.Length; i++)
            {
                result[i] = temp;
                temp *= nums[i];
            }

            temp = 1;
            for(int i = result.Length-1; i >= 0; i--) 
            {
                result[i] *= temp;
                temp *= nums[i];
            }
            return result;
        }

        /// <summary>
        /// Time: O(n)
        /// Space: O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] TopKFrequentThree(int[] nums, int k)
        {
            var maxFrequency = 0;
            var dict = new Dictionary<int, int>();
            foreach(var item in nums) 
            {
                if (!dict.ContainsKey(item)) 
                {
                    dict[item] = 1;
                }
                else 
                {
                    dict[item]++;
                }

                maxFrequency = Math.Max(maxFrequency, dict[item]);
            }

            var bucket = new Dictionary<int, List<int>>();
            foreach(var item in dict) 
            {
                if (!bucket.ContainsKey(item.Value)) 
                {
                    bucket[item.Value] = new List<int>();
                }
                bucket[item.Value].Add(item.Key);
            }

            var result = new int[k];
            var index = 0;
            for(int i = maxFrequency; i >=0; i--) 
            {
                if (!bucket.ContainsKey(i)) continue;

                if (bucket.ContainsKey(i)) 
                {
                    for(int m = 0; m < bucket[i].Count; m++) 
                    {
                        if(index < k) 
                        {
                            result[index] = bucket[i][m];
                            index++;
                            if (index == k) return result;
                        }

                        
                    }
                }
            }
            return result;
            
        }

        /// <summary>
        /// Big O: Time: O(n)
        ///        Space: O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int result = target - nums[i];
                if (!dict.ContainsKey(result))
                {
                    dict[nums[i]] = i;
                }
                else
                {
                    return new int[] { i, dict[result] };
                }
            }
            return new int[2];
        }

        /// <summary>
        /// Big O: Time: O(n)
        ///        Space: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>

        public static string[] Unique(string[] arr)
        {
            var set = new HashSet<string>();
            foreach (var element in arr)
            {
                if (!set.Contains(element))
                {
                    set.Add(element);
                }
            }
            var result = set.ToArray();
            return result;
        }

        /// <summary>
        /// Time: O(n)
        /// Space:O(t)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var first = new int[26];
            var second = new int[26];

            for (int i = 0; i < t.Length; i++)
            {
                first[s[i] - 'a']++;
                second[t[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Time: O(m * n) => m: strs, n: length of a string in strs
        /// Space: O(MN)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                var arr = new char[26];
                foreach (var element in strs[i])
                {
                    arr[element - 'a']++;
                }

                var sb = new StringBuilder();
                for (int m = 0; m < arr.Length; m++)
                {
                    sb.Append(arr[m]);
                    sb.Append("#");
                }

                string key = sb.ToString();
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string> { strs[i] });
                }
                else
                {
                    dict[key].Add(strs[i]);
                }
            }

            return dict.Values.ToList();
        }

        public static int[] TopKFrequent(int[] nums, int k) 
        {
            var dict = new Dictionary<int, int>();
            foreach(var num in nums) 
            {
                if (!dict.ContainsKey(num)) 
                {
                    dict[num] = 1;
                }
                else 
                {
                    dict[num]++;
                }
            }

            var arr = new int[k];
            var set = new SortedSet<(int frequency, int num)>();
            foreach(var item in dict) 
            {
                set.Add((item.Value, item.Key));
                if (set.Count > k)
                {
                    set.Remove(set.Min);
                }
            }

            for(int i = 0; i < k; i++) 
            {
                arr[i] = set.ElementAt(i).num;
            }

            return arr;
        }

        public static int[] TopKFrequentTwo(int[] nums, int k) 
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!dict.ContainsKey(num))
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }
            }

            var arr = new List<int>[nums.Length];
            foreach(var (key,value) in dict) 
            {
                Console.Write($"{key} {value}");
                if(arr[value] == null) 
                {
                    arr[value] = new List<int> { key};
                }

                else 
                {
                    arr[value].Add(key);
                }
                
            }

            var result = new int[k];
            var count = 0;
            for(int i = arr.Length-1; i > 0; i--) 
            {
                if(arr[i] != null) 
                {
                    foreach(var element in arr[i]) 
                    {
                        result[count] = element;
                        count++;
                        if(count == k) 
                        {
                            return result;
                        }
                    }
                }
            }
            return result;
           
        }

    }
}
