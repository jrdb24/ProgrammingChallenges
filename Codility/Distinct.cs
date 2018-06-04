using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility
{
    class Distinct
    {
        public static int Solution(int[] A, int N)
        {
            return A.Distinct().Count();
        }
    }

    [TestFixture]
    public class DistinctSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(3, Distinct.Solution(new int[] { 2, 1, 1, 2, 3, 1 }, 6));
            Assert.AreEqual(4, Distinct.Solution(new int[] { 1, 2, 3, 4 }, 4));
        }
    }
}
