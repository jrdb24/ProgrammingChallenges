using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    class Logarithm
    {
        public static double Solution(int value)
        {
            return Math.Log10(value);
        }
    }

    class SquareRoot
    {
        public static double Solution(int value)
        {
            return Math.Sqrt(value);
        }
    }

    class AreaOfCircle
    {
        public static double Solution(int Radius)
        {
            double pi = 3.14159;
            return Math.Round(pi * Radius * Radius, 2);
        }
    }

    [TestFixture]
    public class AreaOfCircleShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(314.16, AreaOfCircle.Solution(10));
            Assert.AreEqual(1256.64, AreaOfCircle.Solution(20));
            Assert.AreEqual(78.54, AreaOfCircle.Solution(5));
        }
    }

    [TestFixture]
    public class SquareRootShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(3, SquareRoot.Solution(9));
            Assert.AreEqual(4, SquareRoot.Solution(16));
            Assert.AreEqual(5, SquareRoot.Solution(25));
            Assert.AreEqual(6, SquareRoot.Solution(36));
        }
    }

    [TestFixture]
    public class LogarithmShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2, Logarithm.Solution(100));
            Assert.AreEqual(3, Logarithm.Solution(1000));
        }
    }
}
