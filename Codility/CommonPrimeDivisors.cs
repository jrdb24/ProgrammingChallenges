using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility
{
    class CommonPrimeDivisors
    {
        public static HashSet<int> GetPrimes(int upTo)
        {
            HashSet<int> primes = new HashSet<int>();
            int count = 0;

            for (int i = 1; i <= upTo; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j != 0)
                    {
                        count += 1;
                    }
                }
                if (count == (i - 2))
                {
                    primes.Add(i);
                }

                count = 0;
            }

            return primes;
        }

        public static HashSet<int> PrimeDivisors(int toCheck)
        {
            HashSet<int> primes = GetPrimes(toCheck);
            HashSet<int> primeDivisors = new HashSet<int>();

            foreach(int poss in primes)
            {
                for (int i = 0; i < toCheck; i++)
                {
                    if(poss * i == toCheck)
                    {
                        primeDivisors.Add(poss);
                    }
                }
            }

            return primeDivisors;
        }

        public static bool HaveSamePrimeDivisors(int first, int second)
        {
            HashSet<int> firstSet = PrimeDivisors(first);
            HashSet<int> secondSet = PrimeDivisors(second);

            if(firstSet.All(secondSet.Contains) && firstSet.Count == secondSet.Count)
                return true;
            return false;
        }
    }

    [TestFixture]
    public class CommonPrimeDivisorsSolutionShould
    {
        [Test]
        public void HaveSamePrimeDivisors()
        {
            Assert.AreEqual(true, CommonPrimeDivisors.HaveSamePrimeDivisors(15,75));
            Assert.AreEqual(false, CommonPrimeDivisors.HaveSamePrimeDivisors(10, 30));
            Assert.AreEqual(false, CommonPrimeDivisors.HaveSamePrimeDivisors(3, 5));


            //Assert.AreEqual(false, CommonPrimeDivisors.HaveSamePrimeDivisors(3, 5000000));
        }

        [Test]
        public void GetPrimes()
        {
            Assert.AreEqual(new List<int>() { 2, 3, 5, 7 }, CommonPrimeDivisors.GetPrimes(10));
        }

        [Test]
        public void GetPrimeDivisors()
        {
            Assert.AreEqual(new List<int>() { 3, 5 }, CommonPrimeDivisors.PrimeDivisors(15));
            Assert.AreEqual(new List<int>() { 3, 5 }, CommonPrimeDivisors.PrimeDivisors(75));
            Assert.AreEqual(new List<int>() { 2, 5 }, CommonPrimeDivisors.PrimeDivisors(10));
            Assert.AreEqual(new List<int>() { 2, 3, 5 }, CommonPrimeDivisors.PrimeDivisors(30));
            Assert.AreEqual(new List<int>() { 3 }, CommonPrimeDivisors.PrimeDivisors(9));
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 2; i < 100; i++)
            {
                Assert.DoesNotThrow(() => CommonPrimeDivisors.PrimeDivisors(i));
            }
        }
    }
}
