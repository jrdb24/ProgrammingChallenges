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
    public class AdjacentValues
    {
        public static int Solution(int[] A)
        {
            SortedDictionary<int, List<int>> dicValues = new SortedDictionary<int, List<int>>();

            for(int i = 0; i < A.Length; i++)
            {
                int key = A[i];
                int value = i;

                if (!dicValues.ContainsKey(key))
                    dicValues.Add(key, new List<int>() { value });
                else
                    dicValues[key].Add(value);
            }

            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

            dicValues.OrderBy(k => k.Key);

            List<int> sortedKeys = new List<int>(dicValues.Keys);
            int index = 0;

            foreach (KeyValuePair<int, List<int>> kvp in dicValues)
            {
                int tempVar = kvp.Key;
                ++index;

                if (sortedKeys.Count > index)
                {
                    var nextkey = sortedKeys[index];
                    List<int> values1 = kvp.Value;
                    List<int> values2 = dicValues[nextkey];
                    pairs.AddRange(MakePairs(values1, values2));
                }
            }

            int maxIndex = GetMaxPair(pairs);
            Tuple<int, int> tupleWithMaxDistance = pairs[maxIndex];
            return tupleWithMaxDistance.Item2 - tupleWithMaxDistance.Item1;
        }

        private static int GetMaxPair(List<Tuple<int, int>> pairs)
        {
            int index = 0;
            int maxSoFar = 0;
            int maxIndex = 0;

            foreach(Tuple<int, int> t in pairs)
            {
                int diff = t.Item2 - t.Item1;

                if(diff > maxSoFar)
                {
                    maxIndex = index;
                    maxSoFar = diff;
                }

                index++;
            }

            return maxIndex;
        }

        private static IEnumerable<Tuple<int, int>> MakePairs(List<int> values1, List<int> values2)
        {
            List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();

            foreach (int i in values1)
            {
                foreach(int j in values2)
                {
                    Tuple<int, int> temp = new Tuple<int, int>(i < j ? i : j, i > j ? i : j);
                    tuples.Add(temp);
                }
            }

            return tuples;
        }
    }

    [TestFixture]
    public class AdjacentValuesShould
    {
        [Test]
        public void TestOne()
        {
           Assert.AreEqual(4, AdjacentValues.Solution(new int[] { 1, 4, 7, 3, 3, 5 }));

           //Assert.AreEqual(4, AdjacentValues.Solution(new int[] { 1, 2, 7, 3, 3, 5 }));
        }
    }
}
