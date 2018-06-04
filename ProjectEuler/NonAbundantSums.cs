using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler
{
    class NonAbundantSums
    {
        internal static List<int> GetProperDivisors(int value)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= value / 2; i++)
                if (value % i == 0)
                    divisors.Add(i);
            return divisors;
        }

        //internal static bool IsPerfect(int value)
        //{
        //    if (GetProperDivisors(value).Sum() == value)
        //        return true;
        //    return false;
        //}

        internal static bool IsAbundant(int value)
        {
            if (GetProperDivisors(value).Sum() > value)
                return true;
            return false;
        }

        internal static double Solution()
        {
            List<int> abundantNumbers = new List<int>();
            int sum = 0;

            for (int i = 1; i < 28123; i++)
            {
                if (IsAbundant(i))
                    abundantNumbers.Add(i);
            }

            bool[] abundant = new bool[28123];

            for (int j = 1; j < abundantNumbers.Count; j++)
            {
                for (int k = 1; k < abundantNumbers.Count; k++)
                {
                    if (abundantNumbers[j] + abundantNumbers[k] < 28123)
                    {
                        if (IsAbundant(abundantNumbers[j] + abundantNumbers[k]))
                        {
                            abundant[abundantNumbers[j] + abundantNumbers[k]] = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for(int l = 1; l < 28123; l++)
            {
                if (!abundant[l])
                    sum += l;
            }

            return sum;
        }

        internal static string LongestRepeatedSubstring(string str)
        {
            var reg = new System.Text.RegularExpressions.Regex("(.+?)(?=\\1|$)");
            //foreach (var str in list)
            //{
                string result = string.Format("{0} (x{1})", reg.Match(str).Value, reg.Matches(str).Count);
                return result;
            //}

            //if (string.IsNullOrEmpty(str))
            //    return null;

            //int N = str.Length;
            //string[] substrings = new string[N];

            //for (int i = 0; i < N; i++)
            //{
            //    substrings[i] = str.Substring(i);
            //}

            //Array.Sort(substrings);

            //string result = "";

            //for (int i = 0; i < N - 1; i++)
            //{
            //    string lcs = LongestCommonString(substrings[i], substrings[i + 1]);

            //    if (lcs.Length > result.Length)
            //    {
            //        result = lcs;
            //    }
            //}

            //return result;
        }

        //internal static string LongestCommonString(string a, string b)
        //{
        //    int n = Math.Min(a.Length, b.Length);
        //    string result = "";

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (a[i] == b[i])
        //            result = result + a[i];
        //        else
        //            break;
        //    }

        //    return result;
        //}
    }

    [TestFixture]
    public class NonAbundantSumsShould
    {
        [Test]
        public void Test()
        {
            //Assert.AreEqual(0,NonAbundantSums.Solution());

            decimal denominator = 2;

            while (denominator < 1001)
            {
                decimal d = (decimal)1 / denominator;
                Trace.WriteLine(denominator + " " + d.ToString());
                //Trace.WriteLine(NonAbundantSums.LongestRepeatedSubstring(d.ToString()));
                denominator++;
            }
        }

        [Test]
        public void TestOne()
        {
            //Assert.IsTrue(NonAbundantSums.IsPerfect(28));
            Assert.IsTrue(NonAbundantSums.IsAbundant(12));
        }

        [Test]
        public void TestDivisors()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 }, NonAbundantSums.GetProperDivisors(220));
            Assert.AreEqual(new List<int>() { 1, 2, 4, 71, 142 }, NonAbundantSums.GetProperDivisors(284));
        }
    }
}
