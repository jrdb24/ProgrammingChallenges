using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    public class LargestPrimeFactor
    {
        public static int Solution()
        {
            Int64 value = 600851475143;

            int squareRoot = (int)Math.Sqrt(value);

            List<int> primeFactors = Enumerable.Range(1, squareRoot).Where(i => IsPrimeFactor(i, value)).ToList();

            return primeFactors.Max();
        }

        public static bool IsPrimeFactor(int possiblePrime, Int64 factor)
        {
            if (factor % possiblePrime != 0)
                return false;

            if (possiblePrime < 2)
                return false;

            if (possiblePrime % 2 == 0)
                return false;

            bool isPrime = true;

            int l = (int)Math.Sqrt(possiblePrime);

            for (int i = 2; i <= l; ++i)
            {
                if (possiblePrime % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        //public static bool IsPrime(int toCheck)
        //{
        //    return Enumerable.Range(1, toCheck).Where(i => toCheck % i == 0).Count() == 2;
        //}
    }

    [TestFixture]
    public class LargestPrimeFactorShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(true, LargestPrimeFactor.IsPrimeFactor(7, 49));
            Assert.AreEqual(false, LargestPrimeFactor.IsPrimeFactor(7, 50));
            Assert.AreEqual(false, LargestPrimeFactor.IsPrimeFactor(8, 49));
            Assert.AreEqual(6857, LargestPrimeFactor.Solution());
        }
    }
}

