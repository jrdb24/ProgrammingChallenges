using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class PermCheck
    {
        public static int Solution(int[] A) //Scores 100%
        {
            Array.Sort(A);

            int count = 0;

            for(int i = 0; i < A.Length; i++)
            {
                if(A[i] != ++count)
                {
                    return 0;
                }
            }

            return 1;
        }
    }

    [TestFixture]
    public class PermCheckSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(1, PermCheck.Solution(new int[] { 4, 1, 3, 2 }));
            Assert.AreEqual(0, PermCheck.Solution(new int[] { 4, 1, 3 }));
            Assert.AreEqual(1, PermCheck.Solution(new int[] { 4, 1, 3, 2, 6, 5, 8, 7 }));
            Assert.AreEqual(1, PermCheck.Solution(Helper.GenerateContiguousArray(100, 1)));
            Assert.AreEqual(0, PermCheck.Solution(Helper.GenerateRandomArray(100, 1, 100000)));
            Assert.AreEqual(1, PermCheck.Solution(Helper.GenerateContiguousArray(10000, 1)));
        }
    }
}
