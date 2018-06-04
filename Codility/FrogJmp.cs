using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility
{
    class FrogJmp
    {
        public static int Solution(int X, int Y, int D) //Scores 100%
        {
            int distanceToTravel = Y - X;
            int jumpLength = D;
            return distanceToTravel % jumpLength == 0 ? (distanceToTravel / jumpLength) : (distanceToTravel / jumpLength) + 1;
        }
    }

    [TestFixture]
    public class FrogJmpSolutionShould
    {
        [Test]
        public void FirstTest()
        {
            Assert.AreEqual(3, FrogJmp.Solution(10, 85, 30));
            Assert.AreEqual(1, FrogJmp.Solution(10, 1000000, 2000000));

            var start = DateTime.Now;
            Assert.AreEqual(987654222, FrogJmp.Solution(99, 987654321, 1));
            var end = DateTime.Now;
            Console.WriteLine("Time (ExtremeTest): " + (end - start).TotalMilliseconds + " ms");
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 2; i < 10000; i++)
            {
                int start = GenerateRandomNumber(i);
                int end = GenerateRandomNumber(start);
                int distance = GenerateRandomNumber(i);

                Assert.DoesNotThrow(() => FrogJmp.Solution(start, end, distance));
            }
        }

        private Random _random = new Random();

        private int GenerateRandomNumber(int startAt)
        {
            return _random.Next(startAt, 1000000000);
        }
    }
}
