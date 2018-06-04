using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class TimeComplexityPrimality //100% on Hacker Rank
    {
        public static string Solution(int count, int[] A)
        {
            int p = count;
            string output = string.Empty;
            List<int> possiblePrimes = new List<int>(A);

            for (int a0 = 0; a0 < p; a0++)
            {
                if(IsPrime(possiblePrimes[a0]))
                    output += "Prime\n";
                else
                    output += "Not prime\n";
            }

            return output;
        }

        public static List<int> GetPrimes(int val)
        {
            //int upTo = (int)Math.Sqrt(val);

            List<int> primes = new List<int>();
            primes.AddRange(Enumerable.Range(1, val).Where(i => IsPrime(i)));
            return primes;
        }

        public static bool IsPrimeLinq(int number)
        {
            return (Enumerable.Range(1, number).Count(i => number % i == 0) == 2);
        }

        //public static IEnumerable<int> GetPrimes(int val)
        //{
        //    List<int> primes = new List<int>();
        //    primes.AddRange(Enumerable.Range(0, val).Where(i => IsPrimeLinq(i)));
        //    return primes;
        //}

        //public static bool IsPrimeLinq(int number)
        //{
        //    return (Enumerable.Range(1, number).Count(i => number % i == 0) == 2);
        //}

        //public static bool IsPrime(int toCheck)
        //{
        //    if (toCheck < 2)
        //        return false;

        //    bool isPrime = true;

        //    int l = (int)Math.Sqrt(toCheck);

        //    for (int i = 2; i <= l; ++i)
        //    {
        //        if (toCheck % i == 0)
        //        {
        //            isPrime = false;
        //            break;
        //        }
        //    }

        //    return isPrime;
        //}


        //public static bool IsPrime(int number)
        //{
        //    if (number < 2)
        //        return false;

        //    for (int i = 2; i < number; i++)
        //    {
        //        if (number % i == 0)
        //            return false;
        //    }

        //    return true;
        //}




        public static bool IsPrime(int value)
        {
            if (value < 2)
                return false;

            for(int i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }

    }

    [TestFixture]
    public class TimeComplexityPrimalitySolutionShould
    {
        [Test]
        public void GetPrimes()
        {
            Assert.AreEqual(new List<int>() { 2, 3 }, TimeComplexityPrimality.GetPrimes(3));
            Assert.AreEqual(new List<int>() { 2, 3 }, TimeComplexityPrimality.GetPrimes(4));
            Assert.AreEqual(new List<int>() { 2, 3, 5 }, TimeComplexityPrimality.GetPrimes(6));
            Assert.AreEqual(new List<int>() { 2, 3, 5, 7 }, TimeComplexityPrimality.GetPrimes(10));
            Assert.AreEqual(new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19 }, TimeComplexityPrimality.GetPrimes(20));
        }

        [Test]
        public void TestPrime()
        {
            Assert.AreEqual(true, TimeComplexityPrimality.IsPrimeLinq(3));
            Assert.AreEqual(true, TimeComplexityPrimality.IsPrime(3));

            Assert.AreEqual(false, TimeComplexityPrimality.IsPrimeLinq(8));
            Assert.AreEqual(false, TimeComplexityPrimality.IsPrime(8));

            Assert.AreEqual(false, TimeComplexityPrimality.IsPrimeLinq(121));
            Assert.AreEqual(false, TimeComplexityPrimality.IsPrime(121));

            Assert.AreEqual(true, TimeComplexityPrimality.IsPrimeLinq(97));
            Assert.AreEqual(true, TimeComplexityPrimality.IsPrime(97));
        }

        //[Test]
        //public void TestOne()
        //{
        //    Assert.AreEqual("Not prime\nPrime\nPrime\n", TimeComplexityPrimality.Solution(3, new int[] { 12, 5, 7 }));
        //    Assert.AreEqual("Prime\nNot prime\nPrime\n", TimeComplexityPrimality.Solution(3, new int[] { 1000000007, 100000003, 1000003 }));
        //}
    }
}
