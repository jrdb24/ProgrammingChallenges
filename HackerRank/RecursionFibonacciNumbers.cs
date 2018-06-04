using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class RecursionFibonacciNumbers //Scores 100% on HackerRank
    {
        public static int Solution(int toCheck)
        {
            return Fibonacci(toCheck);
        }

        public static int Fibonacci(int toCheck)
        {

            if (toCheck == 0)
                return 0;

            if (toCheck == 1)
                return 1;

            return Fibonacci(toCheck - 1) + Fibonacci(toCheck - 2);
        }
    }

    [TestFixture]
    public class RecursionFibonacciNumbersSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2, RecursionFibonacciNumbers.Solution(3));
            Assert.AreEqual(0, RecursionFibonacciNumbers.Solution(0));
            Assert.AreEqual(1, RecursionFibonacciNumbers.Solution(1));
            Assert.AreEqual(8, RecursionFibonacciNumbers.Solution(6));
        }
    }
}
