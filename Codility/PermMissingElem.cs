using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class PermMissingElem
    {
        public static int Solution(int[] A) //Scores 100%
        {
            Int64 sumShouldBe = (from i in Enumerable.Range(1, A.Length + 1) select (Int64)i).ToList().Sum();
            Int64 sumActuallyIs = A.Select(a => (Int64)a).Sum();
            return Convert.ToInt32(sumShouldBe - sumActuallyIs);
        }
    }

    [TestFixture]
    public class PermMissingElemSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4, PermMissingElem.Solution(new int[] { 2, 3, 1, 5 }));
            Assert.AreEqual(10, PermMissingElem.Solution(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 }));
        }

        [Test]
        public void TestTwo()
        {
            int[] array = Helper.GenerateContiguousArray(100, 1);
            array[98] = 101;
            Assert.AreEqual(99, PermMissingElem.Solution(array));

            int[] array2 = Helper.GenerateContiguousArray(10000, 1);
            array2[989] = 10001;
            Assert.AreEqual(990, PermMissingElem.Solution(array2));

            int[] array3 = Helper.GenerateContiguousArray(100000, 1);
            array3[9999] = 100001;
            Assert.AreEqual(10000, PermMissingElem.Solution(array3));
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 3; i < 1000; i++)
            {
                Assert.DoesNotThrow(() => PermMissingElem.Solution(Helper.GenerateDistinctArray(i, 1, i + 1)));
            }
        }
    }
}


