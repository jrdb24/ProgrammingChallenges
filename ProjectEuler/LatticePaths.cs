using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class LatticePaths
    {
        public static double Solution(int sizeOfGrid)
        {
            long numberOfRoutes = 1;

            for (int i = 0; i < sizeOfGrid; i++)
            {
                numberOfRoutes *= (2 * sizeOfGrid) - i;
                numberOfRoutes /= i + 1;
            }

            return numberOfRoutes;
        }
    }

    [TestFixture]
    public class LatticePathsShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(6, LatticePaths.Solution(2));
            Assert.AreEqual(20, LatticePaths.Solution(3));
        }

        [Test]
        public void TestPower()
        {
            Assert.AreEqual(32768, Math.Pow(2,15));
            Assert.AreEqual(1048576, Math.Pow(2, 20));

            BigInteger b = BigInteger.Parse("2");

            for(int i = 2; i <= 15; i++)
                b = b * 2;

            Assert.AreEqual(BigInteger.Parse("32768"), b);
        }

        [Test]
        public void Powerof1000()
        {
            BigInteger b = BigInteger.Parse("2");

            for (int i = 2; i <= 1000; i++)
                b = b * 2;

            int result = 0;

            for(int j = 0; j < b.ToString().Length; j++)
                result += Convert.ToInt32(b.ToString()[j].ToString());

            Assert.AreEqual(1366, result);
        }
    }
}