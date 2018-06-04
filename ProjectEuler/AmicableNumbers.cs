using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Numerics;

namespace ProjectEuler
{
    class AmicableNumbers
    {
        internal static int Solution()
        {
            Dictionary<int,int> amicableNumbers = new Dictionary<int, int>();

            for(int i = 2; i < 10000; i++)
            {
                int sum1 = GetProperDivisors(i).Sum();
                int sum2 = GetProperDivisors(sum1).Sum();

                if (i == sum2 && !amicableNumbers.ContainsKey(sum2) && sum1 != sum2)
                    amicableNumbers.Add(sum1, sum2);
            }

            return amicableNumbers.Sum(x => x.Value + x.Key);
        }

        internal static List<int> GetProperDivisors(int value)
        {
            List<int> divisors = new List<int>();
            for(int i = 1; i <= value / 2; i++)
                if (value % i == 0)
                    divisors.Add(i);
            return divisors;
        }
    }

    [TestFixture]
    public class AmicableNumbersShould
    {
        [Test]
        public void TestOne()
        {
            //Assert.AreEqual(31626, AmicableNumbers.Solution()); //correct project euler answer
        }

        [Test]
        public void TestDivisors()
        {
            Assert.AreEqual(new List<int>() { 1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110 }, AmicableNumbers.GetProperDivisors(220));
            Assert.AreEqual(new List<int>() {1, 2, 4, 71, 142 }, AmicableNumbers.GetProperDivisors(284));
        }
    }
}
