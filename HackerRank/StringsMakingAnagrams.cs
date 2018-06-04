using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class StringsMakingAnagrams //100% on Hacker Rank
    {
        public static int Solution(string[] A)
        {
            return NumberNeeded(A[0], A[1]);
        }

        public static int NumberNeeded(String first, String second)
        {
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();

            foreach(char c in first.ToCharArray())
            {
                if (!letterCounts.ContainsKey(c))
                    letterCounts.Add(c, 1);
                else
                    letterCounts[c]++;
            }

            foreach (char s in second.ToCharArray())
            {
                if(letterCounts.ContainsKey(s))
                {
                    letterCounts[s]--;
                }
                else
                {
                    letterCounts.Add(s, -1);
                }
            }

            int output = 0;

            foreach(KeyValuePair<char, int> kvp in letterCounts)
            {
                output += Math.Abs(kvp.Value);
            }

            return output;
        }
    }

    [TestFixture]
    public class StringsMakingAnagramsSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4, StringsMakingAnagrams.Solution(new string[] { "cde", "abc" }));

            Assert.AreEqual(5, StringsMakingAnagrams.Solution(new string[] { "dog", "abcd" }));

            Assert.AreEqual(6, StringsMakingAnagrams.Solution(new string[] { "james", "jamesxdcfvg" }));

            Assert.AreEqual(30, StringsMakingAnagrams.Solution(new string[] { "fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke" }));

        }
    }
}
