using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class MissingInteger
    {
        public static int Solution(int[] A) //Scores 100%
        {
            var missingInteger = 1; 
            List<int> sorted = A.ToList();
            sorted.Sort();

            foreach (var i in sorted)
            {
                if (i == missingInteger)
                {
                    missingInteger = missingInteger + 1;
                }

                if (i > missingInteger) //we've found it
                {
                    break;
                }
            }

            return missingInteger;
        }
    }

    [TestFixture]
    public class MissingIntegerSolutionShould
    {

        [Test]
        public void ExtremeTests()
        {
            Assert.AreEqual(2, MissingInteger.Solution(new int[] { 1 }));
            Assert.AreEqual(1, MissingInteger.Solution(new int[] { Int32.MinValue, Int32.MaxValue }));
            Assert.AreEqual(1, MissingInteger.Solution(new int[] { 2 }));
            Assert.AreEqual(1, MissingInteger.Solution(new int[] { 1010101010 }));

            int[] array4 = Helper.GenerateContiguousArray(100000, 1);
            Assert.AreEqual(100001, MissingInteger.Solution(array4));
        }

        [Test]
        public void MoreTests()
        {
            int[] array3 = Helper.GenerateContiguousArray(100, -100);
            Assert.AreEqual(1, MissingInteger.Solution(array3));
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(5, MissingInteger.Solution(new int[] { 1, 3, 6, 4, 1, 2 }));
            Assert.AreEqual(7, MissingInteger.Solution(new int[] { 2147483647, 3, 6, 4, 1, 2, 5, 8 }));
            Assert.AreEqual(3, MissingInteger.Solution(new int[] { -1, -3, 6, 4, 1, 2 }));

            int[] array2 = Helper.GenerateContiguousArray(10000, 1);
            array2[989] = 10001;
            Assert.AreEqual(990, MissingInteger.Solution(array2));

            int[] array3 = Helper.GenerateContiguousArray(100000, 1);
            array3[9999] = 100001;
            Assert.AreEqual(10000, MissingInteger.Solution(array3));

            int[] array4 = Helper.GenerateContiguousArray(10, 4);
            array4[7] = 100001;
            Assert.AreEqual(1, MissingInteger.Solution(array4));
        }

        [Test]
        public void ExceptionTest()
        {
            Assert.AreEqual(3, MissingInteger.Solution(new int[] { -1, -3, 6, 4, 1, 2 }));
        }
    }
}
