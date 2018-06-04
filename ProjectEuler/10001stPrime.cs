using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    public class NthPrime
    {
        public static int Solution()
        {
            List<int> primes = new List<int>();

            //int counter = 2;

            //while (primes.Count <= 10001)
            //{
            //    if(IsPrime(counter))
            //    {
            //        primes.Add(counter);
            //    }
            //    counter++;
            //}

            primes = GetListOfPrimesBetween(1, 100000);

            return primes[10001];
        }

        public static List<int> GetListOfPrimesBetween(int start, int end)
        {
            List<int> primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }

            return primes;
        }

        public static bool IsPrimeLinq(int value)
        {
            return Enumerable.Range(1, value).Count(i => value % i == 0) == 2;
        }

        public static bool IsPrime(int value)
        {
            for(int i = 2; i < value; i++)
            {
                if (value % i == 0)
                    return false;
            }
            return true;
        }
    }

    [TestFixture]
    public class NthPrimeShould
    {
        //[Test]
        //public void TestSolution()
        //{
        //    //int blah = NthPrime.Solution();

        //    Assert.AreEqual(123, NthPrime.Solution());
        //}

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(true, NthPrime.IsPrimeLinq(2));
            Assert.AreEqual(true, NthPrime.IsPrimeLinq(3));
            Assert.AreEqual(true, NthPrime.IsPrimeLinq(7));
            Assert.AreEqual(false, NthPrime.IsPrimeLinq(8));

            Assert.AreEqual(true, NthPrime.IsPrime(2));
            Assert.AreEqual(true, NthPrime.IsPrime(3));
            Assert.AreEqual(true, NthPrime.IsPrime(7));
            Assert.AreEqual(false, NthPrime.IsPrime(8));
        }
    }
}

