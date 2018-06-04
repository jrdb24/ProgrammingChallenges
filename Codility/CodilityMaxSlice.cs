using System.Collections.Generic;
using NUnit.Framework;

namespace Codility
{
    class CodilitySlice
    {
        public static int Solution(int[] A)
        {
            if (A == null || A.Length == 0 || A.Length == 1)
                return 0;

            int maximumPairFound = 1;
            int currentSlice = 1;
            List<int> maxSliceStartIndexes = new List<int>();

            for (int i = 0; i < A.Length - 1; i++)
            {
                int P = A[i];
                int Q = A[i+1];

                if (P < Q && (++currentSlice > maximumPairFound))
                {
                    maximumPairFound++;
                    maxSliceStartIndexes.Add(i);                   
                }
                else
                {
                    currentSlice = 1;
                }
            }

            return maxSliceStartIndexes.Count > 0 ? maxSliceStartIndexes[0] : 0;
        }
    }

    [TestFixture]
    public class CodilityMaxSliceSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4, CodilitySlice.Solution(new int[] { 2, 2, 2, 2, 1, 2, -1, 2, 1, 3 }));
            Assert.AreEqual(0, CodilitySlice.Solution(new int[] { 30, 20, 10 }));
            Assert.AreEqual(0, CodilitySlice.Solution(null));
        }
    }
}
