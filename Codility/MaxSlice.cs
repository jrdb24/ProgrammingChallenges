using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Codility
{
    class MaxSlice //Gets 92% on Codility
    {
        internal static int Solution(int[] array)
        {
            if (array == null || array.Length == 0)
                return 0;

            if (array.Length == 1)
                return array[0];

            if(array.Distinct().Count() == 1 && array[0] < 0)
                return array[0];

            //Kadanes algorithm
            /*
             * Initialize:
                    max_so_far = 0
                    max_ending_here = 0

                Loop for each element of the array
                  (a) max_ending_here = max_ending_here + a[i]
                  (b) if(max_ending_here < 0)
                            max_ending_here = 0
                  (c) if(max_so_far < max_ending_here)
                            max_so_far = max_ending_here
                return max_so_far
             * 
             */

            int maxSoFar = 0;
            int maxEndingHere = 0;

            for (int i = 0; i < array.Length; i++)
            {
                maxEndingHere = maxEndingHere + array[i];

                if (maxEndingHere < 0)
                    maxEndingHere = 0;

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;
            }

            return maxSoFar;
        }
    }

    [TestFixture]
    public class MaxSliceShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(5, MaxSlice.Solution(new int[] { 3, 2, -6, 4, 0 }));
            Assert.AreEqual(27, MaxSlice.Solution(new int[] { 3, 3, 3, -2, -111, -1, 9, 9, 9 }));
            Assert.AreEqual(0, MaxSlice.Solution(null));
            Assert.AreEqual(-2, MaxSlice.Solution(new int[] { -2, -2 }));
            Assert.AreEqual(2, MaxSlice.Solution(new int[] { 1, 1 }));
        }
    }
}
