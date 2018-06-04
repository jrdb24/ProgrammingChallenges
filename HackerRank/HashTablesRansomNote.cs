using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class HashTablesRansomNote //100% on Hacker Rank
    {
        public static string Solution(string magazine, string ransomNote)
        {
            string output = string.Empty;

            string[] magazineArray = magazine.Split(' ');
            string[] ransomNoteArray = ransomNote.Split(' ');

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string c in magazineArray)
            {
                if (!wordCounts.ContainsKey(c))
                    wordCounts.Add(c, 1);
                else
                    wordCounts[c]++;
            }

            foreach (string s in ransomNoteArray)
            {
                if (wordCounts.ContainsKey(s))
                {
                    wordCounts[s]--;
                }
                else
                {
                    wordCounts.Add(s, -1);
                }
            }

            output = wordCounts.Values.Any(v => v <= -1) ? "No" : "Yes";

            return output;
        }
    }

    [TestFixture]
    public class HashTablesRansomNoteSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("Yes", HashTablesRansomNote.Solution("give me one grand today night", "give one grand today"));
            Assert.AreEqual("No", HashTablesRansomNote.Solution("two times three is not four", "two times two is four"));
        }
    }
}
