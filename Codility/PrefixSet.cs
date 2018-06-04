using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class PrefixSet
    {
        public static int Solution(int[] A) //Scores 100%
        {
            HashSet<int> distinctValues = new HashSet<int>(A);

            for(int i = 0; i < A.Length; i++)
            {
                distinctValues.Remove(A[i]);

                if (distinctValues.Count == 0)
                    return i;
            }

            return 0;
        }
    }

    [TestFixture]
    public class PrefixSetSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(3, PrefixSet.Solution(new int[] { 2, 2, 1, 0, 1 }));
            Assert.AreEqual(5, PrefixSet.Solution(new int[] { 2, 2, 1, 0, 1, 8 }));
            Assert.AreEqual(99, PrefixSet.Solution(Helper.GenerateContiguousArray(100, 1)));
            Assert.AreEqual(99999, PrefixSet.Solution(Helper.GenerateContiguousArray(100000, 1)));
        }
    }
}
