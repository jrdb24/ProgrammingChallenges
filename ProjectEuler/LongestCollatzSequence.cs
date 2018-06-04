using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;

namespace ProjectEuler
{
    class LongestCollatzSequence
    {
        //Answer = Starting value of 837799 which gives a Collatz Sequence count of 525

        internal static int Solution(int startingValue)
        {
            List<long> collatzSequence = new List<long>();
            collatzSequence.Add(startingValue);
            long result = startingValue;

            while(result != 1)
            {
                result = result % 2 == 0 ? result / 2 : (result * 3) + 1;
                collatzSequence.Add(result);
            }

            return collatzSequence.Count;
        }
    }

    [TestFixture]
    public class LongestCollatzSequenceShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(10, LongestCollatzSequence.Solution(13));
            Assert.AreEqual(525, LongestCollatzSequence.Solution(837799));//Project Euler answer
        }
    }
}
