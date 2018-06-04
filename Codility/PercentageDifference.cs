using System.Linq;
using NUnit.Framework;
using System;

namespace Codility
{
    class PercentageDifference
    {
        public static double Equals(double a, double b)
        {
            double top = Math.Abs((a - b));
            double bottom = Math.Abs((a + b) / 2);
            return ((top / bottom) * 100);
        }
    }

    [TestFixture]
    public class PercentageDifferenceSolutionShould
    {
        [Test]
        public void TestOne()
        {
            //Assert.AreEqual(33.333333, PercentageDifference.Equals(5, 7));

            Assert.That(PercentageDifference.Equals(5, 7), Is.EqualTo(33.333333).Within(.000005));

            //Assert.AreEqual(3, PercentageDifference.Equals(97, 98.5));

        }
    }
}
