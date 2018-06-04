using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Codility
{
    public class MergingTime
    {
        public static int Solution(int[] A)
        {
            List<List<int>> permutations = new List<List<int>>();

            //CreatePermutations(permutations, A, 0, A.Length-1);

            int minSoFar = Int32.MaxValue;

            foreach(List<int> temp in permutations)
            {
                int runningCount = 0;

                for (int i = 0; i < temp.Count-1; i++)
                {
                    int sum = (temp[i] + temp[i + 1]);
                    runningCount += sum;
                }

                minSoFar = minSoFar < runningCount ? minSoFar : runningCount;
            }

            return minSoFar;
        }

        public static void CreatePermutations(List<long> permutations, long[] array, long start, long count)
        {
            if (start == count)
            {
                var listAsString = String.Join("", array.ToList().ConvertAll(x => x.ToString()).ToArray());
                permutations.Add(Int64.Parse(listAsString));
            }
            else
            {
                for (long i = start; i <= count; i++)
                {
                    Swap(ref array[start], ref array[i]);
                    CreatePermutations(permutations, array, start + 1, count);
                    Swap(ref array[start], ref array[i]);
                }
            }
        }


        public static void CreatePermutationsString(List<List<string>> permutations, string[] array, int start, int count)
        {
            if (start == count)
            {
                List<string> temp = new List<string>();

                for (int j = 0; j <= count; j++)
                {
                    temp.Add(array[j]);
                }

                StringBuilder blah = new StringBuilder();
                foreach (string s in temp)
                {
                    blah.Append(s);                 
                }
                Trace.WriteLine(blah.ToString());
                if(blah.ToString().Contains("voldemort"))
                {
                    int jj = 0;
                }
                permutations.Add(temp);
            }
            else
            {
                for (int i = start; i <= count; i++)
                {
                    SwapString(ref array[start], ref array[i]);
                    CreatePermutationsString(permutations, array, start + 1, count);
                    SwapString(ref array[start], ref array[i]);
                }
            }
        }

        private static void SwapString(ref string i, ref string j)
        {
            string temp = i;
            i = j;
            j = temp;
        }

        private static void Swap(ref long i, ref long j)
        {
            long temp = i;
            i = j;
            j = temp;
        }
    }

    [TestFixture]
    public class MergingTimeShould
    {
        [Test]
        public void Main()
        {
            long[] A = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<long> permutations = new List<long>();
            MergingTime.CreatePermutations(permutations, A, 0, A.Length - 1);
            permutations.Sort();
            Trace.WriteLine("Count: " + permutations.Count + " " + permutations[999999]);
        }

        [Test]
        public void TestTwo()
        {
            string[] A = new string[] { "t", "o", "m", "e" };
            List<List<string>> permutations = new List<List<string>>();
            MergingTime.CreatePermutationsString(permutations, A, 0, A.Length - 1);
            Assert.AreEqual(24, permutations.Count);

            string[] B = new string[] { "t", "o", "m" };
            permutations.Clear();
            MergingTime.CreatePermutationsString(permutations, B, 0, B.Length - 1);
            Assert.AreEqual(6, permutations.Count);

            string[] C = new string[] { "t", "o", "m", "e", "a" };
            permutations.Clear();
            MergingTime.CreatePermutationsString(permutations, C, 0, C.Length - 1);
            Assert.AreEqual(120, permutations.Count);

            string[] D = new string[] { "t", "o", "m", "e", "a", "i" };
            permutations.Clear();
            MergingTime.CreatePermutationsString(permutations, D, 0, D.Length - 1);
            Assert.AreEqual(720, permutations.Count);
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(false, typeof(string).IsPrimitive);
            Assert.AreEqual(true, typeof(bool).IsPrimitive);
            Assert.AreEqual(true, typeof(int).IsPrimitive);

            //Assert.AreEqual(1750, MergingTime.Solution(new int[] { 100, 250, 1000 }));

            //public static void CreatePermutationsString(List<List<string>> permutations, string[] array, int start, int count)

            //string[] A = new string[] { "t", "o", "m", "m", "a", "r", "v", "o", "l", "o", "r", "i", "d", "d", "l", "e" };
            //List<List<string>> permutations = new List<List<string>>();

            //MergingTime.CreatePermutationsString(permutations, A, 0, A.Length - 1);
        }
    }
}
