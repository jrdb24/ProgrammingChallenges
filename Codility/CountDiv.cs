using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class CountDiv
    {
        public static int Solution(int A, int B, int K) //Scores 100%
        {
            int allAOccurrencesDivisibleByK = (A / K);
            int allBOccurrencesDivisibleByK = (B / K);
            return (allBOccurrencesDivisibleByK - allAOccurrencesDivisibleByK) + (A % K == 0 ? 1 : 0);

            //Too slow
            //return (from i in Enumerable.Range(A, (B - A) + 1) select (Int64)i).Where(a => a % K == 0).Count();
        }
    }

    [TestFixture]
    public class CountDivSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(3, CountDiv.Solution(6, 11, 2));
            Assert.AreEqual(20, CountDiv.Solution(11, 345, 17));
            Assert.AreEqual(202, CountDiv.Solution(111, 34545, 171));
        }

        [Test]
        public void TestExtreme()
        {
            Assert.AreEqual(50001, CountDiv.Solution(1000000000, 2000000000, 20000));
        }
    }
}


