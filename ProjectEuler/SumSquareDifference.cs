using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    class SumSquareDifference
    {

        public static int SumOfTheSquares(int upTo)
        {
            int output = 0;

            for(int i = 1; i <= upTo; i++)
            {
                output += i * i;
            }

            return output;
        }

        public static int SquareOfTheSum(int upTo)
        {
            int output = 0;

            for (int i = 1; i <= upTo; i++)
            {
                output += i;
            }

            return output * output;
        }

        public static int Difference(int upTo)
        {
            return SquareOfTheSum(upTo) - SumOfTheSquares(upTo);
        }
    }

    [TestFixture]
    public class SumSquareDifferenceShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(385, SumSquareDifference.SumOfTheSquares(10));
            Assert.AreEqual(3025, SumSquareDifference.SquareOfTheSum(10));
            Assert.AreEqual(2640, SumSquareDifference.Difference(10));
            Assert.AreEqual(25164150, SumSquareDifference.Difference(100));
        }
    }
}
