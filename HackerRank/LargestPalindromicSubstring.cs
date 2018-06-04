using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class LargestPalindromicSubstring
    {
        public static string Solution(string input)
        {
            string output = string.Empty;

            if (input.Distinct().Count() == 1)
                return input;

            for (int i = 0; i < input.Length-1; i++)
            {
                char first = input[i];
                char second = input[i + 1];

                if (first == second)
                {
                    string temp = SearchForPalindrome(input, i, i+1);
                    output = temp.Length > output.Length ? temp : output;
                }
            }

            return output;
        }

        private static string SearchForPalindrome(string input, int leftPosition, int rightPosition)
        {
            string palindrome = string.Empty;

            while (true)
            {
                if (leftPosition == 0 || rightPosition == input.Length - 1)
                    break;

                if (input[leftPosition] == input[rightPosition])
                {
                    rightPosition++;
                    leftPosition--;
                }
                else
                {
                    leftPosition++;
                    rightPosition--;
                    break;
                }
            }

            for (int i = leftPosition; i <= rightPosition; i++)
                palindrome += input[i];
            return palindrome;
        }
    }

    [TestFixture]
    public class LargestPalindromicSubstringShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("hackerrekcah", LargestPalindromicSubstring.Solution("hackerrekcahba"));
            Assert.AreEqual("volcanoonaclov", LargestPalindromicSubstring.Solution("abcgdratvolcanoonaclovjvuaghsghfj"));
            Assert.AreEqual("montluconnocultnom", LargestPalindromicSubstring.Solution("hysdfhdghsfhdsfqhdsfhsdfhmontluconnocultnomasdhhbbcgyadyio"));
            Assert.AreEqual("montluconnocultnom", LargestPalindromicSubstring.Solution("abcgdratvollovjvuaghsghmontluconnocultnomfj"));
            Assert.AreEqual("vannav", LargestPalindromicSubstring.Solution("asjhdjkashdkjasdkjvannav"));
            Assert.AreEqual("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", LargestPalindromicSubstring.Solution("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
        }
    }
}
