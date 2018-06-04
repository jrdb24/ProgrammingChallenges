using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{

     /*
      No two consecutive characters are the same.
      No two consecutive characters are in the following vowel set: a, e, i, o, u, y. Note that we consider y to be a vowel in this challenge.  
     */

    class BeautifulWord
    {
        private static HashSet<string> _vowels = new HashSet<string>() { "a", "e", "i", "o", "u", "y"};   

        public static string Solution(string word)
        {
            char[] wordArray = word.ToCharArray();

            for(int i = 0; i < wordArray.Length-1; i++)
            {
                if (wordArray[i] == wordArray[i + 1])
                    return "NO";

                if(_vowels.Contains(wordArray[i].ToString()) && _vowels.Contains(wordArray[i+1].ToString()))
                    return "NO";
            }

            return "YES";
        }
    }

    [TestFixture]
    public class BeautifulWordShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("YES", BeautifulWord.Solution("batman"));
            Assert.AreEqual("NO", BeautifulWord.Solution("apple"));
            Assert.AreEqual("NO", BeautifulWord.Solution("beauty"));
        }
    }
}
