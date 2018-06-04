using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codility
{
    class EquilibriumIndex
    {
        public static int Solution(int[] A)
        {
            Int64 sumToLeftOfIndex = 0;
            Int64 sumToRightOfIndex = 0;            

            if (A == null || A.Length == 0)
                return -1;

            if (A.Length == 1)
                return 0;

            Int64 totalSum = A.Select(a => (Int64)a).Sum(); //handle Maxint edge cases with Int64
            Int64 lengthOfArray = A.Length;

            for (int index = 0; index < lengthOfArray; index++)
            {
                sumToRightOfIndex = (totalSum - sumToLeftOfIndex - A[index]);//get sum of values on right of current index

                if (sumToRightOfIndex == sumToLeftOfIndex) //if we have an equilibrium
                    return index;

                sumToLeftOfIndex += A[index]; //otherwise move to next value in array
            }

            return -1;
        }
    }

    [TestFixture]
    public class EquilibriumIndexShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(-1, EquilibriumIndex.Solution(new int[0]));
            Assert.AreEqual(-1, EquilibriumIndex.Solution(null));
            Assert.AreEqual(0, EquilibriumIndex.Solution(new int[] { 3 }));
            Assert.AreEqual(1, EquilibriumIndex.Solution(new int[] { -1, 3, -4, 5, 1, -6, 2, 1 }));
            Assert.AreEqual(11, EquilibriumIndex.Solution(new int[] { 1, 4, 5, 4, 3, 2, 1, 6, 7, 8, 9, 11, 1, 4, 5, 4, 3, 2, 1, 6, 7, 8, 9 }));
            Assert.AreEqual(1, EquilibriumIndex.Solution(new int[3] { 2147483647, 2147483647 , 2147483647 } ));
            Assert.AreEqual(1, EquilibriumIndex.Solution(new int[3] { Int32.MinValue, 2147483647, Int32.MinValue }));
        }
    }
}
