﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int F1 = 0; //minimum value in array
                int L1 = nums.Length - 1;  //maximum value in array
                int midel = 0; //middle value in array
                while (F1 <= L1)
                {
                    midel = (F1 + L1) / 2;
                    if (target == nums[midel])
                    {
                        return midel;
                    }
                    else if (target < nums[midel])
                    {
                        L1 = midel - 1;
                        F1++;
                    }
                    else
                        F1 = midel + 1;
                    F1++;
                }
                return midel + 1;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
       
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                paragraph = paragraph.ToLower();
                paragraph = paragraph.Replace(',', ' ');
                paragraph = paragraph.Replace('.', ' ');
                paragraph = paragraph.Trim();
                Console.WriteLine("paragraph");
                string[] split = paragraph.Split(' ');
                Dictionary<string, int> map = new Dictionary<string, int>(); //adding keys to dictionary
                for (int i = 0; i < split.Length; i++)
                {
                    if (map.ContainsKey(split[i]))
                    {
                        map[split[i]]++;
                    }
                    else
                    {
                        map.Add(split[i], 1);
                    }
                    for (int j = 0; j < banned.Length; j++)
                    {
                        if (split[i] == banned[j])
                        {
                            map.Remove(split[i]);
                        }
                    }
                }
                int maxfre = 0;
                string ans = "";
                foreach (KeyValuePair<string, int> kvp in map) //loop through array
                {
                    if (maxfre < kvp.Value)
                    {
                        maxfre = kvp.Value;
                        ans = kvp.Key;
                    }
                }
                return ans;

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                Dictionary<int, int> luckynum = new Dictionary<int, int>();   //creating dictonary for matching answer format
                for (int i = 0; i < arr.Length; i++) 
                {
                    if (luckynum.ContainsKey(arr[i]))
                    {
                        luckynum[arr[i]]++;
                    }
                    else
                        luckynum.Add(arr[i], 1);
                }
                var value = luckynum.Keys.ToList();
                int final = -1;
                foreach (var key in value) // loop through the values to find the maximum
                {
                    if (luckynum[key] == key)
                    {
                        final = (Math.Max(final, key));
                    }
                }


                return final;

            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                int p = 0;
                int q = 0;
                bool[] value = new bool[secret.Length];
                Dictionary<char, int> map = new Dictionary<char, int>(); //adding keys to dictionary
                for (int i = 0; i < secret.Length; i++) 
                {
                    if (secret[i] == guess[i])
                    {
                        p++;
                        value[i] = true;
                    }
                    else
                    {
                        value[i] = false;
                    }
                    if (map.ContainsKey(secret[i]))
                    {
                        map[secret[i]] = map[secret[i]] + 1;
                    }
                    else
                    {
                        map[secret[i]] = 1;
                    }
                }
                for (int j = 0; j < guess.Length; j++)
                {
                    if (value[j]) continue;
                    if (map.ContainsKey(guess[j]) && map[guess[j]] > 0)
                    {
                        q++;
                        map[guess[j]] = map[guess[j]] - 1;
                    }
                }

                string op = p + "A" + q + "B";

                return op;

            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                //write your code here.
                int ln = s.Length;
                List<int> result = new List<int>(); //creating list for matching ans format
                int[] map = new int[26];
                for (int i = ln - 1; i >= 0; i--)
                {
                    if (map[s[i] - 97] == 0)
                    {
                        map[s[i] - 97] = i;
                    }
                }
                int index = 0;
                while (index < ln)
                {
                    int lw = index;
                    int high = map[s[index] - 97];
                    int diff = high - lw + 1;
                    for (int j = lw; j <= high; j++)
                    {
                        if (map[s[j] - 97] > high)
                        {
                            high = map[s[j] - 97];
                            diff = high - lw + 1;
                        }

                    }
                    result.Add(diff);
                    index = high + 1;
                }
                return result;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

       
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.
                int line = 1;
                int curr_pixel = 0;
                for (int i = 0; i < s.Length; i++)
                {        // looping over all the character
                    int x = s[i] - 97;                   //finding the ascii code and Substring so that we get the index for the same in th width
                                                         // if (s[i]=='k' || s[i]=='v'){
                                                         //     Console.Write(s[i]);
                                                         // }
                    if (curr_pixel + widths[x] <= 100)
                    {             //check if current line overflow
                        curr_pixel = curr_pixel + widths[x];   //if  not then fill current line pixel
                    }
                    else
                    {
                        curr_pixel = 0;                         //setting curr to 0
                        curr_pixel = curr_pixel + widths[x];    //adding to width
                        line++;                                 //incrementing line
                    }
                }
                List<int> ans = new List<int>();                //creating list for matching the ans format
                ans.Add(line);
                ans.Add(curr_pixel);
                return ans;


            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
         Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
       
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                //write your code here.
                int sl = bulls_string10.Length;
                Stack<char> stk = new Stack<char>(); //creating stack for matching ans format
                for (int i = 0; i < sl; i++)
                {
                    if (bulls_string10[i] == '(' || bulls_string10[i] == '{' || bulls_string10[i] == '[')
                    {
                        stk.Push(bulls_string10[i]); //push the left brackets to the stack
                    }
                    if (bulls_string10[i] == ')' || bulls_string10[i] == '}' || bulls_string10[i] == ']')
                    {
                        if (stk.Count <= 0)
                        {
                            return false;
                        }
                    }
                    if (bulls_string10[i] == ')')
                    {
                        if (stk.Peek() == '(')
                        {
                            stk.Pop(); // popping the bracket from the stack
                        }
                        else
                        {
                            return false;
                        }
                    }

                    if (bulls_string10[i] == '}')
                    {
                        if (stk.Peek() == '{')
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (bulls_string10[i] == ']')
                    {
                        if (stk.Peek() == '[')
                        {
                            stk.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;


            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                string[] uniquemorse = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                HashSet<string> set = new HashSet<string>();
                int ln = words.Length;
                for (int i = 0; i < ln; i++)
                {
                    var sbuilder = new StringBuilder();
                    foreach (var ch in words[i])
                    {
                        sbuilder.Append(uniquemorse[ch - 'a']); //appending string using append function
                    }
                    set.Add(sbuilder.ToString()); // adding the word to the output
                }
                return set.Count(); //returning total count


            }
            catch (Exception)
            {
                throw;
            }

        }




    }
}