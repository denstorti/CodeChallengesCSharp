using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Algorithms
    {

        /// <summary>
        /// Determine if a 9x9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
        ///Each row must contain the digits 1-9 without repetition.
        ///Each column must contain the digits 1-9 without repetition.
        ///Each of the 9 3x3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        /// </summary>
        //Input:
        //[
        //  ["5","3",".",".","7",".",".",".","."],
        //  ["6",".",".","1","9","5",".",".","."],
        //  [".","9","8",".",".",".",".","6","."],
        //  ["8",".",".",".","6",".",".",".","3"],
        //  ["4",".",".","8",".","3",".",".","1"],
        //  ["7",".",".",".","2",".",".",".","6"],
        //  [".","6",".",".",".",".","2","8","."],
        //  [".",".",".","4","1","9",".",".","5"],
        //  [".",".",".",".","8",".",".","7","9"]
        //]
        //Output: true
        public static bool IsValidSudoku(char[,] board)
        {
            HashSet<char> rowHashSet = new HashSet<char>();
            HashSet<char> colHashSet = new HashSet<char>();
            Dictionary<string, HashSet<char>> boxesHashSet = new Dictionary<string, HashSet<char>>();  //contains the 9 boxes

            for (int i = 0; i < board.GetLongLength(0); i++) //until the size of the row
            {
                for (int j = 0; j < board.GetLongLength(1); j++)  //until size of the column
                {
                    char rowItem = board[i, j];
                    char colItem = board[j, i];

                    //validate row
                    if (rowHashSet.Contains(rowItem))
                    {
                        return false;
                    }
                    else if (!rowItem.Equals('.'))
                    {
                        rowHashSet.Add(rowItem);
                    }

                    //validate column
                    if (colHashSet.Contains(colItem))
                    {
                        return false;
                    }
                    else if (!colItem.Equals('.'))
                    {
                        colHashSet.Add(colItem);
                    }

                    bool boxValid = true;
                    if (i <= 2)
                    {
                        if (j <= 2)  //box 1
                        {
                            boxValid = checkBoxSudoku("box1", board, i, j, boxesHashSet);
                        }
                        else if (j > 2 && j <= 5) //box 2
                        {
                            boxValid = checkBoxSudoku("box2", board, i, j, boxesHashSet);
                        }
                        else //box 3
                        {
                            boxValid = checkBoxSudoku("box3", board, i, j, boxesHashSet);
                        }
                    }
                    else if (i > 2 && i <= 5)
                    {
                        if (j <= 2)
                        {
                            boxValid = checkBoxSudoku("box4", board, i, j, boxesHashSet);
                        }
                        else if (j > 2 && j <= 5)
                        {
                            boxValid = checkBoxSudoku("box5", board, i, j, boxesHashSet);
                        }
                        else
                        {
                            boxValid = checkBoxSudoku("box6", board, i, j, boxesHashSet);
                        }
                    }
                    else
                    {
                        if (j <= 2)
                        {
                            boxValid = checkBoxSudoku("box7", board, i, j, boxesHashSet);
                        }
                        else if (j > 2 && j <= 5)
                        {
                            boxValid = checkBoxSudoku("box8", board, i, j, boxesHashSet);
                        }
                        else
                        {
                            boxValid = checkBoxSudoku("box9", board, i, j, boxesHashSet);
                        }
                    }

                    if (!boxValid)
                    {
                        return false;
                    }
                }
                rowHashSet.Clear();
                colHashSet.Clear();
            }

            return true;
        }

        public static bool checkBoxSudoku(string boxName, char[,] board, int i, int j, Dictionary<string, HashSet<char>> boxesHashSet)
        {
            char boxItem = board[i, j];
            if (!boxesHashSet.ContainsKey(boxName))
            {
                boxesHashSet.Add(boxName, new HashSet<char>());
            }

            if (boxesHashSet.ContainsKey(boxName) && boxesHashSet[boxName].Contains(boxItem))
            {
                return false;
            }
            else if (!boxItem.Equals('.'))
            {
                boxesHashSet[boxName].Add(boxItem);
            }

            return true;
        }

        //Beautiful solution for IsValidSudoku (JAVA) - by https://leetcode.com/stefanpochmann/
        //public boolean isValidSudoku(char[][] board)
        //{
        //    Set seen = new HashSet();
        //    for (int i = 0; i < 9; ++i)
        //    {
        //        for (int j = 0; j < 9; ++j)
        //        {
        //            char number = board[i][j];
        //            if (number != '.')
        //                if (!seen.add(number + " in row " + i) ||
        //                    !seen.add(number + " in column " + j) ||
        //                    !seen.add(number + " in block " + i / 3 + "-" + j / 3))
        //                    return false;
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// Given an array of strings, group anagrams together.
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        //        Example:
        //Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
        //Output:
        //[
        //  ["ate","eat","tea"],
        //  ["nat","tan"],
        //  ["bat"]
        //]
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> hashmap = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                char[] charString = strs[i].ToCharArray();
                Array.Sort(charString);
                string sorted = new string(charString);

                if (hashmap.ContainsKey(sorted))
                {
                    hashmap[sorted].Add(strs[i]);
                }
                else
                {
                    hashmap.Add(sorted, new List<string>());
                    hashmap[sorted].Add(strs[i]);
                }
            }

            IList<IList<string>> output = new List<IList<string>>(hashmap.Values);

            return output;
        }


        /// <summary>
        /// Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
        //        Example 1:
        //Input: nums = [1,2,3,1], k = 3
        //Output: true
        //Example 2:
        //Input: nums = [1,0,1,1], k = 1
        //Output: true
        //Example 3:
        //Input: nums = [1,2,3,1,2,3], k = 2
        //Output: false
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> hash = new Dictionary<int, int>();

            int j = 0;
            foreach (var item in nums)
            {
                if (hash.ContainsKey(item))
                {
                    if ((j - hash[item]) <= k)
                    {
                        return true;
                    }

                    hash[item] = j;
                }
                else
                {
                    hash.Add(item, j);
                }

                j++;
            }

            return false;
        }

        /// <summary>
        /// Given two arrays, write a function to compute their intersection.
        ////        Example 1:

        ////Input: nums1 = [1,2,2,1], nums2 = [2,2]
        ////        Output: [2,2]

        ////        Example 2:

        ////Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        ////        Output: [4,9]
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> intersection = new List<int>();

            //key = number, KV.key = index, KV.Value = count
            Dictionary<int, int> hashNums1 = new Dictionary<int, int>();
            int k = 0;
            foreach (var item in nums1)
            {
                if (hashNums1.ContainsKey(item))
                {
                    hashNums1[item] += 1;
                }
                else
                {
                    hashNums1.Add(item, 1);
                }
            }

            foreach (var item in nums2)
            {
                if (hashNums1.ContainsKey(item) && hashNums1[item] > 0)
                {
                    intersection.Add(item);
                    hashNums1[item] -= 1;
                }
            }

            return intersection.ToArray();
        }

        /// <summary>
        ///  Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.
        //        Examples:

        //s = "leetcode"
        //return 0.

        //s = "loveleetcode",
        //return 2.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> hashMap = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (hashMap.ContainsKey(s[i]))
                {
                    hashMap[s[i]] += 1;
                }
                else
                {
                    hashMap.Add(s[i], 1);

                }
            }

            int indexMin = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (hashMap[s[i]] == 1)
                {
                    return indexMin;

                }
                indexMin++;
            }

            return -1;
        }

        /// <summary>
        ///  Suppose Andy and Doris want to choose a restaurant for dinner, and they both have a list of favorite restaurants represented by strings.

        /// You need to help them find out their common interest with the least list index sum.If there is a choice tie between answers, output all of them with no order requirement.You could assume there always exists an answer.
        /// 
        /// Input:
        ///["Shogun", "Tapioca Express", "Burger King", "KFC"]
        ///["KFC", "Shogun", "Burger King"]
        ///Output: ["Shogun"]
        ///Explanation: The restaurant they both like and have the least index sum is "Shogun" with index sum 1 (0+1).
        ///
        /// Input:
        ///     ["Shogun", "Tapioca Express", "Burger King", "KFC"]
        ///     ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"]
        /// Output: ["Shogun"]
        /// Explanation: The only restaurant they both like is "Shogun".
        /// </summary>
        public static string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, short> dic2 = new Dictionary<string, short>();

            short i = 0;
            foreach (var item in list2)
            {
                dic2.Add(item, i++);
            }

            List<string> output = new List<string>();
            int accSumIndex = int.MaxValue;
            for (int j = 0; j < list1.Length; j++)
            {
                if (dic2.ContainsKey(list1[j]) && (j + dic2[list1[j]] <= accSumIndex))
                {
                    output.Add(list1[j]);
                    accSumIndex = j + dic2[list1[j]];
                }

            }


            return output.ToArray();
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();

            foreach (int item in nums)
            {
                if (hashSet.Contains(item))
                {
                    return true;
                }

                hashSet.Add(item);
            }

            return false;
        }

        public static int SingleNumber(int[] nums)
        {
            SortedSet<int> hash = new SortedSet<int>();
            HashSet<int> hash2 = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.Contains(nums[i]))
                {
                    hash.Remove(nums[i]);
                }
                else
                {
                    hash.Add(nums[i]);
                }
            }

            foreach (var item in hash)
            {
                return item;
            }
            return 0;
        }

        /// <summary>
        /// Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        /// Output: [9,4]
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> hash = new HashSet<int>();
            List<int> output = new List<int>();

            foreach (int num1item in nums1)
            {
                hash.Add(num1item);
            }

            foreach (int num2item in nums2)
            {
                if (hash.Contains(num2item))
                {
                    output.Add(num2item);
                    hash.Remove(num2item);
                }

                if (hash.Count == 0)
                {
                    break;
                }
            }

            return output.ToArray();
        }

        public static int[] intersection2(int[] nums1, int[] nums2)
        {
            HashSet<int> set = new HashSet<int>();
            Array.Sort(nums2);

            foreach (int num in nums1)
            {
                if (binarySearch(nums2, num))
                {
                    set.Add(num);
                }
            }
            int i = 0;
            int[] result = new int[set.Count];
            foreach (int num in set)
            {
                result[i++] = num;
            }
            return result;
        }

        public static bool binarySearch(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }

        public static bool IsHappy(int n)
        {
            bool happyNumber = false;
            HashSet<int> hash = new HashSet<int>();
            double squaredSum = 0;
            int temp = n;

            while (squaredSum != 1)
            {
                int unit = temp % 10;
                int remainder = temp / 10;
                squaredSum = Math.Pow(unit, 2);

                while (remainder > 0)
                {
                    unit = remainder % 10;
                    remainder = remainder / 10;
                    squaredSum += Math.Pow(unit, 2);
                }

                temp = (int)squaredSum;

                if (hash.Contains(temp))
                {
                    happyNumber = false;
                    break;
                }

                hash.Add(temp);
            }

            if (squaredSum == 1)
            {
                happyNumber = true;
            }

            return happyNumber;
        }

        /// <summary>
        /// Given two strings s and t, determine if they are isomorphic.
        /// 
        /// Input: s = "egg", t = "add"
        /// Output: true
        ///   
        /// Input: s = "foo", t = "bar"
        /// Output: false
        ///  
        /// Input: s = "paper", t = "title"
        /// Output: true
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();

            short index = 0;
            foreach (char charS in s)
            {
                if (map.ContainsKey(charS))
                {
                    if (map[charS] != t[index])
                    {
                        return false;
                    }
                }
                else if (!map.ContainsValue(t[index]))
                {
                    map.Add(charS, t[index]);
                }
                else
                {
                    return false;
                }
                index++;
            }

            return true;

        }
    }
}
