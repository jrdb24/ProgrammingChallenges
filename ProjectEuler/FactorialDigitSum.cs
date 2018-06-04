using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Numerics;

namespace ProjectEuler
{
    class FactorialDigitSum
    {
        internal static double Solution(int start)
        {
            BigInteger factor = 1;
            int sum = 0;

            while(start > 0)
                factor *= start--;

            foreach(char c in factor.ToString())
                sum += Convert.ToInt32(c.ToString());

            return sum;
        }
    }

    [TestFixture]
    public class FactorialDigitSumShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(27, FactorialDigitSum.Solution(10));
            Assert.AreEqual(648, FactorialDigitSum.Solution(100));
        }
    }
}
