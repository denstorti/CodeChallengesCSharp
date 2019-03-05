using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            char[,] sudokuBoard = new char[9, 9] {
                 {'5','3','.','.','7', '.', '.', '.', '.'},
                 {'6','.','.','1','9','5','.','.','.'},
                 {'.','9','8','.','.','.','.','6','.'},
                 {'8','.','.','.','6','.','.','.','3'},
                 {'4','.','.','8','.','3','.','.','1'},
                 {'7','.','.','.','2','.','.','.','6'},
                 {'.','6','.','.','.','.','2','8','.'},
                 {'.','.','.','4','1','9','.','.','5'},
                 {'.','.','.','.','8','.','.','7','9'}
            };
            Algorithms.IsValidSudoku(sudokuBoard);

            char[,] invalidSudokuBoard = new char[9, 9] {
                 {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                 {'6','.','.','1','9','5','.','.','.'},
                 {'.','9','8','.','.','.','.','6','.'},
                 {'8','.','.','.','6','.','.','.','3'},
                 {'4','.','.','8','.','3','.','.','1'},
                 {'7','.','.','.','2','.','.','.','6'},
                 {'.','6','.','.','.','.','2','8','.'},
                 {'.','.','.','4','1','9','.','.','5'},
                 {'.','.','.','.','8','.','.','7','9'}
            };
            Algorithms.IsValidSudoku(invalidSudokuBoard);

            char[,] invalidBoxSudokuBoard = new char[9, 9] {
                 {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                 {'6','.','.','1','9','5','.','.','.'},
                 {'.','5','8','.','.','.','.','6','.'},
                 {'8','.','.','.','6','.','.','.','3'},
                 {'4','.','.','8','.','3','.','.','1'},
                 {'7','.','.','.','2','.','.','.','6'},
                 {'.','6','.','.','.','.','2','8','.'},
                 {'.','.','.','4','1','9','.','.','5'},
                 {'.','.','.','.','8','.','.','7','9'}
            };
            Algorithms.IsValidSudoku(invalidBoxSudokuBoard);

            invalidBoxSudokuBoard = new char[9, 9] {
                 {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                 {'6','.','.','1','9','5','.','.','.'},
                 {'.','.','8','.','.','.','.','6','.'},
                 {'8','.','.','.','6','.','.','.','3'},
                 {'4','.','.','8','.','3','.','.','1'},
                 {'7','.','.','.','2','.','.','.','6'},
                 {'.','6','.','.','.','.','2','8','.'},
                 {'.','.','.','4','1','9','.','.','5'},
                 {'.','.','.','.','8','8','.','7','9'}
            };
            Algorithms.IsValidSudoku(invalidBoxSudokuBoard);

            invalidBoxSudokuBoard = new char[9, 9] {
                 {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                 {'6','.','.','1','9','5','.','.','.'},
                 {'.','.','8','.','.','.','.','6','.'},
                 {'8','.','.','.','6','.','.','.','3'},
                 {'4','.','.','8','.','3','.','.','1'},
                 {'7','.','.','.','2','.','.','.','6'},
                 {'.','6','.','.','.','.','2','8','.'},
                 {'.','.','.','4','1','9','7','.','5'},
                 {'.','.','.','.','8','.','.','7','9'}
            };
            Algorithms.IsValidSudoku(invalidBoxSudokuBoard);

            Algorithms.GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            Algorithms.ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1 }, 3); //true
            Algorithms.ContainsNearbyDuplicate(new int[] { 1, 0, 1, 1 }, 1); //true
            Algorithms.ContainsNearbyDuplicate(new int[] { 1, 2, 3, 1, 2, 3 }, 2); //false

            Algorithms.Intersect(new int[] { 1, 2 }, new int[] { 1, 1 });
            Algorithms.Intersect(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            Algorithms.Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });

            Algorithms.FirstUniqChar("dddccdbba");

            Algorithms.FindRestaurant(
               new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" },
               new string[] { "Burger King", "The Grill at Torrey Pines", "Shogun", "Hungry Hunter Steakhouse" }
               );

            Algorithms.FindRestaurant(
                new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" },
                new string[] { "KFC", "Shogun", "Burger King" }
                );

            Algorithms.FindRestaurant(
                new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" },
                new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" }
                );

            Algorithms.IsIsomorphic("aa", "ab");
            Algorithms.IsIsomorphic("ab", "aa");
            Algorithms.IsIsomorphic("egg", "add");
            Algorithms.IsIsomorphic("paper", "title");
            Algorithms.IsIsomorphic("foo", "bar");

            var keyValuePair1 = new KeyValuePair<int, int>(5, 17);
            var keyValuePair2 = new KeyValuePair<int, int>(5, 17);
            var keyValuePair3 = new KeyValuePair<int, int>(5, 17);

            var hashmapKV = new MyHashMap<string, KeyValuePair<int, int>>();


            hashmapKV.Put("denis", keyValuePair1);
            hashmapKV.Put("will", keyValuePair2);
            hashmapKV.Put("luzia", keyValuePair3);

            var hashmapInt = new MyHashMap<Int64, int>();
            hashmapInt.Put(1, 1);
            hashmapInt.Put(2, 2);
            hashmapInt.Get(2);
            hashmapInt.Put(2, 1);
            hashmapInt.Get(2);


            Algorithms.IsHappy(123);
            Algorithms.IsHappy(23);

            var sw = new Stopwatch();
            sw.Start();
            Algorithms.Intersection(new int[] { 4, 9, 59, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 4 }, new int[] { 9, 4, 9, 8, 4, 9, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 4 });
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Reset();
            sw.Start();
            Algorithms.intersection2(new int[] { 4, 9, 59, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 4 }, new int[] { 9, 4, 9, 8, 4, 9, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 49, 4, 9, 8, 4 });
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Console.ReadKey();

            Algorithms.SingleNumber(new int[] { 2, 2, 1 });
            Console.WriteLine("Hello World!");
        }


    }
}
